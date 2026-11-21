namespace AnderFlowPrismIsland.Logic;
/// <summary>Interpretação visual de amplitude. Não armazena amostras nem reproduz som.</summary>
public static class EspectroAudio
{
    public static double Limitar(double valor) =>
        double.IsFinite(valor) ? Math.Clamp(valor, 0d, 1d) : 0d;

    public static double Suavizar(double anterior, double novo, double resposta)
    {
        resposta = Limitar(resposta);
        return Limitar(anterior + (Limitar(novo) - Limitar(anterior)) * resposta);
    }

    public static double Barra(int indice, int total, double nivel, double instante)
    {
        nivel = Limitar(nivel);
        if (total <= 0) return 0;
        double centro = (total - 1d) / 2d;
        double forma = .26d + .74d * Math.Pow(Math.Max(0, 1d - Math.Abs(indice-centro) / Math.Max(1d, centro)), .5);
        double textura = .54d + .46d * Math.Abs(Math.Sin(indice * 1.33d + instante * 1.35d));
        double energia = Math.Pow(nivel, .68d);
        return Limitar(.065d + energia * forma * textura * .93d);
    }
}
