using AnderFlowPrismIsland.Logic;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace AnderFlowPrismIsland;

// Histórico de cópias: opcional, desligado a cada início, só em memória.
public partial class MainWindow
{
    private const int WmClipboardUpdate = 0x031D;
    private readonly HistoricoCopias historicoCopias = new();
    private bool copiasAtivas;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool AddClipboardFormatListener(IntPtr janela);
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool RemoveClipboardFormatListener(IntPtr janela);

    private void AoAlternarCopias(object sender, RoutedEventArgs e)
    {
        if (origemMensagens is null) return;
        if (!copiasAtivas)
            copiasAtivas = AddClipboardFormatListener(origemMensagens.Handle);
        else
        {
            RemoveClipboardFormatListener(origemMensagens.Handle);
            copiasAtivas = false;
            historicoCopias.Limpar();      // desligar apaga o que foi guardado
        }
        AtualizarListaCopias();
    }

    private void AoLimparCopias(object sender, RoutedEventArgs e)
    {
        historicoCopias.Limpar();
        AtualizarListaCopias();
    }

    private void PararCopias()
    {
        if (copiasAtivas && origemMensagens is not null)
            RemoveClipboardFormatListener(origemMensagens.Handle);
        copiasAtivas = false;
        historicoCopias.Limpar();
    }

    private void AoMudarAreaTransferencia()
    {
        if (!copiasAtivas) return;
        try
        {
            // Gerenciadores de senha marcam o conteúdo para não ser monitorado: respeitamos.
            if (System.Windows.Clipboard.ContainsData("ExcludeClipboardContentFromMonitorProcessing")) return;
            if (!System.Windows.Clipboard.ContainsText()) return;
            if (historicoCopias.Adicionar(System.Windows.Clipboard.GetText()))
                AtualizarListaCopias();
        }
        catch (System.Runtime.InteropServices.ExternalException)
        {
            // Outro programa estava usando a área de transferência neste instante; ignoramos esta cópia.
        }
    }

    private void AoUsarCopia(object sender, RoutedEventArgs e)
    {
        if (sender is not System.Windows.Controls.Button { Tag: string texto }) return;
        try { System.Windows.Clipboard.SetText(texto); }
        catch (System.Runtime.InteropServices.ExternalException) { }
    }

    private void AtualizarListaCopias()
    {
        BotaoCopias.Content = "Histórico de cópias: " + (copiasAtivas ? "ligado" : "desligado");
        BotaoCopias.Background = Cor(copiasAtivas ? "#E8622A" : "#25242A");
        ListaCopias.Children.Clear();
        if (historicoCopias.Itens.Count == 0)
        {
            ListaCopias.Children.Add(new TextBlock
            {
                Text = copiasAtivas ? "Copie um texto e ele aparece aqui" : "Desligado. Ligue para começar a guardar.",
                FontSize = 11,
                Foreground = Cor("#A6A0A1")
            });
            return;
        }
        foreach (string texto in historicoCopias.Itens)
        {
            var botao = new System.Windows.Controls.Button
            {
                Style = (Style)FindResource("Acao"),
                Tag = texto,
                ToolTip = texto.Length > 300 ? texto[..300] + "…" : texto,
                Content = new TextBlock
                {
                    Text = HistoricoCopias.Resumo(texto),
                    TextTrimming = TextTrimming.CharacterEllipsis,
                    MaxWidth = 430
                }
            };
            botao.Click += AoUsarCopia;
            ListaCopias.Children.Add(botao);
        }
    }
}
