using AnderFlowPrismIsland.Logic;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace AnderFlowPrismIsland;

public partial class MainWindow
{
    private readonly ServicoModWindows modificadorWindows = new();

    private void AplicarModReal(ModWindowsOpcao opcao, string nome)
    {
        if (!ServicoModWindows.Compativel)
        {
            TextoDesktop.Text = "Mod de aparência nativo disponível no Windows 11.";
            return;
        }

        var confirmacao = System.Windows.MessageBox.Show(this,
            $"Modificar {nome} na aparência REAL do Windows para a conta '{Environment.UserName}'?\n\n" +
            "O Prism Island guardará as opções originais antes de alterar. " +
            "Algumas mudanças de barra exigem sair e entrar na sessão ou reiniciar o Explorer. " +
            "Nenhum aplicativo será encerrado automaticamente.",
            "Ander Flow · Modificar Windows", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (confirmacao != MessageBoxResult.Yes) return;

        try
        {
            modificadorWindows.Aplicar(opcao);
            TextoDesktop.Text = $"{nome} aplicado às preferências reais de {Environment.UserName}. " +
                "Se a barra não atualizar, encerre e entre novamente na sua sessão. " +
                "Use 'Restaurar Windows' para desfazer.";
        }
        catch (Exception erro)
        {
            TextoDesktop.Text = "Falha ao modificar Windows: " + erro.Message;
        }
    }

    private void AoWindowsEscuro(object sender, RoutedEventArgs e) =>
        AplicarModReal(ModWindowsOpcao.TemaEscuroPrism, "tema escuro e bordas de destaque");

    private void AoWindowsClaro(object sender, RoutedEventArgs e) =>
        AplicarModReal(ModWindowsOpcao.TemaClaro, "tema claro");

    private void AoWindowsAlinharEsquerda(object sender, RoutedEventArgs e) =>
        AplicarModReal(ModWindowsOpcao.AlinharEsquerda, "ícones da barra à esquerda");

    private void AoWindowsAlinharCentro(object sender, RoutedEventArgs e) =>
        AplicarModReal(ModWindowsOpcao.AlinharCentro, "ícones centralizados");

    private void AoWindowsBordas(object sender, RoutedEventArgs e) =>
        AplicarModReal(ModWindowsOpcao.BordasDestaque, "borda de destaque das janelas");

    private void AoWindowsRestaurar(object sender, RoutedEventArgs e)
    {
        if (!modificadorWindows.PossuiBackup)
        {
            TextoDesktop.Text = "Sem backup: o Prism ainda não alterou as opções do Windows desta conta.";
            return;
        }
        if (System.Windows.MessageBox.Show(this, "Restaurar as preferências de aparência do Windows " +
                "salvas antes da primeira alteração do Prism? Não remove mods de terceiros.",
                "Restaurar Windows", MessageBoxButton.YesNo, MessageBoxImage.Warning)
            != MessageBoxResult.Yes) return;
        try
        {
            modificadorWindows.Restaurar();
            TextoDesktop.Text = "Preferências originais restauradas. " +
                "Algumas mudanças de barra exigem sair e entrar novamente.";
        }
        catch (Exception erro)
        {
            TextoDesktop.Text = "Não foi possível restaurar: " + erro.Message +
                ". O backup foi preservado.";
        }
    }

}
