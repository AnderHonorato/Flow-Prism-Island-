namespace AnderFlowPrismIsland.Logic;

/// <summary>Opções validadas de atraso da ocultação para evitar valores inválidos nas preferências.</summary>
public static class TempoOcultacao
{
    public const int PadraoMs = 2500;

    public static int Normalizar(int milissegundos) =>
        milissegundos is 1500 or 2500 or 5000 ? milissegundos : PadraoMs;

    public static int Proximo(int milissegundos) => Normalizar(milissegundos) switch
    {
        1500 => 2500,
        2500 => 5000,
        5000 => 1500,
        _ => PadraoMs
    };
}
