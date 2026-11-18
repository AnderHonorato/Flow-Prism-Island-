namespace AnderFlowPrismIsland.Logic;

public enum EstadoIlha { Recolhida, Expandida, Fixada }

public sealed class MaquinaIlha
{
    public EstadoIlha Estado { get; private set; } = EstadoIlha.Recolhida;
    public bool EstaExpandida => Estado != EstadoIlha.Recolhida;
    public void Expandir() { if (Estado == EstadoIlha.Recolhida) Estado = EstadoIlha.Expandida; }
    public void Fixar() { Estado = EstadoIlha.Fixada; }
    public void Desfixar() { if (Estado == EstadoIlha.Fixada) Estado = EstadoIlha.Expandida; }
    public void RecolherSeNaoFixada() { if (Estado != EstadoIlha.Fixada) Estado = EstadoIlha.Recolhida; }
    public void Recolher() => Estado = EstadoIlha.Recolhida;
    public void Alternar() { if (EstaExpandida) Recolher(); else Expandir(); }
}