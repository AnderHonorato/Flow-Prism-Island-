using AnderFlowPrismIsland.Logic;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace AnderFlowPrismIsland;

/// <summary>
/// Aparência, visualizador e modo mini. Todas as personalizações são do próprio aplicativo.
/// </summary>
public partial class MainWindow
{
    private string corAccent = PrismVisualPersonalizacao.CorPadrao;
    private double larguraBase = 282d;
    private double larguraStudio = 752d;
    private double intensidadeVisual = 1d;
    private double velocidadeVisual = 1d;
    private bool visualMiniSempreVisivel = true;
    private bool visualReativoLigado = true;
    private MiniVisualWindow? janelaMini;
    private DateTime proximaTentativaAudio = DateTime.MinValue;
    private string abaAtual = "midia";
    private bool configurandoCor;

    private void SincronizarCapturaAudio()
    {
        bool tocando = midiaAtual.TemSessao && midiaAtual.Tocando;
        EspectroMini.Ativo = tocando;
        EspectroGrande.Ativo = tocando;

        if (!visualReativoLigado || !tocando)
        {
            PararCapturaAudio();
            BotaoAudioReativo.Content = visualReativoLigado ? "Reatividade com música: ativada" : "Ativar reatividade ao áudio";
            return;
        }

        if (capturaReativa is null && DateTime.UtcNow >= proximaTentativaAudio)
        {
            try
            {
                var nova = new CapturaAudioReativo();
                nova.IntensidadeAtualizada += AoIntensidadeAudio;
                nova.Iniciar();
                capturaReativa = nova;
                audioReativoAtivo = true;
                AnimarBarras(false); // As barras passam a acompanhar a amplitude medida, não uma animação simulada.
                TextoRetornoMidia.Text = "Espectro reagindo à saída de áudio do PC · processamento local";
            }
            catch (Exception erro)
            {
                capturaReativa?.Dispose();
                capturaReativa = null;
                audioReativoAtivo = false;
                proximaTentativaAudio = DateTime.UtcNow.AddSeconds(20);
                TextoRetornoMidia.Text = "Espectro sem captura: " + erro.GetType().Name;
            }
        }
        BotaoAudioReativo.Content = audioReativoAtivo ? "Desativar visualização reativa" : "Tentar ativar reatividade";
    }

    private void PararCapturaAudio()
    {
        if (capturaReativa is null) return;
        var anterior = capturaReativa;
        capturaReativa = null;
        audioReativoAtivo = false;
        anterior.IntensidadeAtualizada -= AoIntensidadeAudio;
        anterior.Dispose();
        EspectroMini.Nivel = 0;
        EspectroGrande.Nivel = 0;
        if (janelaMini is not null) janelaMini.Espectro.Nivel = 0;
        AnimarBarras(midiaAtual.Tocando);
    }

    private void AoIntensidadeAudio(double nivel)
    {
        if (Dispatcher.HasShutdownStarted || Dispatcher.HasShutdownFinished) return;
        Dispatcher.BeginInvoke(new Action(() =>
        {
            if (!audioReativoAtivo || !IsLoaded) return;
            EspectroMini.Nivel = nivel;
            EspectroGrande.Nivel = nivel;
            if (janelaMini is not null) janelaMini.Espectro.Nivel = nivel;

            double altura = 4 + nivel * 18 * intensidadeVisual;
            BarraMusica1.Height = altura * .72;
            BarraMusica2.Height = altura;
            BarraMusica3.Height = altura * .82;
        }), DispatcherPriority.Render);
    }

    private void AtualizarMiniIndependente()
    {
        bool apresentar = PrismVisualPersonalizacao.MiniIndependente(
            visualMiniSempreVisivel, midiaAtual.TemSessao && midiaAtual.Tocando, oculta, telaCheia);
        if (!apresentar)
        {
            if (janelaMini is not null)
            {
                janelaMini.Close();
                janelaMini = null;
            }
            return;
        }
        if (janelaMini is null)
        {
            janelaMini = new MiniVisualWindow(() => Dispatcher.Invoke(() =>
            {
                Revelar();
                Expandir();
                AtualizarAbas("midia");
                Activate();
            }));
            janelaMini.Espectro.Ativo = true;
            AtualizarAspectoEspectro(janelaMini.Espectro);
            janelaMini.Show();
        }
    }

    private void AoAlternarModoMini(object sender, SelectionChangedEventArgs e)
    {
        if (!IsLoaded || aplicandoPreferencias) return;
        visualMiniSempreVisivel = ComboModoMini.SelectedIndex != 1;
        AtualizarMiniIndependente();
        AgendarSalvarStudio();
    }

    private void AtualizarAspectoEspectro(Controls.EspectroPrism espectro)
    {
        espectro.CorDestaque = corAccent;
        espectro.Intensidade = intensidadeVisual;
        espectro.Velocidade = velocidadeVisual;
    }

    private void AplicarVisualPersonalizado()
    {
        corAccent = PrismVisualPersonalizacao.Cor(corAccent);
        larguraBase = PrismVisualPersonalizacao.TamanhoEntalhe(larguraBase);
        larguraStudio = PrismVisualPersonalizacao.LarguraStudio(larguraStudio);
        intensidadeVisual = PrismVisualPersonalizacao.Intensidade(intensidadeVisual);
        velocidadeVisual = PrismVisualPersonalizacao.Velocidade(velocidadeVisual);
        var cor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(corAccent);

        try
        {
            if (TryFindResource("PrismLaranja") is SolidColorBrush pincel && !pincel.IsFrozen)
                pincel.Color = cor;
        }
        catch { /* O aplicativo ainda aplica a cor nos elementos próprios. */ }

        IndicadorAbertura.Foreground = new SolidColorBrush(cor);
        BotaoPlay.Background = new SolidColorBrush(cor);
        BordaPrincipal.BorderBrush = new SolidColorBrush(
            System.Windows.Media.Color.FromArgb(212, cor.R, cor.G, cor.B));
        AtualizarAspectoEspectro(EspectroMini);
        AtualizarAspectoEspectro(EspectroGrande);
        if (janelaMini is not null) AtualizarAspectoEspectro(janelaMini.Espectro);
        if (IsLoaded) AtualizarAbas(abaAtual);
        if (IsLoaded) AjustarJanela(ilha.EstaExpandida);
    }

    private void AoEscolherCorDestaque(object sender, RoutedEventArgs e)
    {
        if (sender is not Button botao || botao.Tag is not string cor) return;
        corAccent = PrismVisualPersonalizacao.Cor(cor);
        CampoCor.Text = corAccent;
        AplicarVisualPersonalizado();
        AgendarSalvarStudio();
    }

    private void AoAplicarCorHex(object sender, RoutedEventArgs e)
    {
        string texto = CampoCor.Text.Trim();
        if (!Regex.IsMatch(texto, "^#[0-9A-Fa-f]{6}$"))
        {
            TextoRodape.Text = "Cor inválida: use #RRGGBB, por exemplo #A078F5";
            return;
        }
        corAccent = PrismVisualPersonalizacao.Cor(texto);
        AplicarVisualPersonalizado();
        AgendarSalvarStudio();
    }

    private void AoMudarTamanhoEntalhe(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (!IsLoaded || aplicandoPreferencias) return;
        larguraBase = PrismVisualPersonalizacao.TamanhoEntalhe(e.NewValue);
        TextoTamanhoEntalhe.Text = Math.Round(larguraBase) + " px";
        AtualizarStatusCompacto();
        AgendarSalvarStudio();
    }

    private void AoMudarTamanhoStudio(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (!IsLoaded || aplicandoPreferencias) return;
        larguraStudio = PrismVisualPersonalizacao.LarguraStudio(e.NewValue);
        TextoTamanhoStudio.Text = Math.Round(larguraStudio) + " px";
        if (ilha.EstaExpandida) AjustarJanela(true);
        AgendarSalvarStudio();
    }

    private void AoMudarIntensidade(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (!IsLoaded || aplicandoPreferencias) return;
        intensidadeVisual = PrismVisualPersonalizacao.Intensidade(e.NewValue / 100d);
        TextoIntensidade.Text = Math.Round(intensidadeVisual * 100) + "%";
        AtualizarAspectoEspectro(EspectroMini);
        AtualizarAspectoEspectro(EspectroGrande);
        if (janelaMini is not null) AtualizarAspectoEspectro(janelaMini.Espectro);
        AgendarSalvarStudio();
    }

    private void AoMudarVelocidade(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (!IsLoaded || aplicandoPreferencias) return;
        velocidadeVisual = PrismVisualPersonalizacao.Velocidade(e.NewValue / 100d);
        TextoVelocidade.Text = Math.Round(velocidadeVisual * 100) + "%";
        AtualizarAspectoEspectro(EspectroMini);
        AtualizarAspectoEspectro(EspectroGrande);
        if (janelaMini is not null) AtualizarAspectoEspectro(janelaMini.Espectro);
        AgendarSalvarStudio();
    }
}
