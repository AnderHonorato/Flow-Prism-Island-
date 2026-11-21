using AnderFlowPrismIsland.Controls;
using AnderFlowPrismIsland.Logic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Brushes = System.Windows.Media.Brushes;
using Orientation = System.Windows.Controls.Orientation;

namespace AnderFlowPrismIsland;

/// <summary>
/// Mini visualizador destacado quando o entalhe está oculto e a opção permanente é usada.
/// Acesso ao som acontece somente no serviço de áudio principal.
/// </summary>
public sealed class MiniVisualWindow : Window
{
    public EspectroPrism Espectro { get; }

    public MiniVisualWindow(Action mostrarEntalhe)
    {
        Title = "Prism • música";
        WindowStyle = WindowStyle.None;
        ResizeMode = ResizeMode.NoResize;
        AllowsTransparency = true;
        ShowInTaskbar = false;
        ShowActivated = false;
        Topmost = true;
        Width = 164;
        Height = 40;
        Background = Brushes.Transparent;
        var bordo = new Border
        {
            CornerRadius = new CornerRadius(20),
            Background = new LinearGradientBrush(
                (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#292031"),
                (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#11111D"), 18),
            BorderBrush = new SolidColorBrush(
                (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#855675")),
            BorderThickness = new Thickness(1),
            Padding = new Thickness(13, 6, 13, 6),
            Cursor = System.Windows.Input.Cursors.Hand,
            Effect = new DropShadowEffect { Color = Colors.Black, ShadowDepth = 6, BlurRadius = 20, Opacity = .65 }
        };
        var faixa = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Center };
        faixa.Children.Add(new TextBlock
        {
            Text = "♪", FontSize = 17, Foreground = Brushes.White,
            Margin = new Thickness(0, 0, 10, 0), VerticalAlignment = VerticalAlignment.Center
        });
        Espectro = new EspectroPrism { Width = 107, Height = 23, Barras = 16, Ativo = true };
        faixa.Children.Add(Espectro);
        bordo.Child = faixa;
        Content = bordo;
        bordo.MouseLeftButtonUp += (_, _) => mostrarEntalhe();
        Reposicionar();
    }

    public void Reposicionar()
    {
        var area = SystemParameters.WorkArea;
        Left = area.Left + (area.Width - Width) / 2d;
        Top = area.Top + 8d;
    }
}
