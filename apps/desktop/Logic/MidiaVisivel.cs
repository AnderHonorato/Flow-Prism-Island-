namespace AnderFlowPrismIsland.Logic;

public sealed record MidiaVisivel(
    bool TemSessao, string Titulo, string Artista, string Aplicativo,
    bool Tocando, bool PodePausar, bool PodeAvancar, bool PodeVoltar,
    TimeSpan Posicao, TimeSpan Duracao,
    bool PodeBuscar = false, byte[]? CapaBytes = null, string? IdSessao = null)
{
    public static MidiaVisivel Vazia() => new(false, "Nenhuma mídia em reprodução", "", "",
        false, false, false, false, TimeSpan.Zero, TimeSpan.Zero);

    public static MidiaVisivel DaSessao(
        string? titulo, string? artista, string? aplicativo,
        bool tocando, bool podePausar, bool podeAvancar,
        bool podeVoltar = true, TimeSpan? posicao = null, TimeSpan? duracao = null,
        bool podeBuscar = false, byte[]? capaBytes = null, string? idSessao = null) =>
        new(true, string.IsNullOrWhiteSpace(titulo) ? "Título não informado" : titulo.Trim(),
            artista?.Trim() ?? "", aplicativo?.Trim() ?? "Aplicativo",
            tocando, podePausar, podeAvancar, podeVoltar,
            posicao ?? TimeSpan.Zero, duracao ?? TimeSpan.Zero,
            podeBuscar, capaBytes, idSessao);
}
