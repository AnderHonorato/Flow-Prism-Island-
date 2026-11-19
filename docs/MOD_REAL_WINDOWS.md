# Mod real do Windows — Ander Flow Prism Island v0.4.0

Este módulo altera **preferências reais do Windows 11 do usuário que estiver executando o aplicativo**. Não é um overlay que imita a taskbar. A ilha e o Dock Flow continuam disponíveis separadamente.

## Funcionalidades nativas

| Ação no app | Alteração efetiva |
|---|---|
| Windows escuro / claro | `HKCU\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize` — `AppsUseLightTheme` e `SystemUsesLightTheme` |
| Contorno das janelas | `HKCU\Software\Microsoft\Windows\DWM` — `ColorPrevalence` |
| Ícones da barra de tarefas à esquerda / centro | `HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced` — `TaskbarAl` |

As preferências anteriores são armazenadas, uma única vez, em
`%APPDATA%\Ander Flow\Prism Island\visual-windows-original.json`.
**Restaurar aparência original do Windows** repõe os valores anteriores ou remove valores que não existiam; não restaura ou desativa mods de terceiros. O backup é separado por usuário.

Não executa `reg.exe`, PowerShell visível, reinicializações de Explorer, elevação de privilégios ou alterações em `HKLM`. Alterações visuais podem demorar ou exigir sair e entrar na sessão. Na conta Lil, abra o app como Lil; o serviço remoto atualmente autenticado como Pichau não é substituto da sessão Lil.

## Mod visual profundo da barra de tarefas e do Explorer

Windows 11 não possui APIs públicas para modificar livremente os controles XAML internos da taskbar. Para modificação visual verdadeira do Explorer, o botão **Tema Prism na barra original (Windhawk)** gera a configuração com seletores `Taskbar.*`, copia o texto e abre o mod oficial `Windows 11 Taskbar Styler`.

1. Instale o Windhawk do site oficial, caso ainda não esteja instalado: https://windhawk.net/
2. No Windhawk, instale `Windows 11 Taskbar Styler`: https://windhawk.net/mods/windows-11-taskbar-styler
3. Clique no botão de tema Prism no app.
4. No Windhawk, abra o mod, vá em **Settings** → **Textual mode**, cole o preset e salve.
5. A barra de tarefas **original** recebe cantos arredondados e destaque laranja nos indicadores e hover.

Arquivo de preset:
`%APPDATA%\Ander Flow\Prism Island\prism-taskbar-styler.yaml`.

**Reversão do tema avançado:** desative o mod no Windhawk ou restaure suas configurações anteriores lá. O backup nativo do Prism **não** cobre regras Windhawk. Antes de importar, salve/exporte o preset anterior no Windhawk.

O Windhawk é um mecanismo de modificação de processo do sistema. Mods do Explorer podem ficar incompatíveis após atualizações do Windows e causar travamentos; escolha explicitamente e desative o mod afetado para recuperar a interface original. O Prism não instala nem ativa o Windhawk automaticamente.

## Limites da v0.4.0

- Personalização global de molduras e cantos de **todas** as janelas, ícones internos do Explorer, barra de tarefas flutuante e menu Iniciar ainda não são implementados nativamente no Prism.
- A mudança de tema do Windows não garante que aplicativos de terceiros sigam o modo escuro/claro.
- Não há instalador assinado, integração automática com CLI Windhawk, nem prova de testes visuais em todos os builds.
- O app não modifica a UI de outras contas enquanto estiver em execução como Pichau ou Lil.

## Referências técnicas

- Microsoft — configurações do Windows 11: https://learn.microsoft.com/windows/apps/develop/settings/settings-windows-11
- Microsoft — configuração de cores: https://support.microsoft.com/windows/experience/personalization/personalize-your-colors-in-windows
- Ramen Software — Windows 11 Taskbar Styler: https://windhawk.net/mods/windows-11-taskbar-styler
- Guia de seletores de componentes XAML do Explorer: https://github.com/ramensoftware/windows-11-taskbar-styling-guide

## Verificação

```powershell
dotnet run --project tests/Prism.Tests/Prism.Tests.csproj -c Release
dotnet build apps/desktop/AnderFlowPrismIsland.csproj -c Release
```

Testes de lógica verificam planos de alterações e geração do preset; **não** mudam o registro do Windows durante testes automáticos.
