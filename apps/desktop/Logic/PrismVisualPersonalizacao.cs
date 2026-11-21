using System.Text.RegularExpressions;
namespace AnderFlowPrismIsland.Logic;
/// <summary>Regras de visualização locais do Prism; nada modifica o shell por estes ajustes.</summary>
public static class PrismVisualPersonalizacao
{
    public const string CorPadrao = "#E8622A";
    public static double TamanhoEntalhe(double valor) => double.IsFinite(valor) ? Math.Clamp(valor, 230d, 430d) : 282d;
    public static double LarguraStudio(double valor) => double.IsFinite(valor) ? Math.Clamp(valor, 680d, 980d) : 752d;
    public static double Velocidade(double valor) => double.IsFinite(valor) ? Math.Clamp(valor, .5d, 1.8d) : 1d;
    public static double Intensidade(double valor) => double.IsFinite(valor) ? Math.Clamp(valor, .3d, 1.7d) : 1d;

    public static string Cor(string? hex)
    {
        var valor = hex?.Trim();
        return valor is not null && Regex.IsMatch(valor, "^#[0-9A-Fa-f]{6}$")
            ? valor.ToUpperInvariant() : CorPadrao;
    }

    public static bool MiniIndependente(bool sempreVisivel, bool tocando, bool entalheOculto, bool telaCheia)
        => sempreVisivel && tocando && entalheOculto && !telaCheia;
}
