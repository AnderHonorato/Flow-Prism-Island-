using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace AnderFlowPrismIsland.Logic;

/// <summary>
/// Aplica alterações REAIS nas preferências do Windows do usuário logado.
/// Não injeta código, não substitui explorer.exe e não altera HKLM.
/// </summary>
public sealed class ServicoModWindows
{
    private sealed record ValorAnterior(string Chave, string Nome, bool Existia, int Valor);
    private sealed record CopiaSeguranca(string Conta, DateTimeOffset Data, List<ValorAnterior> Valores);

    private readonly string caminhoBackup;

    public ServicoModWindows(string? pastaDados = null)
    {
        string pasta = pastaDados ?? Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Ander Flow", "Prism Island");
        caminhoBackup = Path.Combine(pasta, "visual-windows-original.json");
    }

    public bool PossuiBackup => File.Exists(caminhoBackup);

    public static bool Compativel => OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22000);

    /// <summary>Prepara uma cópia sem alterar o Windows; útil antes de testar um tema.</summary>
    public void PrepararBackup()
    {
        if (!Compativel) throw new PlatformNotSupportedException("Este módulo requer Windows 11.");
        GarantirBackup();
    }

    public void Aplicar(ModWindowsOpcao opcao)
    {
        if (!Compativel) throw new PlatformNotSupportedException("Este módulo requer o Windows 11.");
        var alteracoes = PlanoModWindows.Criar(opcao);
        GarantirBackup();
        // Em caso de falha parcial, restaura somente os valores desta operação.
        var anteriores = alteracoes.Select(a => LerAtual(a.Chave, a.Nome)).ToList();
        try
        {
            foreach (var alteracao in alteracoes)
            {
                using var chave = Registry.CurrentUser.CreateSubKey(alteracao.Chave, writable: true)
                    ?? throw new InvalidOperationException("Não foi possível acessar a configuração do Windows.");
                chave.SetValue(alteracao.Nome, alteracao.Valor, RegistryValueKind.DWord);
            }
        }
        catch
        {
            foreach (var item in anteriores) { try { EscreverValor(item); } catch { /* backup persiste */ } }
            throw;
        }
        AtualizarTemaWindows();
    }

    public void Restaurar()
    {
        if (!File.Exists(caminhoBackup))
            throw new FileNotFoundException("Nenhum backup de aparência encontrado.");

        var dados = JsonSerializer.Deserialize<CopiaSeguranca>(File.ReadAllText(caminhoBackup))
            ?? throw new InvalidDataException("Backup de aparência inválido.");
        if (dados.Conta != Environment.UserName)
            throw new UnauthorizedAccessException("Backup pertence a outro usuário do Windows.");
        if (dados.Valores == null || dados.Valores.Count != PlanoModWindows.ChavesGerenciadas.Length)
            throw new InvalidDataException("Backup incompleto.");
        // Segurança: não aceitamos caminhos arbitrários de um arquivo JSON modificado.
        var permitidas = PlanoModWindows.ChavesGerenciadas
            .Select(a => a.Chave + "\0" + a.Nome).ToHashSet(StringComparer.OrdinalIgnoreCase);
        if (dados.Valores.Any(a => !permitidas.Contains(a.Chave + "\0" + a.Nome)))
            throw new InvalidDataException("O backup contém chaves não autorizadas.");
        foreach (var valor in dados.Valores) EscreverValor(valor);
        File.Delete(caminhoBackup);
        AtualizarTemaWindows();
    }

    private void GarantirBackup()
    {
        if (PossuiBackup)
        {
            // Não sobrescreve o estado original em aplicações subsequentes.
            var existente = JsonSerializer.Deserialize<CopiaSeguranca>(File.ReadAllText(caminhoBackup));
            if (existente?.Conta != Environment.UserName)
                throw new InvalidDataException("Backup existente inválido ou de outra conta.");
            return;
        }

        var dados = new CopiaSeguranca(Environment.UserName, DateTimeOffset.Now,
            PlanoModWindows.ChavesGerenciadas.Select(a => LerAtual(a.Chave, a.Nome)).ToList());
        Directory.CreateDirectory(Path.GetDirectoryName(caminhoBackup)!);
        string temporario = caminhoBackup + ".tmp";
        File.WriteAllText(temporario, JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true }));
        File.Move(temporario, caminhoBackup, overwrite: false);
    }

    private static ValorAnterior LerAtual(string caminho, string nome)
    {
        using var chave = Registry.CurrentUser.OpenSubKey(caminho);
        var tipo = chave?.GetValueNames().Contains(nome, StringComparer.OrdinalIgnoreCase) == true
            ? chave.GetValueKind(nome) : (RegistryValueKind?)null;
        if (tipo is not null && tipo != RegistryValueKind.DWord)
            throw new InvalidDataException("Tipo de registro inesperado: " + nome);
        return new ValorAnterior(caminho, nome, tipo is not null,
            tipo is null ? 0 : Convert.ToInt32(chave!.GetValue(nome)));
    }

    private static void EscreverValor(ValorAnterior anterior)
    {
        using var chave = Registry.CurrentUser.CreateSubKey(anterior.Chave, writable: true)
            ?? throw new UnauthorizedAccessException("Chave do Windows inacessível.");
        if (anterior.Existia) chave.SetValue(anterior.Nome, anterior.Valor, RegistryValueKind.DWord);
        else chave.DeleteValue(anterior.Nome, throwOnMissingValue: false);
    }

    private const uint WmSettingChange = 0x001A;
    private const uint SmtoAbortIfHung = 0x0002;

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern IntPtr SendMessageTimeout(
        IntPtr janela, uint mensagem, IntPtr wparam, string texto,
        uint flags, uint tempoLimite, out IntPtr resultado);

    private static void AtualizarTemaWindows()
    {
        // Notifica aplicações das novas preferências. Não encerra Explorer.
        if (!OperatingSystem.IsWindows()) return;
        SendMessageTimeout(new IntPtr(0xFFFF), WmSettingChange, IntPtr.Zero,
            "ImmersiveColorSet", SmtoAbortIfHung, 800, out _);
    }
}
