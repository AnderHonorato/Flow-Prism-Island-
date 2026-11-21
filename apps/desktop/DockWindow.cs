using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Brush = System.Windows.Media.Brush;
using Button = System.Windows.Controls.Button;
using Brushes = System.Windows.Media.Brushes;
using Orientation = System.Windows.Controls.Orientation;

namespace AnderFlowPrismIsland;

/// <summary>
/// Dock complementar reversível. Não oculta nem modifica a taskbar do Windows.
/// </summary>
public sealed class DockWindow : Window
{
    private readonly WrapPanel appsAbertos = new() { Orientation = Orientation.Horizontal };
    private readonly DispatcherTimer atualizar = new() { Interval = TimeSpan.FromSeconds(8) };
    private readonly Action abrirMidia;
    private readonly Action abrirStudio;
    private string posicao = "inferior";

    [DllImport("user32.dll")]
    private static extern bool EnumWindows(EnumerarJanela proc, IntPtr parametro);
    private delegate bool EnumerarJanela(IntPtr hwnd, IntPtr parametro);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IsWindowVisible(IntPtr janela);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetWindowText(IntPtr janela, StringBuilder texto, int comprimento);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetWindowTextLength(IntPtr janela);
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr janela);
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr janela, int codigo);

    public DockWindow(Action abrirMidia, Action abrirStudio)
    {
        this.abrirMidia = abrirMidia;
        this.abrirStudio = abrirStudio;
        Title = "Dock Flow";
        Width = 650;
        Height = 82;
        ResizeMode = ResizeMode.NoResize;
        WindowStyle = WindowStyle.None;
        AllowsTransparency = true;
        Background = Brushes.Transparent;
        ShowInTaskbar = false;
        ShowActivated = false;
        Topmost = true;
        WindowStartupLocation = WindowStartupLocation.Manual;
        var area = SystemParameters.WorkArea;
        Left = area.Left + Math.Max(0, (area.Width - Width) / 2);
        Top = area.Bottom - Height - 9;

        var bordo = new Border
        {
            Background = new LinearGradientBrush(CorRgb("#221E32"), CorRgb("#0B0A13"), 16),
            BorderBrush = Cor("#A26B61"),
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(21),
            Padding = new Thickness(12, 9, 12, 9),
            Effect = new System.Windows.Media.Effects.DropShadowEffect { Color = System.Windows.Media.Colors.Black, BlurRadius = 28, ShadowDepth = 9, Opacity = 0.55 }
        };
        var linha = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = System.Windows.VerticalAlignment.Center };
        linha.Children.Add(CriarBotao("FL", "Abrir Prism Island", () => this.abrirMidia(), true));
        linha.Children.Add(CriarBotao("Files", "Explorador de arquivos", () => Iniciar("explorer.exe")));
        linha.Children.Add(CriarBotao("Web", "Navegador padrão", () => Iniciar("https://www.google.com")));
        linha.Children.Add(CriarBotao("Studio", "Personalização dentro do Prism", () => this.abrirStudio()));
        linha.Children.Add(new Border
        {
            Width = 1, Height = 38, Background = Cor("#544F55"),
            Margin = new Thickness(9, 0, 9, 0)
        });
        var grupos = new StackPanel { VerticalAlignment = System.Windows.VerticalAlignment.Center };
        grupos.Children.Add(new TextBlock
        {
            Text = "JANELAS ABERTAS", Foreground = Cor("#A19BA1"),
            FontSize = 9, Margin = new Thickness(3, 0, 0, 4)
        });
        grupos.Children.Add(appsAbertos);
        linha.Children.Add(grupos);
        bordo.Child = linha;
        Content = bordo;
        Loaded += (_, _) => AtualizarJanelas();
        atualizar.Tick += (_, _) => AtualizarJanelas();
        atualizar.Start();
        Closed += (_, _) => atualizar.Stop();
    }

    private static Brush Cor(string cor) => (Brush)new BrushConverter().ConvertFromString(cor)!;
    private static System.Windows.Media.Color CorRgb(string cor) => (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(cor);

    public void AtualizarPreferencias(double opacidade, string novaPosicao)
    {
        posicao = AnderFlowPrismIsland.Logic.EstiloStudio.PosicaoDock(novaPosicao);
        Opacity = AnderFlowPrismIsland.Logic.EstiloStudio.Opacity(opacidade);
        var area = SystemParameters.WorkArea;
        Left = area.Left + Math.Max(0, (area.Width - Width) / 2);
        Top = posicao == "superior" ? area.Top + 70 : area.Bottom - Height - 9;
    }

    private Button CriarBotao(string texto, string dica, Action acao, bool destaque = false)
    {
        var botao = new Button
        {
            Content = texto,
            ToolTip = dica,
            FontSize = 11,
            FontWeight = FontWeights.SemiBold,
            Foreground = Brushes.White,
            Background = Cor(destaque ? "#E8622A" : "#29262F"),
            BorderThickness = new Thickness(0),
            Padding = new Thickness(9, 8, 9, 8),
            MinWidth = 43,
            Margin = new Thickness(2, 0, 2, 0),
            Cursor = System.Windows.Input.Cursors.Hand
        };
        var estilo = new Style(typeof(Button));
        var template = new ControlTemplate(typeof(Button));
        var border = new FrameworkElementFactory(typeof(Border));
        border.SetValue(Border.CornerRadiusProperty, new CornerRadius(11));
        border.SetBinding(Border.BackgroundProperty, new System.Windows.Data.Binding("Background")
        { RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent) });
        var presenter = new FrameworkElementFactory(typeof(ContentPresenter));
        presenter.SetValue(HorizontalAlignmentProperty, System.Windows.HorizontalAlignment.Center);
        presenter.SetValue(VerticalAlignmentProperty, System.Windows.VerticalAlignment.Center);
        presenter.SetValue(ContentPresenter.MarginProperty, new Thickness(8, 5, 8, 5));
        border.AppendChild(presenter);
        template.VisualTree = border;
        estilo.Setters.Add(new Setter(Button.TemplateProperty, template));
        botao.Style = estilo;
        botao.Click += (_, _) => acao();
        return botao;
    }

    private static void Iniciar(string destino)
    {
        try { Process.Start(new ProcessStartInfo(destino) { UseShellExecute = true }); }
        catch { /* Evita interromper o desktop se um atalho falhar. */ }
    }

    private void AtualizarJanelas()
    {
        var janelas = new List<(IntPtr Handle, string Titulo)>();
        EnumWindows((handle, _) =>
        {
            if (!IsWindowVisible(handle) || handle == new System.Windows.Interop.WindowInteropHelper(this).Handle)
                return true;
            int tamanho = GetWindowTextLength(handle);
            if (tamanho < 3 || tamanho > 300) return true;
            var sb = new StringBuilder(tamanho + 1);
            GetWindowText(handle, sb, sb.Capacity);
            var texto = sb.ToString();
            if (string.IsNullOrWhiteSpace(texto) || texto.StartsWith("Dock Flow", StringComparison.OrdinalIgnoreCase))
                return true;
            janelas.Add((handle, texto));
            return janelas.Count < 18;
        }, IntPtr.Zero);

        appsAbertos.Children.Clear();
        foreach (var item in janelas.Take(5))
        {
            var titulo = item.Titulo;
            var h = item.Handle;
            var curto = titulo.Length > 8 ? titulo[..8] + "…" : titulo;
            appsAbertos.Children.Add(CriarBotao(curto, titulo, () =>
            {
                ShowWindow(h, 9);
                SetForegroundWindow(h);
            }));
        }
        if (janelas.Count == 0)
            appsAbertos.Children.Add(new TextBlock
            { Text = "Sem janelas", Foreground = Cor("#A19BA1"), FontSize = 11 });
    }
}
