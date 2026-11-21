using AnderFlowPrismIsland.Logic;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace AnderFlowPrismIsland.Controls;

/// <summary>
/// Visualizador 2D de amplitude de áudio do Windows.
/// Desenha localmente sem imagens externas e sem armazenar amostras.
/// </summary>
public sealed class EspectroPrism : FrameworkElement
{
    private readonly DispatcherTimer animador = new() { Interval = TimeSpan.FromMilliseconds(33) };
    private readonly System.Diagnostics.Stopwatch relogio = System.Diagnostics.Stopwatch.StartNew();
    private double nivel, nivelSuavizado;
    private bool ativo;
    private string hexadecimal = PrismVisualPersonalizacao.CorPadrao;
    private Brush pincel = Brushes.Coral;
    private Brush brilho = Brushes.DarkOrange;

    public EspectroPrism()
    {
        Focusable = false;
        Barras = 21;
        AtualizarPincel();
        animador.Tick += (_, _) =>
        {
            if (!IsVisible) { animador.Stop(); return; }
            nivelSuavizado = EspectroAudio.Suavizar(nivelSuavizado, nivel, nivel > nivelSuavizado ? .39 : .16);
            InvalidateVisual();
        };
        Loaded += (_, _) => AjustarAnimador();
        Unloaded += (_, _) => animador.Stop();
        IsVisibleChanged += (_, _) => AjustarAnimador();
    }

    public int Barras { get; set; }
    public double Intensidade { get; set; } = 1;
    public double Velocidade { get; set; } = 1;
    public double Nivel
    {
        get => nivel;
        set { nivel = EspectroAudio.Limitar(value); if (!ativo) InvalidateVisual(); }
    }
    public bool Ativo
    {
        get => ativo;
        set { if (ativo == value) return; ativo = value; if (!ativo) { nivel = 0; nivelSuavizado = 0; } AjustarAnimador(); InvalidateVisual(); }
    }
    public string CorDestaque
    {
        get => hexadecimal;
        set { hexadecimal = PrismVisualPersonalizacao.Cor(value); AtualizarPincel(); InvalidateVisual(); }
    }

    private void AtualizarPincel()
    {
        var cor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(hexadecimal);
        var topo = System.Windows.Media.Color.FromRgb(
            (byte)Math.Min(255, cor.R + 55), (byte)Math.Min(255, cor.G + 48), (byte)Math.Min(255, cor.B + 44));
        var gradiente = new LinearGradientBrush(topo, cor, 90);
        gradiente.Freeze();
        pincel = gradiente;
        var luminoso = new SolidColorBrush(System.Windows.Media.Color.FromArgb(66, cor.R, cor.G, cor.B));
        luminoso.Freeze();
        brilho = luminoso;
    }

    private void AjustarAnimador()
    {
        if (ativo && IsLoaded && IsVisible)
        {
            if (!animador.IsEnabled) animador.Start();
        }
        else animador.Stop();
    }

    protected override void OnRender(DrawingContext desenho)
    {
        base.OnRender(desenho);
        double largura = RenderSize.Width;
        double altura = RenderSize.Height;
        if (largura <= 0 || altura <= 0) return;
        int total = Math.Clamp(Barras, 3, 40);
        double espaco = largura >= 180 ? 3.6d : 2d;
        double faixa = (largura - espaco * (total - 1)) / total;
        if (faixa <= 0) { espaco = 1; faixa = Math.Max(1, (largura - (total-1)) / total); }
        double intervalo = relogio.Elapsed.TotalSeconds * PrismVisualPersonalizacao.Velocidade(Velocidade);
        double ganho = PrismVisualPersonalizacao.Intensidade(Intensidade);
        for (int i = 0; i < total; i++)
        {
            double amplitude = ativo ? EspectroAudio.Barra(i, total, nivelSuavizado * ganho, intervalo) : .065d;
            double h = Math.Max(2.8d, Math.Min(altura * .92d, amplitude * altura));
            double x = i * (faixa + espaco);
            double y = (altura - h) / 2d;
            double raio = Math.Max(1.2d, Math.Min(faixa / 2d, 4d));
            desenho.DrawRoundedRectangle(brilho, null,
                new Rect(x - .8d, y - 2d, faixa + 1.6d, h + 4d), raio+1, raio+1);
            desenho.DrawRoundedRectangle(pincel, null,
                new Rect(x, y, faixa, h), raio, raio);
        }
    }
}
