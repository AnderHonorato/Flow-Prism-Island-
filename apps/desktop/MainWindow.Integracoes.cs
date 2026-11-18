using AnderFlowPrismIsland.Logic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Windows.UI.Notifications;
using Windows.UI.Notifications.Management;

namespace AnderFlowPrismIsland;

public partial class MainWindow
{
    private readonly ServicoMidiaWindows midiaWindows = new();
    private readonly VolumeSistema volumeWindows = new();
    private readonly DispatcherTimer atualizacaoMidia = new() { Interval = TimeSpan.FromSeconds(3) };
    private readonly List<string> alertasLocais = new();
    private MidiaVisivel midiaAtual = MidiaVisivel.Vazia();
    private bool consultandoMidia;
    private bool atualizandoVolume;
    private bool dockAtivo;
    private DockWindow? janelaDock;
    private string? papelAnterior;

    private void IniciarIntegracoes()
    {
        atualizacaoMidia.Tick += async (_, _) => await AtualizarMidiaAsync();
        atualizacaoMidia.Start();
        AtualizarVolume();
        AtualizarStatusCompacto();
        if (dockAtivo) MostrarDock();
        _ = AtualizarMidiaAsync();
    }

    private void PararIntegracoes()
    {
        atualizacaoMidia.Stop();
        if (janelaDock is not null) { janelaDock.Close(); janelaDock = null; }
    }

    private void AtualizarStatusCompacto()
    {
        TituloPrincipal.Text = midiaAtual.TemSessao && midiaAtual.Tocando
            ? midiaAtual.Titulo : "PRISM ISLAND";
        StatusCompacto.Text = midiaAtual.TemSessao
            ? (midiaAtual.Tocando ? "Reproduzindo • " : "Pausada • ") + midiaAtual.Aplicativo
            : DateTime.Now.ToString("HH:mm") + (foco.Rodando ? " • Foco ativo" : " • Ander Flow");
    }

    private async Task AtualizarMidiaAsync()
    {
        if (consultandoMidia) return;
        consultandoMidia = true;
        try
        {
            var anterior = midiaAtual;
            midiaAtual = await midiaWindows.ConsultarAsync();
            if (!IsLoaded) return;
            TextoMusica.Text = midiaAtual.Titulo;
            TextoArtista.Text = midiaAtual.TemSessao
                ? (string.IsNullOrWhiteSpace(midiaAtual.Artista) ? "Artista não informado" : midiaAtual.Artista)
                : "Abra um player com suporte à mídia do Windows";
            TextoOrigem.Text = midiaAtual.Aplicativo;
            BotaoPlay.IsEnabled = midiaAtual.PodePausar;
            BotaoAnterior.IsEnabled = midiaAtual.PodeVoltar;
            BotaoProximo.IsEnabled = midiaAtual.PodeAvancar;
            BotaoPlay.Content = midiaAtual.Tocando ? "Pausar" : "Reproduzir";
            TextoRetornoMidia.Text = midiaAtual.TemSessao
                ? "Controlando a sessão real do Windows" : "Nenhum player compatível detectado";
            var duracao = midiaAtual.Duracao.TotalSeconds;
            ProgressoFaixa.Value = duracao > 0
                ? Math.Clamp(midiaAtual.Posicao.TotalSeconds / duracao * 100d, 0d, 100d)
                : 0;
            TextoPosicao.Text = duracao > 0 ? FormatarTempo(midiaAtual.Posicao) : "--:--";
            TextoDuracao.Text = duracao > 0 ? FormatarTempo(midiaAtual.Duracao) : "--:--";
            if (anterior.Tocando != midiaAtual.Tocando) AnimarBarras(midiaAtual.Tocando);
            AtualizarStatusCompacto();
            AtualizarVolume();
        }
        catch (Exception erro)
        {
            TextoRetornoMidia.Text = "Mídia indisponível: " + erro.GetType().Name;
        }
        finally { consultandoMidia = false; }
    }

    private static string FormatarTempo(TimeSpan tempo)
    {
        if (tempo < TimeSpan.Zero) tempo = TimeSpan.Zero;
        return tempo.TotalHours >= 1 ? tempo.ToString(@"h\:mm\:ss") : tempo.ToString(@"mm\:ss");
    }

    private void AnimarBarras(bool tocando)
    {
        var barras = new[] { BarraMusica1, BarraMusica2, BarraMusica3 };
        var tempos = new[] { 370, 470, 560 };
        for (int i = 0; i < barras.Length; i++)
        {
            if (!tocando)
            {
                barras[i].BeginAnimation(HeightProperty, null);
                continue;
            }
            var animacao = new DoubleAnimation(4d, 18d, TimeSpan.FromMilliseconds(tempos[i]))
            { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
            barras[i].BeginAnimation(HeightProperty, animacao);
        }
    }

    private void AtualizarVolume()
    {
        atualizandoVolume = true;
        try
        {
            var nivel = volumeWindows.Ler();
            SliderVolume.IsEnabled = nivel.HasValue;
            BotaoMudo.IsEnabled = nivel.HasValue;
            if (nivel is int volume)
            {
                SliderVolume.Value = volume;
                TextoVolume.Text = volume + "%";
            }
            else TextoVolume.Text = "--";
            BotaoMudo.Content = volumeWindows.EstaMudo() == true ? "Mudo" : "Som";
        }
        finally { atualizandoVolume = false; }
    }

    private async void AoMidiaPlayPause(object sender, RoutedEventArgs e)
    {
        BotaoPlay.IsEnabled = false;
        var sucesso = await midiaWindows.AlternarAsync();
        if (!sucesso) TextoRetornoMidia.Text = "Este player não aceitou o comando.";
        await AtualizarMidiaAsync();
    }

    private async void AoMidiaAnterior(object sender, RoutedEventArgs e)
    {
        if (!await midiaWindows.VoltarAsync()) TextoRetornoMidia.Text = "O player não permite voltar.";
        await AtualizarMidiaAsync();
    }

    private async void AoMidiaProxima(object sender, RoutedEventArgs e)
    {
        if (!await midiaWindows.AvancarAsync()) TextoRetornoMidia.Text = "O player não permite avançar.";
        await AtualizarMidiaAsync();
    }

    private void AoAlterarVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (!IsLoaded || atualizandoVolume) return;
        var percentual = (int)Math.Round(e.NewValue);
        var sucesso = volumeWindows.Ajustar(percentual);
        TextoVolume.Text = sucesso ? percentual + "%" : "--";
    }

    private void AoAlternarMudo(object sender, RoutedEventArgs e)
    {
        var mudo = volumeWindows.EstaMudo();
        if (mudo.HasValue) volumeWindows.DefinirMudo(!mudo.Value);
        AtualizarVolume();
    }

    private void AoSelecionarMidia(object sender, RoutedEventArgs e)
    {
        AtualizarAbas("midia");
        _ = AtualizarMidiaAsync();
    }

    private void AoSelecionarAlertas(object sender, RoutedEventArgs e)
    {
        AtualizarAbas("alertas");
        AtualizarAlertas();
    }

    private void RegistrarAlerta(string origem, string mensagem)
    {
        alertasLocais.Insert(0, DateTime.Now.ToString("HH:mm") + " · " + origem + " · " + mensagem);
        if (alertasLocais.Count > 20) alertasLocais.RemoveAt(alertasLocais.Count - 1);
        if (IsLoaded) AtualizarAlertas();
    }

    private void AtualizarAlertas()
    {
        ListaAlertas.Children.Clear();
        foreach (var alerta in alertasLocais)
            ListaAlertas.Children.Add(new TextBlock
            {
                Text = alerta, Foreground = Cor("#F5F5F0"),
                TextWrapping = TextWrapping.Wrap, FontSize = 11,
                Margin = new Thickness(3, 5, 3, 5)
            });
        if (alertasLocais.Count == 0)
            ListaAlertas.Children.Add(new TextBlock { Text = "Nenhum alerta registrado pelo Prism Island",
                Foreground = Cor("#A6A0A1"), FontSize = 11 });
    }

    private void AoLimparAlertas(object sender, RoutedEventArgs e)
    {
        alertasLocais.Clear();
        AtualizarAlertas();
    }

    private async void AoSolicitarNotificacoes(object sender, RoutedEventArgs e)
    {
        TextoAcessoAlertas.Text = "Solicitando permissão ao Windows…";
        try
        {
            var listener = UserNotificationListener.Current;
            var acesso = await listener.RequestAccessAsync();
            if (acesso != UserNotificationListenerAccessStatus.Allowed)
            {
                TextoAcessoAlertas.Text = "O Windows não concedeu acesso. O aplicativo precisa de identidade de pacote/capability apropriada.";
                return;
            }
            var notificacoes = await listener.GetNotificationsAsync(NotificationKinds.Toast);
            int adicionadas = 0;
            foreach (var notificacao in notificacoes.OrderByDescending(n => n.CreationTime).Take(12))
            {
                var origem = notificacao.AppInfo?.DisplayInfo?.DisplayName ?? "Aplicativo";
                var binding = notificacao.Notification?.Visual?.GetBinding(KnownNotificationBindings.ToastGeneric);
                var mensagem = binding is null ? "Notificação disponível" :
                    string.Join(" • ", binding.GetTextElements().Select(t => t.Text).Where(t => !string.IsNullOrWhiteSpace(t)));
                RegistrarAlerta(origem, mensagem);
                adicionadas++;
            }
            TextoAcessoAlertas.Text = adicionadas + " notificação(ões) lidas com autorização do Windows. Nenhum conteúdo é enviado à nuvem.";
        }
        catch (Exception erro)
        {
            TextoAcessoAlertas.Text = "O Windows não disponibilizou o listener (" + erro.GetType().Name +
                "). A versão .exe ainda não possui identidade MSIX.";
        }
    }

    private void AoSelecionarDesktop(object sender, RoutedEventArgs e) => AtualizarAbas("desktop");

    private void MostrarDock()
    {
        if (janelaDock is not null) return;
        janelaDock = new DockWindow(() => {
            Dispatcher.Invoke(() => { Show(); Expandir(); AtualizarAbas("midia"); Activate(); });
        });
        janelaDock.Closed += (_, _) => { janelaDock = null; };
        janelaDock.Show();
        BotaoDock.Content = "Desativar Dock Flow";
    }

    private void AoAlternarDock(object sender, RoutedEventArgs e)
    {
        if (janelaDock is not null)
        {
            janelaDock.Close(); janelaDock = null; dockAtivo = false;
            BotaoDock.Content = "Ativar Dock Flow";
        }
        else { dockAtivo = true; MostrarDock(); }
        SalvarConfiguracoes();
    }

    [DllImport("user32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SystemParametersInfo(uint acao, uint parametro, string? valor, uint flags);

    private void AoEscolherWallpaper(object sender, RoutedEventArgs e)
    {
        var janela = new Microsoft.Win32.OpenFileDialog
        {
            Title = "Escolha o papel de parede do Windows",
            Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp",
            CheckFileExists = true
        };
        if (janela.ShowDialog(this) != true) return;
        try
        {
            if (papelAnterior is null)
            {
                using var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop");
                papelAnterior = key?.GetValue("WallPaper") as string;
            }
            if (!SystemParametersInfo(20u, 0u, janela.FileName, 3u))
                throw new InvalidOperationException("O Windows recusou o papel de parede.");
            TextoDesktop.Text = "Papel de parede aplicado. É possível restaurar a imagem anterior.";
            SalvarConfiguracoes();
        }
        catch (Exception erro) { TextoDesktop.Text = erro.Message; }
    }

    private void AoRestaurarWallpaper(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(papelAnterior) || !File.Exists(papelAnterior))
        {
            TextoDesktop.Text = "Não há arquivo anterior acessível para restaurar.";
            return;
        }
        if (SystemParametersInfo(20u, 0u, papelAnterior, 3u))
        {
            papelAnterior = null;
            SalvarConfiguracoes();
            TextoDesktop.Text = "Papel de parede anterior restaurado.";
        }
        else TextoDesktop.Text = "O Windows não permitiu restaurar.";
    }

    private void AoAbrirBarraWindows(object sender, RoutedEventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo("ms-settings:taskbar") { UseShellExecute = true });
            TextoDesktop.Text = "Configurações da barra original abertas. O Prism Island não altera o Explorer.";
        }
        catch (Exception erro) { TextoDesktop.Text = erro.Message; }
    }
}
