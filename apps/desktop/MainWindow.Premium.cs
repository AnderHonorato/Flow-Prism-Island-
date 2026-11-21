using AnderFlowPrismIsland.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace AnderFlowPrismIsland;

public partial class MainWindow
{
    private double opacidadeIlha = EstiloStudio.OpacidadePadrao;
    private double opacidadeDock = 0.92;
    private string posicaoDock = "inferior";
    private bool aplicandoPreferencias;
    private bool atualizandoListaPlayers;
    private bool buscandoFaixa;
    private string? capaAnteriorChave;
    private string? listaAnteriorPlayers;
    private readonly MetricasSistema metricasPremium = new();
    private readonly DispatcherTimer timerMetricas = new() { Interval = TimeSpan.FromSeconds(2) };
    private readonly DispatcherTimer timerSalvar = new() { Interval = TimeSpan.FromMilliseconds(650) };

    private void AplicarPreferenciasStudio()
    {
        aplicandoPreferencias = true;
        try
        {
            opacidadeIlha = EstiloStudio.Opacity(opacidadeIlha);
            opacidadeDock = EstiloStudio.Opacity(opacidadeDock);
            posicaoDock = EstiloStudio.PosicaoDock(posicaoDock);
            Opacity = opacidadeIlha;
            SliderIlhaOpacidade.Value = opacidadeIlha * 100;
            SliderDockOpacidade.Value = opacidadeDock * 100;
            TextoOpacidade.Text = Math.Round(opacidadeIlha * 100) + "%";
            TextoDockOpacidade.Text = Math.Round(opacidadeDock * 100) + "%";
            ComboPosicaoDock.SelectedIndex = posicaoDock == "superior" ? 1 : 0;
            janelaDock?.AtualizarPreferencias(opacidadeDock, posicaoDock);
        }
        finally { aplicandoPreferencias = false; }

        timerSalvar.Tick += (_, _) =>
        {
            timerSalvar.Stop();
            SalvarConfiguracoes();
        };
        timerMetricas.Tick += (_, _) => AtualizarMetricasPremium();
        timerMetricas.Start();
        AtualizarMetricasPremium();
    }

    private void PararStudio()
    {
        timerMetricas.Stop();
        timerSalvar.Stop();
    }

    private void AgendarSalvarStudio()
    {
        timerSalvar.Stop();
        timerSalvar.Start();
    }

    private void AoMudarOpacidadeIlha(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (!IsLoaded || aplicandoPreferencias) return;
        opacidadeIlha = EstiloStudio.Opacity(e.NewValue / 100d);
        Opacity = opacidadeIlha;
        TextoOpacidade.Text = Math.Round(opacidadeIlha * 100) + "%";
        AgendarSalvarStudio();
    }

    private void AoMudarOpacidadeDock(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (!IsLoaded || aplicandoPreferencias) return;
        opacidadeDock = EstiloStudio.Opacity(e.NewValue / 100d);
        TextoDockOpacidade.Text = Math.Round(opacidadeDock * 100) + "%";
        janelaDock?.AtualizarPreferencias(opacidadeDock, posicaoDock);
        AgendarSalvarStudio();
    }

    private void AoMudarPosicaoDock(object sender, SelectionChangedEventArgs e)
    {
        if (!IsLoaded || aplicandoPreferencias) return;
        var item = ComboPosicaoDock.SelectedItem as ComboBoxItem;
        posicaoDock = EstiloStudio.PosicaoDock(item?.Tag?.ToString());
        janelaDock?.AtualizarPreferencias(opacidadeDock, posicaoDock);
        AgendarSalvarStudio();
    }

    private void AoRestaurarStudio(object sender, RoutedEventArgs e)
    {
        tema = "prism";
        opacidadeIlha = EstiloStudio.OpacidadePadrao;
        opacidadeDock = 0.92;
        posicaoDock = "inferior";
        AplicarTema();
        aplicandoPreferencias = true;
        try
        {
            SliderIlhaOpacidade.Value = opacidadeIlha * 100;
            SliderDockOpacidade.Value = opacidadeDock * 100;
            ComboPosicaoDock.SelectedIndex = 0;
        }
        finally { aplicandoPreferencias = false; }
        Opacity = opacidadeIlha;
        TextoOpacidade.Text = "96%";
        TextoDockOpacidade.Text = "92%";
        janelaDock?.AtualizarPreferencias(opacidadeDock, posicaoDock);
        SalvarConfiguracoes();
        TextoRodape.Text = "Visual do Prism restaurado · suas opções do Windows não foram alteradas";
    }

    private void AoFoco15(object sender, RoutedEventArgs e) => AjustarSessaoFoco(15);
    private void AoFoco25(object sender, RoutedEventArgs e) => AjustarSessaoFoco(25);
    private void AoFoco50(object sender, RoutedEventArgs e) => AjustarSessaoFoco(50);

    private void AjustarSessaoFoco(int minutos)
    {
        foco.Reiniciar(TimeSpan.FromMinutes(minutos));
        AtualizarCronometro();
        TextoEstadoFoco.Text = "Sessão personalizada de " + minutos + " minutos";
        AtualizarStatusCompacto();
    }

    private void AtualizarMetricasPremium()
    {
        if (!IsLoaded) return;
        var dados = metricasPremium.Ler();
        TextoCpuTotal.Text = MetricasSistema.FormatarPercentual(dados.Cpu);
        TextoRamTotal.Text = MetricasSistema.FormatarPercentual(dados.Ram);
        TextoDiscoTotal.Text = MetricasSistema.FormatarPercentual(dados.Disco);
        TextoRedeAtiva.Text = dados.Rede;
        BarraCpuTotal.Value = dados.Cpu ?? 0;
        BarraRamTotal.Value = dados.Ram ?? 0;
        BarraDiscoTotal.Value = dados.Disco ?? 0;
        TextoCpuTotal.ToolTip = "Uso do processador — CPU total atual";
        TextoRamTotal.ToolTip = dados.RamTexto;
        TextoDiscoTotal.ToolTip = dados.DiscoTexto;
    }

    private void AtualizarListaPlayers()
    {
        var disponiveis = midiaWindows.ListarPlayers();
        var chave = string.Join("|", disponiveis.Select(p => p.Id));
        if (string.Equals(chave, listaAnteriorPlayers, StringComparison.Ordinal)) return;
        listaAnteriorPlayers = chave;
        atualizandoListaPlayers = true;
        try
        {
            var lista = new List<SessaoPlayer> { new("", "Automático · Windows") };
            lista.AddRange(disponiveis);
            ListaPlayers.ItemsSource = lista;
            ListaPlayers.DisplayMemberPath = nameof(SessaoPlayer.Nome);
            ListaPlayers.SelectedValuePath = nameof(SessaoPlayer.Id);
            ListaPlayers.SelectedValue = midiaWindows.PlayerEscolhido ?? "";
            if (ListaPlayers.SelectedIndex < 0) ListaPlayers.SelectedIndex = 0;
        }
        finally { atualizandoListaPlayers = false; }
    }

    private void AoTrocarPlayer(object sender, SelectionChangedEventArgs e)
    {
        if (!IsLoaded || atualizandoListaPlayers) return;
        var selecionado = ListaPlayers.SelectedValue as string;
        midiaWindows.EscolherPlayer(selecionado);
        capaAnteriorChave = null;
        _ = AtualizarMidiaAsync();
    }

    private void AtualizarCapaMusica()
    {
        string chave = (midiaAtual.IdSessao ?? "") + "|" + midiaAtual.Titulo + "|" + midiaAtual.Artista;
        if (chave == capaAnteriorChave) return;
        capaAnteriorChave = chave;
        if (midiaAtual.CapaBytes is not { Length: > 0 } bytes)
        {
            ImagemCapa.Source = null;
            ImagemCapa.Visibility = Visibility.Collapsed;
            CapaPlaceholder.Visibility = Visibility.Visible;
            return;
        }

        try
        {
            using var stream = new MemoryStream(bytes, writable: false);
            var imagem = new BitmapImage();
            imagem.BeginInit();
            imagem.CacheOption = BitmapCacheOption.OnLoad;
            imagem.StreamSource = stream;
            imagem.EndInit();
            imagem.Freeze();
            ImagemCapa.Source = imagem;
            ImagemCapa.Visibility = Visibility.Visible;
            CapaPlaceholder.Visibility = Visibility.Collapsed;
        }
        catch
        {
            ImagemCapa.Source = null;
            ImagemCapa.Visibility = Visibility.Collapsed;
            CapaPlaceholder.Visibility = Visibility.Visible;
        }
    }

    private async void AoBuscarFaixa(object sender, MouseButtonEventArgs e)
    {
        if (!midiaAtual.PodeBuscar || midiaAtual.Duracao <= TimeSpan.Zero) return;
        buscandoFaixa = true;
        try
        {
            await Dispatcher.Yield(DispatcherPriority.Input);
            var destino = LinhaTempoMidia.Posicao(ProgressoFaixa.Value, midiaAtual.Duracao);
            bool sucesso = await midiaWindows.BuscarAsync(destino);
            if (!sucesso) TextoRetornoMidia.Text = "O player não aceitou a alteração de posição.";
            await AtualizarMidiaAsync();
        }
        catch (Exception erro)
        {
            TextoRetornoMidia.Text = "Não foi possível buscar na faixa: " + erro.GetType().Name;
        }
        finally { buscandoFaixa = false; }
    }
}
