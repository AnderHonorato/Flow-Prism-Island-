namespace AnderFlowPrismIsland.Logic;

public static class LinhaTempoMidia
{
    public static double Percentual(TimeSpan posicao, TimeSpan duracao)
    {
        if (duracao.Ticks <= 0) return 0;
        return Math.Clamp(posicao.TotalMilliseconds / duracao.TotalMilliseconds * 100, 0, 100);
    }

    public static TimeSpan Posicao(double percentual, TimeSpan duracao)
    {
        if (duracao <= TimeSpan.Zero || !double.IsFinite(percentual)) return TimeSpan.Zero;
        return TimeSpan.FromTicks((long)(duracao.Ticks * Math.Clamp(percentual, 0d, 100d) / 100d));
    }
}
