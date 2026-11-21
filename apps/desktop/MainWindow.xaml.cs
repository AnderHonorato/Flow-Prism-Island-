using AnderFlowPrismIsland.Logic;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Microsoft.Win32;
using Forms = System.Windows.Forms;
using Drawing = System.Drawing;
using Point = System.Windows.Point;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace AnderFlowPrismIsland;

public partial class MainWindow : Window
{
    private const int HotkeyId = 7711;
    private const int WmHotkey = 0x0312;
    private const uint ModCtrlShift = 0x0002 | 0x0004;
    private readonly MaquinaIlha ilha = new();
    private readonly Temporizador foco = new(TimeSpan.FromMinutes(25));
    private readonly DispatcherTimer relogio = new() { Interval = TimeSpan.FromSeconds(1) };
    private readonly DispatcherTimer recolhimento = new() { Interval = TimeSpan.FromMilliseconds(760) };
    private readonly string caminhoConfiguracoes = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "Ander Flow", "Prism Island", "configuracoes.json");
    private DateTime ultimoTick = DateTime.UtcNow;
    private Forms.NotifyIcon? iconeBandeja;
    private HwndSource? origemMensagens;
    private bool atalhoDisponivel;
    private string tema = "prism";
    private bool iniciarComWindows;
    private bool encerrando;
    private double larguraRecolhida = 282;
    private bool autoOcultar = true;
    private int tempoAutoOcultarMs = TempoOcultacao.PadraoMs;
    private bool oculta;
    private bool ocultarEmTelaCheia = true;
    private bool telaCheia;
    private int ciclosVigia;
    private Forms.Screen? telaAtual;
    private DateTime ultimaInteracao = DateTime.UtcNow;
    private readonly DispatcherTimer vigia = new() { Interval = TimeSpan.FromMilliseconds(120) };

    [StructLayout(LayoutKind.Sequential)]
    private struct PontoNativo { public int X; public int Y; }
    [DllImport("shell32.dll")]
    private static extern int SHQueryUserNotificationState(out int estado);
    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out PontoNativo ponto);
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool RegisterHotKey(IntPtr janela, int id, uint modificadores, uint tecla);
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool UnregisterHotKey(IntPtr janela, int id);

    public MainWindow()
    {
        InitializeComponent();
        relogio.Tick += (_, _) => AtualizarRelogio();
        vigia.Tick += (_, _) => VigiarBorda();
        recolhimento.Tick += (_, _) =>
        {
            recolhimento.Stop();
            if (!IsMouseOver && ilha.Estado != EstadoIlha.Fixada)
                Recolher();
        };
    }

    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        origemMensagens = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
        origemMensagens.AddHook(ReceberMensagem);
        atalhoDisponivel = RegisterHotKey(origemMensagens.Handle, HotkeyId, ModCtrlShift, 0x20);
    }

    private IntPtr ReceberMensagem(IntPtr hwnd, int mensagem, IntPtr wparam, IntPtr lparam, ref bool tratado)
    {
        if (mensagem == WmHotkey && wparam.ToInt32() == HotkeyId)
        {
            if (ilha.EstaExpandida) Recolher();
            else Expandir();
            tratado = true;
        }
        if (mensagem == WmClipboardUpdate) AoMudarAreaTransferencia();
        return IntPtr.Zero;
    }

    private void AoCarregar(object sender, RoutedEventArgs e)
    {
        CarregarConfiguracoes();
        AplicarTema();
        AtualizarRelogio();
        AtualizarAbas("midia");
        AtualizarCronometro();
        CriarBandeja();
        Posicionar();
        relogio.Start();
        ultimaInteracao = DateTime.UtcNow;
        vigia.Start();
        IniciarIntegracoes();
        AplicarPreferenciasStudio();
    }

    private void Posicionar()
    {
        var area = AreaTrabalho();
        Left = area.Left + (area.Width - Width) / 2;
        Top = area.Top + 8;
    }

    private void Animar(DependencyProperty propriedade, double valor, int duracao = 220)
    {
        if (!SystemParameters.MenuAnimation)
        {
            SetValue(propriedade, valor);
            return;
        }
        var animacao = new DoubleAnimation(valor, TimeSpan.FromMilliseconds(duracao))
        {
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
            FillBehavior = FillBehavior.HoldEnd
        };
        BeginAnimation(propriedade, animacao, HandoffBehavior.SnapshotAndReplace);
    }

    private void AjustarJanela(bool expandida)
    {
        double largura = expandida ? larguraStudio : larguraRecolhida;
        double altura = expandida ? 620 : 56;
        var area = AreaTrabalho();
        if (expandida) PainelAberto.Visibility = Visibility.Visible;
        IndicadorAbertura.Text = expandida ? "⌃" : "⌄";
        Animar(WidthProperty, largura);
        Animar(HeightProperty, altura);
        Animar(LeftProperty, area.Left + (area.Width - largura) / 2);
        if (!expandida)
            PainelAberto.Visibility = Visibility.Collapsed;
    }

    private void Expandir()
    {
        Revelar();
        recolhimento.Stop();
        ilha.Expandir();
        AjustarJanela(true);
    }

    private void Recolher()
    {
        ultimaInteracao = DateTime.UtcNow;
        recolhimento.Stop();
        ilha.Recolher();
        BotaoFixar.Content = "Fixar";
        AjustarJanela(false);
    }

    private void AoClicarCabecalho(object sender, MouseButtonEventArgs e)
    {
        if (ilha.EstaExpandida) Recolher();
        else Expandir();
    }

    private void AoEntrar(object sender, System.Windows.Input.MouseEventArgs e)
    {
        recolhimento.Stop();
        if (!ilha.EstaExpandida) Expandir();
    }

    private void AoSair(object sender, System.Windows.Input.MouseEventArgs e)
    {
        ultimaInteracao = DateTime.UtcNow;
        if (ilha.Estado != EstadoIlha.Fixada)
        {
            recolhimento.Stop();
            recolhimento.Start();
        }
    }

    private void AoPressionarTecla(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            Recolher();
            e.Handled = true;
        }
    }

    // ===== Ocultar automaticamente, tela cheia e vários monitores =====
    // Área útil (em unidades do WPF) do monitor em que a ilha está. Sem monitor escolhido, usa o principal.
    private Rect AreaTrabalho(Forms.Screen? tela = null)
    {
        tela ??= telaAtual ?? Forms.Screen.PrimaryScreen;
        if (tela is null) return SystemParameters.WorkArea;
        var dpi = VisualTreeHelper.GetDpi(this);
        var area = tela.WorkingArea;
        return new Rect(area.Left / dpi.DpiScaleX, area.Top / dpi.DpiScaleY,
                        area.Width / dpi.DpiScaleX, area.Height / dpi.DpiScaleY);
    }

    // Estados do Windows para "há um app em tela cheia": ocupado (2), Direct3D em tela cheia (3), apresentação (4).
    private static bool EmTelaCheia() =>
        SHQueryUserNotificationState(out int estado) == 0 && (estado == 2 || estado == 3 || estado == 4);

    private bool CursorNaBorda(out Forms.Screen? tela)
    {
        tela = null;
        if (!GetCursorPos(out var ponto)) return false;
        tela = Forms.Screen.FromPoint(new Drawing.Point(ponto.X, ponto.Y));
        var dpi = VisualTreeHelper.GetDpi(this);
        double x = ponto.X / dpi.DpiScaleX, y = ponto.Y / dpi.DpiScaleY;
        var area = AreaTrabalho(tela);
        double meio = area.Left + area.Width / 2;
        double meiaLargura = Math.Max(Width, larguraRecolhida) / 2 + 80;
        return y >= area.Top - 1 && y <= area.Top + 3 && Math.Abs(x - meio) <= meiaLargura;
    }

    private void VigiarBorda()
    {
        // Consulta o Windows cerca de uma vez por segundo.
        if (++ciclosVigia % 8 == 0)
        {
            telaCheia = ocultarEmTelaCheia && EmTelaCheia();
            AtualizarMiniIndependente();
        }
        if (telaCheia && !ilha.EstaExpandida)
        {
            if (!oculta) Ocultar();
            return;
        }
        if (!autoOcultar) { if (oculta) Revelar(); return; }
        bool naBorda = CursorNaBorda(out var tela);
        if (oculta)
        {
            if (!naBorda) return;
            string? atual = (telaAtual ?? Forms.Screen.PrimaryScreen)?.DeviceName;
            if (tela is not null && tela.DeviceName != atual)
            {
                telaAtual = tela;       // a ilha muda para o monitor em que o mouse encostou
                AjustarJanela(false);
            }
            Revelar();
            return;
        }
        if (ilha.EstaExpandida || IsMouseOver || naBorda) { ultimaInteracao = DateTime.UtcNow; return; }
        if (DateTime.UtcNow - ultimaInteracao > TimeSpan.FromMilliseconds(tempoAutoOcultarMs)) Ocultar();
    }

    private void Ocultar()
    {
        oculta = true;
        Animar(TopProperty, AreaTrabalho().Top - ActualHeight - 6, 260);
        AtualizarMiniIndependente();
    }

    private void Revelar()
    {
        ultimaInteracao = DateTime.UtcNow;
        if (!oculta) return;
        oculta = false;
        Animar(TopProperty, AreaTrabalho().Top + 8, 220);
        AtualizarMiniIndependente();
    }

    private void AoAlternarTelaCheia(object sender, RoutedEventArgs e)
    {
        ocultarEmTelaCheia = !ocultarEmTelaCheia;
        if (!ocultarEmTelaCheia) { telaCheia = false; if (!autoOcultar) Revelar(); }
        AtualizarTextoTelaCheia();
        SalvarConfiguracoes();
    }

    private void AtualizarTextoTelaCheia() =>
        BotaoTelaCheia.Content = "Ocultar em tela cheia: " + (ocultarEmTelaCheia ? "ligado" : "desligado");

    private void AoAlternarAutoOcultar(object sender, RoutedEventArgs e)
    {
        autoOcultar = !autoOcultar;
        if (!autoOcultar) Revelar();
        AtualizarTextoAutoOcultar();
        SalvarConfiguracoes();
    }

    private void AtualizarTextoAutoOcultar()
    {
        BotaoAutoOcultar.Content = "Ocultar automaticamente: " + (autoOcultar ? "ligado" : "desligado");
        BotaoTempoOcultacao.IsEnabled = autoOcultar;
        BotaoTempoOcultacao.Content = $"Tempo para ocultar: {tempoAutoOcultarMs / 1000.0:0.#} s";
    }

    private void AoAlternarTempoOcultacao(object sender, RoutedEventArgs e)
    {
        tempoAutoOcultarMs = TempoOcultacao.Proximo(tempoAutoOcultarMs);
        ultimaInteracao = DateTime.UtcNow;
        AtualizarTextoAutoOcultar();
        SalvarConfiguracoes();
    }

    private void AoFixar(object sender, RoutedEventArgs e)
    {
        if (ilha.Estado == EstadoIlha.Fixada)
        {
            ilha.Desfixar();
            BotaoFixar.Content = "Fixar";
        }
        else
        {
            ilha.Fixar();
            BotaoFixar.Content = "Soltar";
            recolhimento.Stop();
        }
    }

    private void AoRecolher(object sender, RoutedEventArgs e) => Recolher();

    private void AtualizarAbas(string selecionada)
    {
        bool mudou = abaAtual != selecionada;
        abaAtual = selecionada;
        PainelMidia.Visibility = selecionada == "midia" ? Visibility.Visible : Visibility.Collapsed;
        PainelFoco.Visibility = selecionada == "foco" ? Visibility.Visible : Visibility.Collapsed;
        PainelAlertas.Visibility = selecionada == "alertas" ? Visibility.Visible : Visibility.Collapsed;
        PainelDesktop.Visibility = selecionada == "desktop" ? Visibility.Visible : Visibility.Collapsed;
        PainelSistema.Visibility = selecionada == "sistema" ? Visibility.Visible : Visibility.Collapsed;
        PainelAjustes.Visibility = selecionada == "ajustes" ? Visibility.Visible : Visibility.Collapsed;
        PainelCopias.Visibility = selecionada == "copias" ? Visibility.Visible : Visibility.Collapsed;
        AbaCopias.Background = Cor(selecionada == "copias" ? corAccent : "#25242A");
        if (selecionada == "copias") AtualizarListaCopias();
        AbaMidia.Background = Cor(selecionada == "midia" ? corAccent : "#25242A");
        AbaFoco.Background = Cor(selecionada == "foco" ? corAccent : "#25242A");
        AbaAlertas.Background = Cor(selecionada == "alertas" ? corAccent : "#25242A");
        AbaDesktop.Background = Cor(selecionada == "desktop" ? corAccent : "#25242A");
        AbaSistema.Background = Cor(selecionada == "sistema" ? corAccent : "#25242A");
        AbaAjustes.Background = Cor(selecionada == "ajustes" ? corAccent : "#25242A");
        TextoTituloPainel.Text = selecionada switch
        {
            "midia" => "Sua música. Suas escolhas.",
            "foco" => "Seu tempo, seu ritmo.",
            "alertas" => "O que merece sua atenção.",
            "desktop" => "Seu Windows com sua identidade.",
            "sistema" => "Seu Windows em um olhar.",
            "copias" => "O que você copiou, à mão.",
            _ => "Sua ilha, suas regras."
        };
        TextoSubtitulo.Text = selecionada switch
        {
            "midia" => "Controles reais para players compatíveis.",
            "desktop" => "Personalização opcional e reversível.",
            "alertas" => "Sem capturas secretas nem notificações inventadas.",
            _ => "Ander Flow Prism Island"
        };
        AtualizarEstadoSistema();
        if (mudou)
        {
            var atual = selecionada switch
            {
                "midia" => (UIElement)PainelMidia,
                "foco" => PainelFoco,
                "alertas" => PainelAlertas,
                "desktop" => PainelDesktop,
                "sistema" => PainelSistema,
                "copias" => PainelCopias,
                _ => PainelAjustes
            };
            atual.BeginAnimation(OpacityProperty, new DoubleAnimation(0.18, 1d, TimeSpan.FromMilliseconds(240))
            { EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut } });
        }
    }

    private void AoSelecionarFoco(object sender, RoutedEventArgs e) => AtualizarAbas("foco");
    private void AoSelecionarSistema(object sender, RoutedEventArgs e) => AtualizarAbas("sistema");
    private void AoSelecionarAjustes(object sender, RoutedEventArgs e) => AtualizarAbas("ajustes");
    private void AoSelecionarCopias(object sender, RoutedEventArgs e) => AtualizarAbas("copias");

    private void AoAlternarTemporizador(object sender, RoutedEventArgs e)
    {
        if (foco.Rodando) foco.Pausar(); else foco.Iniciar();
        ultimoTick = DateTime.UtcNow;
        AtualizarCronometro();
    }

    private void AoReiniciarTemporizador(object sender, RoutedEventArgs e)
    {
        foco.Reiniciar();
        AtualizarCronometro();
    }

    private void AtualizarCronometro()
    {
        TextoCronometro.Text = $"{(int)foco.Restante.TotalMinutes:00}:{foco.Restante.Seconds:00}";
        TextoEstadoFoco.Text = foco.Restante == TimeSpan.Zero ? "Sessão concluída" :
            foco.Rodando ? "Sessão em andamento" : "Pronto para começar";
        BotaoTemporizador.Content = foco.Rodando ? "Pausar" :
            foco.Restante == TimeSpan.Zero ? "Concluído" : "Iniciar";
        BotaoTemporizador.IsEnabled = foco.Restante > TimeSpan.Zero;
    }

    private void AtualizarRelogio()
    {
        var agora = DateTime.UtcNow;
        var estavaRodando = foco.Rodando;
        foco.Avancar(agora - ultimoTick);
        ultimoTick = agora;
        if (estavaRodando && foco.Restante == TimeSpan.Zero)
        {
            iconeBandeja?.ShowBalloonTip(3500, "Prism Island", "Sua sessão de foco terminou.", Forms.ToolTipIcon.Info);
            RegistrarAlerta("Foco", "Sua sessão terminou.");
        }
        AtualizarStatusCompacto();
        AtualizarCronometro();
        if (PainelSistema.Visibility == Visibility.Visible) AtualizarEstadoSistema();
    }

    private void AtualizarEstadoSistema()
    {
        var tela = Forms.Screen.PrimaryScreen;
        TextoMonitor.Text = tela is null ? "Monitor não disponível" :
            $"Tela principal: {tela.Bounds.Width} × {tela.Bounds.Height}";
        using var processo = Process.GetCurrentProcess();
        TextoMemoria.Text = $"Memória deste aplicativo: {processo.WorkingSet64 / 1024d / 1024d:N1} MB";
        var ativo = TimeSpan.FromMilliseconds(Environment.TickCount64);
        TextoUptime.Text = $"Windows ligado há {(int)ativo.TotalHours}h {ativo.Minutes}min";
    }

    private static System.Windows.Media.Brush Cor(string valor) => (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString(valor)!;

    private void AplicarTema()
    {
        bool claro = tema == "claro";
        bool mono = tema == "mono";
        var gradiente = new LinearGradientBrush
        {
            StartPoint = new Point(0, 0),
            EndPoint = new Point(1, 1)
        };
        gradiente.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString(
            claro ? "#EFE8E5" : mono ? "#22232A" : tema == "preto" ? "#14141A" : "#1B182A"), 0));
        gradiente.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString(
            claro ? "#D9CED4" : mono ? "#0F1015" : "#0A0A12"), 1));
        BordaPrincipal.Background = gradiente;
        BordaPrincipal.BorderBrush = Cor(claro ? "#BB9F9B" : mono ? "#65616B" : "#755369");
        var textoCabecalho = Cor(claro ? "#211C29" : "#F7F4FA");
        TituloPrincipal.Foreground = textoCabecalho;
        TextoTituloPainel.Foreground = Cor("#FCF9F5");
        TextoCronometro.Foreground = Cor("#F7F4FA");
        TextoMonitor.Foreground = Cor("#F7F4FA");
        IndicadorAbertura.Foreground = Cor(claro ? "#9E5039" : "#F0A16B");
        PainelFoco.Background = PainelSistema.Background = PainelAjustes.Background =
            Cor("#1C1A29");
        BotaoTema.Content = "Tema: " + (claro ? "Pérola" : mono ? "Grafite" : tema == "preto" ? "Ônix" : "Prism Flow");
        Opacity = EstiloStudio.Opacity(opacidadeIlha);
        AplicarVisualPersonalizado();
    }

    private void AoAlternarTema(object sender, RoutedEventArgs e)
    {
        tema = tema switch { "prism" => "claro", "claro" => "mono", "mono" => "preto", _ => "prism" };
        AplicarTema();
        SalvarConfiguracoes();
    }

    private void AoAlternarAutoInicio(object sender, RoutedEventArgs e)
    {
        try
        {
            var caminho = Environment.ProcessPath ?? string.Empty;
            if (!caminho.EndsWith("AnderFlowPrismIsland.exe", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Instale o executável antes de habilitar o início automático.");
            using var chave = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            if (chave is null) throw new InvalidOperationException("Registro indisponível.");
            if (iniciarComWindows) chave.DeleteValue("AnderFlowPrismIsland", false);
            else chave.SetValue("AnderFlowPrismIsland", "\"" + caminho + "\"");
            iniciarComWindows = !iniciarComWindows;
            BotaoAutoInicio.Content = "Iniciar com Windows: " + (iniciarComWindows ? "ligado" : "desligado");
            SalvarConfiguracoes();
        }
        catch (Exception erro)
        {
            TextoRodape.Text = "Não foi possível alterar: " + erro.Message;
        }
    }

    private void SalvarConfiguracoes()
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(caminhoConfiguracoes)!);
            File.WriteAllText(caminhoConfiguracoes,
                JsonSerializer.Serialize(new Preferencias(tema, iniciarComWindows, dockAtivo, papelAnterior,
                    autoOcultar, ocultarEmTelaCheia, tempoAutoOcultarMs,
                    opacidadeIlha, opacidadeDock, posicaoDock, corAccent, larguraBase, larguraStudio,
                    intensidadeVisual, velocidadeVisual, visualMiniSempreVisivel, visualReativoLigado)));
        }
        catch (Exception erro) { TextoRodape.Text = "Falha ao salvar: " + erro.Message; }
    }

    private void CarregarConfiguracoes()
    {
        try
        {
            if (File.Exists(caminhoConfiguracoes))
            {
                var preferencias = JsonSerializer.Deserialize<Preferencias>(File.ReadAllText(caminhoConfiguracoes));
                if (preferencias is not null)
                {
                    tema = new[] { "prism", "preto", "claro", "mono" }.Contains(preferencias.Tema)
                        ? preferencias.Tema : "prism";
                    dockAtivo = preferencias.DockAtivo;
                    papelAnterior = preferencias.PapelAnterior;
                    autoOcultar = preferencias.AutoOcultar;
                    ocultarEmTelaCheia = preferencias.OcultarEmTelaCheia;
                    tempoAutoOcultarMs = TempoOcultacao.Normalizar(preferencias.TempoOcultacaoMs);
                    opacidadeIlha = EstiloStudio.Opacity(preferencias.OpacidadeIlha);
                    opacidadeDock = EstiloStudio.Opacity(preferencias.OpacidadeDock);
                    posicaoDock = EstiloStudio.PosicaoDock(preferencias.PosicaoDock);
                    corAccent = PrismVisualPersonalizacao.Cor(preferencias.CorAccent);
                    larguraBase = PrismVisualPersonalizacao.TamanhoEntalhe(preferencias.TamanhoEntalhe);
                    larguraStudio = PrismVisualPersonalizacao.LarguraStudio(preferencias.TamanhoStudio);
                    intensidadeVisual = PrismVisualPersonalizacao.Intensidade(preferencias.IntensidadeVisual);
                    velocidadeVisual = PrismVisualPersonalizacao.Velocidade(preferencias.VelocidadeVisual);
                    visualMiniSempreVisivel = preferencias.MiniSempreVisivel;
                    visualReativoLigado = preferencias.VisualReativoLigado;
                }
            }
            using var chave = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            iniciarComWindows = chave?.GetValue("AnderFlowPrismIsland") is string;
            AtualizarTextoAutoOcultar();
            AtualizarTextoTelaCheia();
            BotaoAutoInicio.Content = "Iniciar com Windows: " + (iniciarComWindows ? "ligado" : "desligado");
            TextoRodape.Text = "Ander Flow • v0.5.0-dev" + (atalhoDisponivel ? "" : " • Atalho em uso");
        }
        catch { tema = "prism"; iniciarComWindows = false; }
    }

    private record Preferencias(string Tema, bool IniciarComWindows, bool DockAtivo = false, string? PapelAnterior = null,
        bool AutoOcultar = true, bool OcultarEmTelaCheia = true, int TempoOcultacaoMs = TempoOcultacao.PadraoMs,
        double OpacidadeIlha = EstiloStudio.OpacidadePadrao, double OpacidadeDock = 0.92, string PosicaoDock = "inferior",
        string CorAccent = PrismVisualPersonalizacao.CorPadrao, double TamanhoEntalhe = 282d,
        double TamanhoStudio = 752d, double IntensidadeVisual = 1d, double VelocidadeVisual = 1d,
        bool MiniSempreVisivel = true, bool VisualReativoLigado = true);

    private void CriarBandeja()
    {
        var menu = new Forms.ContextMenuStrip();
        menu.Items.Add("Mostrar Prism Island", null, (_, _) =>
            Dispatcher.Invoke(() => { Show(); Expandir(); Activate(); }));
        menu.Items.Add("Recolher", null, (_, _) => Dispatcher.Invoke(Recolher));
        menu.Items.Add(new Forms.ToolStripSeparator());
        menu.Items.Add("Sair", null, (_, _) => Dispatcher.Invoke(() =>
        {
            encerrando = true;
            Close();
        }));
        iconeBandeja = new Forms.NotifyIcon
        {
            Text = "Ander Flow Prism Island",
            Icon = DesenharIcone(),
            Visible = true,
            ContextMenuStrip = menu
        };
        iconeBandeja.DoubleClick += (_, _) => Dispatcher.Invoke(() => { Show(); Expandir(); Activate(); });
    }

    private static Drawing.Icon DesenharIcone()
    {
        using var bitmap = new Drawing.Bitmap(32, 32);
        using var grafico = Drawing.Graphics.FromImage(bitmap);
        grafico.SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias;
        using var fundo = new Drawing.SolidBrush(Drawing.Color.FromArgb(10, 10, 15));
        using var laranja = new Drawing.SolidBrush(Drawing.Color.FromArgb(232, 98, 42));
        grafico.FillEllipse(fundo, 0, 0, 31, 31);
        grafico.FillEllipse(laranja, 9, 9, 14, 14);
        var handle = bitmap.GetHicon();
        using var temporario = Drawing.Icon.FromHandle(handle);
        return (Drawing.Icon)temporario.Clone();
    }

    private void AoFechar(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        if (encerrando == false) encerrando = true;
        recolhimento.Stop();
        relogio.Stop();
        vigia.Stop();
        PararIntegracoes();
        PararStudio();
        PararCopias();
        if (atalhoDisponivel && origemMensagens is not null)
            UnregisterHotKey(origemMensagens.Handle, HotkeyId);
        if (origemMensagens is not null) origemMensagens.RemoveHook(ReceberMensagem);
        if (iconeBandeja is not null)
        {
            iconeBandeja.Visible = false;
            iconeBandeja.Dispose();
        }
    }
}