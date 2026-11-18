namespace AnderFlowPrismIsland.Logic;

public sealed class Temporizador
{
    private TimeSpan duracao;
    public TimeSpan Restante { get; private set; }
    public bool Rodando { get; private set; }

    public Temporizador(TimeSpan duracaoInicial)
    {
        if (duracaoInicial <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(duracaoInicial));
        duracao = duracaoInicial;
        Restante = duracao;
    }

    public void Iniciar() => Rodando = Restante > TimeSpan.Zero;
    public void Pausar() => Rodando = false;

    public void Avancar(TimeSpan decorrido)
    {
        if (!Rodando || decorrido <= TimeSpan.Zero) return;
        Restante = decorrido >= Restante ? TimeSpan.Zero : Restante - decorrido;
        if (Restante == TimeSpan.Zero) Rodando = false;
    }

    public void Reiniciar(TimeSpan? novaDuracao = null)
    {
        if (novaDuracao is { } valor)
        {
            if (valor <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(novaDuracao));
            duracao = valor;
        }
        Rodando = false;
        Restante = duracao;
    }
}