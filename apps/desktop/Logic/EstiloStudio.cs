namespace AnderFlowPrismIsland.Logic;

/// <summary>Preferências de aparência do próprio Prism, nunca altera as configurações do Windows.</summary>
public static class EstiloStudio
{
    public const double OpacidadePadrao = 0.96;
    public static double Opacity(double valor)
        => double.IsFinite(valor) ? Math.Clamp(valor, 0.65, 1) : OpacidadePadrao;
    public static string PosicaoDock(string? valor)
        => valor is "superior" or "inferior" ? valor : "inferior";
}
