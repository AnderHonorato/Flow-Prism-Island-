using System;
using System.IO;
using System.Linq;
using Windows.Media.Control;
using Windows.Storage.Streams;

namespace AnderFlowPrismIsland.Logic;

public sealed record SessaoPlayer(string Id, string Nome);

/// <summary>Integração GSMTC com sessões efetivas do Windows e artwork em memória.</summary>
public sealed class ServicoMidiaWindows
{
    private GlobalSystemMediaTransportControlsSessionManager? gerenciador;
    private GlobalSystemMediaTransportControlsSession? sessao;
    private readonly SemaphoreSlim bloqueio = new(1, 1);
    private string? playerEscolhido;
    private string? chaveCapa;
    private byte[]? capaAnterior;

    public void EscolherPlayer(string? id) => playerEscolhido = string.IsNullOrWhiteSpace(id) ? null : id;
    public string? PlayerEscolhido => playerEscolhido;

    public IReadOnlyList<SessaoPlayer> ListarPlayers()
    {
        try
        {
            if (gerenciador is null) return Array.Empty<SessaoPlayer>();
            return gerenciador.GetSessions()
                .Where(x => !string.IsNullOrWhiteSpace(x.SourceAppUserModelId))
                .GroupBy(x => x.SourceAppUserModelId, StringComparer.OrdinalIgnoreCase)
                .Select(g => new SessaoPlayer(g.Key, NomeApp(g.Key)))
                .OrderBy(x => x.Nome)
                .ToArray();
        }
        catch { return Array.Empty<SessaoPlayer>(); }
    }

    public async Task<MidiaVisivel> ConsultarAsync()
    {
        if (!await bloqueio.WaitAsync(350)) return MidiaVisivel.Vazia();
        try
        {
            gerenciador ??= await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();
            var todas = gerenciador.GetSessions();
            sessao = !string.IsNullOrWhiteSpace(playerEscolhido)
                ? todas.FirstOrDefault(s => string.Equals(s.SourceAppUserModelId, playerEscolhido, StringComparison.OrdinalIgnoreCase))
                : null;
            sessao ??= gerenciador.GetCurrentSession();
            if (sessao is null) return MidiaVisivel.Vazia();

            var propriedades = await sessao.TryGetMediaPropertiesAsync();
            var reproducao = sessao.GetPlaybackInfo();
            var controles = reproducao.Controls;
            var tempo = sessao.GetTimelineProperties();
            string id = sessao.SourceAppUserModelId ?? "";
            string titulo = propriedades?.Title ?? "";
            string artista = propriedades?.Artist ?? "";
            string capaAtual = id + "|" + titulo + "|" + artista;
            if (chaveCapa != capaAtual)
            {
                chaveCapa = capaAtual;
                capaAnterior = await LerCapaAsync(propriedades?.Thumbnail);
            }
            return MidiaVisivel.DaSessao(
                titulo, artista, NomeApp(id),
                reproducao.PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing,
                controles?.IsPlayPauseToggleEnabled ?? false,
                controles?.IsNextEnabled ?? false,
                controles?.IsPreviousEnabled ?? false,
                tempo.Position, tempo.EndTime - tempo.StartTime,
                controles?.IsPlaybackPositionEnabled ?? false,
                capaAnterior, id);
        }
        catch
        {
            sessao = null;
            return MidiaVisivel.Vazia();
        }
        finally { bloqueio.Release(); }
    }

    private static async Task<byte[]?> LerCapaAsync(IRandomAccessStreamReference? referencia)
    {
        if (referencia is null) return null;
        try
        {
            using var stream = await referencia.OpenReadAsync();
            if (stream.Size <= 0 || stream.Size > 2 * 1024 * 1024) return null;
            using var leitor = new DataReader(stream.GetInputStreamAt(0));
            uint carregados = await leitor.LoadAsync((uint)stream.Size);
            if (carregados == 0) return null;
            var bytes = new byte[carregados];
            leitor.ReadBytes(bytes);
            return bytes;
        }
        catch { return null; }
    }

    private static string NomeApp(string? appid)
    {
        if (string.IsNullOrWhiteSpace(appid)) return "Aplicativo";
        var nome = Path.GetFileNameWithoutExtension(appid);
        return nome.Length > 38 ? nome[..38] : nome;
    }

    public async Task<bool> BuscarAsync(TimeSpan posicao)
    {
        try
        {
            if (sessao is null) await ConsultarAsync();
            if (sessao?.GetPlaybackInfo().Controls?.IsPlaybackPositionEnabled != true) return false;
            return await sessao.TryChangePlaybackPositionAsync(Math.Max(0, posicao.Ticks));
        }
        catch { return false; }
    }

    public async Task<bool> AlternarAsync()
    {
        try
        {
            if (sessao is null) await ConsultarAsync();
            return sessao is not null && await sessao.TryTogglePlayPauseAsync();
        }
        catch { return false; }
    }

    public async Task<bool> AvancarAsync()
    {
        try
        {
            if (sessao is null) await ConsultarAsync();
            return sessao is not null && await sessao.TrySkipNextAsync();
        }
        catch { return false; }
    }

    public async Task<bool> VoltarAsync()
    {
        try
        {
            if (sessao is null) await ConsultarAsync();
            return sessao is not null && await sessao.TrySkipPreviousAsync();
        }
        catch { return false; }
    }
}
