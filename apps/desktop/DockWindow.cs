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

namespace AnderFlowPrismIsland;

/// <summary>
/// Dock complementar reversível. Não oculta nem modifica a taskbar do Windows.
/// </summary>
public sealed class DockWindow : Window
{
    private readonly WrapPanel appsAbertos = new() { Orientation = Orientation.Horizontal };
    private readonly DispatcherTimer atualizar = new() { Interval = TimeSpan.FromSeconds(8) };
    private readonly Action abrirMidia;

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

    public DockWindow(Action abrirMidia)
    {
        this.abrirMidia = abrirMidia;
        Title = "Dock Flow";
        Width = 600;
        Height = 85;
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
        Top = area.Bottom - Height - 5;

        var bordo = new Border
        {
            Background = Cor("#0A0A0F"),
            BorderBrush = Cor("#E8622A"),
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(20),
            Padding = new Thickness(10, 9, 10, 9)
        };
        var linha = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };
        linha.Children.Add(CriarBotao("FL", "Abrir Prism Island", () => this.abrirMidia(), true));
        linha.Children.Add(CriarBotao("Files", "Explorador de arquivos", () => Iniciar("explorer.exe")));
        linha.Children.Add(CriarBotao("Web", "Navegador padrão", () => Iniciar("https://www.google.com")));
        linha.Children.Add(CriarBotao("Ajustes", "Configurações do Windows", () => Iniciar("ms-settings:")));
        linha.Children.Add(new Border
        {
            Width = 1, Height = 38, Background = Cor("#544F55"),
            Margin = new Thickness(9, 0, 9, 0)
        });
        var grupos = new StackPanel { VerticalAlignment = VerticalAlignment.Center };
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
        presenter.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Center);
        presenter.SetValue(VerticalAlignmentProperty, VerticalAlignment.Center);
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
