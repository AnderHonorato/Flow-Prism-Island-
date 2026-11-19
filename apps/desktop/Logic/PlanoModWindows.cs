using System;
using System.Collections.Generic;

namespace AnderFlowPrismIsland.Logic;

/// <summary>Plano tipado de mudanças REAIS em opções de personalização do Windows.</summary>
public enum ModWindowsOpcao
{
    TemaEscuroPrism,
    TemaClaro,
    AlinharEsquerda,
    AlinharCentro,
    BordasDestaque,
    BordasPadrao
}

public sealed record AlteracaoWindows(string Chave, string Nome, int Valor);

public static class PlanoModWindows
{
    public const string CaminhoTema = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
    public const string CaminhoBarra = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
    public const string CaminhoDwm = @"Software\Microsoft\Windows\DWM";

    public static readonly AlteracaoWindows[] ChavesGerenciadas =
    [
        new(CaminhoTema, "AppsUseLightTheme", 0),
        new(CaminhoTema, "SystemUsesLightTheme", 0),
        new(CaminhoDwm, "ColorPrevalence", 0),
        new(CaminhoBarra, "TaskbarAl", 1)
    ];

    public static IReadOnlyList<AlteracaoWindows> Criar(ModWindowsOpcao modo) => modo switch
    {
        ModWindowsOpcao.TemaEscuroPrism => [
            new(CaminhoTema, "AppsUseLightTheme", 0),
            new(CaminhoTema, "SystemUsesLightTheme", 0),
            new(CaminhoDwm, "ColorPrevalence", 1)
        ],
        ModWindowsOpcao.TemaClaro => [
            new(CaminhoTema, "AppsUseLightTheme", 1),
            new(CaminhoTema, "SystemUsesLightTheme", 1),
            new(CaminhoDwm, "ColorPrevalence", 0)
        ],
        ModWindowsOpcao.AlinharEsquerda => [new(CaminhoBarra, "TaskbarAl", 0)],
        ModWindowsOpcao.AlinharCentro => [new(CaminhoBarra, "TaskbarAl", 1)],
        ModWindowsOpcao.BordasDestaque => [new(CaminhoDwm, "ColorPrevalence", 1)],
        ModWindowsOpcao.BordasPadrao => [new(CaminhoDwm, "ColorPrevalence", 0)],
        _ => throw new ArgumentOutOfRangeException(nameof(modo))
    };

    // Regras próprias para importar em "Windows 11 Taskbar Styler", Windhawk.
    // Afetam controles do explorer.exe, NÃO um dock falso desenhado pelo Prism.
    public static string GerarConfigWindhawk() =>
        """
        controlStyles:
          - target: Taskbar.TaskListButton
            styles:
              - CornerRadius=12
          - target: Taskbar.TaskListButtonPanel@CommonStates > Grid > Border#BackgroundElement, Taskbar.TaskListButtonPanel@CommonStates > Border#BackgroundElement
            styles:
              - Background@InactivePointerOver=#22E8622A
              - CornerRadius=12
          - target: Grid#IconPanel@RunningIndicatorStates > Rectangle#RunningIndicator, Taskbar.TaskListLabeledButtonPanel@RunningIndicatorStates > Rectangle#RunningIndicator
            styles:
              - Fill=#FFE8622A
              - Height=3
              - Width=18
              - Width@ActiveRunningIndicator=22
        """;
}
