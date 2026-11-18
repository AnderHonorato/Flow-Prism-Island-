using System.IO;
using Windows.Media.Control;

namespace AnderFlowPrismIsland.Logic;

/// <summary>Somente sessões reais fornecidas pelo controle de mídia do Windows.</summary>
public sealed class ServicoMidiaWindows
{
    private GlobalSystemMediaTransportControlsSessionManager? gerenciador;
    private GlobalSystemMediaTransportControlsSession? sessao;
    private readonly SemaphoreSlim bloqueio = new(1, 1);

    public async Task<MidiaVisivel> ConsultarAsync()
    {
        if (!await bloqueio.WaitAsync(200)) return MidiaVisivel.Vazia();
        try
        {
            gerenciador ??= await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();
            sessao = gerenciador.GetCurrentSession();
            if (sessao is null) return MidiaVisivel.Vazia();
            var propriedades = await sessao.TryGetMediaPropertiesAsync();
            var reproducao = sessao.GetPlaybackInfo();
            var controles = reproducao.Controls;
            var tempo = sessao.GetTimelineProperties();
            return MidiaVisivel.DaSessao(
                propriedades?.Title, propriedades?.Artist, NomeApp(sessao.SourceAppUserModelId),
                reproducao.PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing,
                controles?.IsPlayPauseToggleEnabled ?? false,
                controles?.IsNextEnabled ?? false,
                controles?.IsPreviousEnabled ?? false,
                tempo.Position, tempo.EndTime - tempo.StartTime);
        }
        catch { sessao = null; return MidiaVisivel.Vazia(); }
        finally { bloqueio.Release(); }
    }
    private static string NomeApp(string? appid)
    {
        if (string.IsNullOrWhiteSpace(appid)) return "Aplicativo";
        var texto = Path.GetFileNameWithoutExtension(appid);
        return texto.Length > 38 ? texto[..38] : texto;
    }
    public async Task<bool> AlternarAsync()
    {
        try { if(sessao is null) await ConsultarAsync(); return sessao is not null && await sessao.TryTogglePlayPauseAsync(); }
        catch { return false; }
    }
    public async Task<bool> AvancarAsync()
    {
        try { if(sessao is null) await ConsultarAsync(); return sessao is not null && await sessao.TrySkipNextAsync(); }
        catch { return false; }
    }
    public async Task<bool> VoltarAsync()
    {
        try { if(sessao is null) await ConsultarAsync(); return sessao is not null && await sessao.TrySkipPreviousAsync(); }
        catch { return false; }
    }
}