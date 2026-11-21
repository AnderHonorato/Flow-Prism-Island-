# Ander Flow Prism Island

Ilha dinâmica nativa e gratuita para Windows 11, com foco em rapidez e personalização 2D, desenvolvida pela Ander Flow.

**Situação:** v0.6.0-preview.1 (fase inicial; não é release estável).

## O que já existe no código
- Janela WPF real, transparente, sem moldura e sempre visível; cápsula compacta que expande no mouse/clique.
- Painel recolhível com estado fixado, animação de abertura e atalho global Ctrl+Shift+Espaço (se disponível).
- Temporizador real de 25 minutos, com iniciar, pausar e reiniciar.
- Hora, resolução do monitor principal, RAM consumida pelo aplicativo e tempo ativo do Windows.
- Temas Prism Flow, Fosco Claro, Monocromático e Preto Clássico.
- Ícone da bandeja com opção de mostrar, recolher e sair.
- Configurações locais por usuário; autoinício somente por escolha explícita.

## Atualização v0.2.0-dev
- Sessões de mídia reais pelo Windows GSMTC (Spotify, navegadores e players compatíveis): título, artista, tempo, anterior, reproduzir/pausar e próxima conforme recursos expostos.
- Volume e silenciar da saída principal do Windows com CoreAudio via NAudio.
- Barras animadas enquanto a música toca, com **modo opcional de reação à intensidade do áudio real (WASAPI loopback)**. Não coleta nem transmite áudio; captura apenas ao clicar no botão.
- Aba Alertas com histórico local de eventos do próprio app; solicitação explícita ao Windows para ler notificações externas (acesso requer identidade MSIX apropriada, não garantido para .exe).
- Dock Flow opcional e reversível, com abrir arquivos, navegador, configurações e alternar janelas abertas.
- Seleção/restauração de wallpaper com backup anterior; atalho para configurações nativas da barra de tarefas.
- O dock **não substitui nem estiliza a barra de tarefas original**. Os recursos de shell mais invasivos permanecem planejados.

## O que ainda não deve ser considerado pronto
Detecção automática de fullscreen, multi-monitor avançado, notificações globais sem MSIX, edição visual avançada da taskbar, instalador assinado e integrações de IA. Consulte `docs/ACOMPANHAMENTO.md`.

## Executar no Windows
Requer Windows 10/11 x64 e SDK .NET 10 para compilar. Na raiz do projeto:

```powershell
dotnet run --project apps/desktop/AnderFlowPrismIsland.csproj
```

Para gerar versão portátil autocontida:
```powershell
dotnet publish apps/desktop/AnderFlowPrismIsland.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o dist/portable
```

A execução do EXE não requer terminal visível. Feche usando ícone da bandeja > Sair.

## Testes
```powershell
dotnet run --project tests/Prism.Tests/Prism.Tests.csproj -c Release
```

## Licença e origem
Código original independente da Ander Flow, sem incorporar código nem assets de aplicativos de terceiros. Inspirado funcionalmente em interfaces de ilha dinâmica. Atribuições e limites em `docs/LICENCAS_TERCEIROS.md`. Licença MIT no arquivo LICENSE.

## Rastreamento
O escopo completo (418 itens) consta no superprompt do produto e no backlog estruturado em `docs/backlog/TAREFAS.json`. Funcionalidade não testada não é marcada como concluída.

## Prism v0.3.0 — interface e comportamento (prévia)
- Visual Prism com ícones vetoriais, controles de reprodução compactos, foco acessível e painel expandido de 500 px.
- Atividade compacta: indicador de música, temporizador de foco e retorno à largura normal quando a atividade termina.
- Ocultação automática opcional: a ilha sai do topo e retorna ao alcançar a borda superior do monitor.
- Novo ajuste do tempo de ocultação: **1,5 s, 2,5 s ou 5 s**, salvo em configurações locais.
- Ocultação em tela cheia para reduzir interferência em jogos e vídeos; suporte básico a monitores múltiplos.
- Aba **Cópias**: histórico de até 10 textos, **desligado por padrão**, guardado apenas em memória e limpo ao desligar/fechar. Respeita a marca de exclusão de monitoramento de clipboard quando fornecida pela origem. Não garante reconhecimento de todos os dados confidenciais.

**Validação atual:** projeto compilado no Windows com .NET 10 (sem erros/avisos) e 11 testes de lógica aprovados. **Não substituir por isso um teste visual completo de todos os monitores, players e escalas de DPI**. Instalador e pacote portátil são construídos pelo workflow Windows do GitHub.

### Fontes e integração
As melhorias da interface partiram dos arquivos PATCH/ZIP fornecidos pelo usuário e foram integradas numa branch isolada. As modificações locais não commitadas na pasta original foram preservadas. Todas as futuras alterações devem partir deste código versionado e passar novamente pela CI.

## v0.4.0-dev — mod real do Windows 11
A aba Desktop agora possui controles nativos para o Windows **real**: tema claro/escuro, alinhamento dos ícones da barra de tarefas e contorno das janelas. O aplicativo salva o estado original por usuário antes de qualquer alteração, pede confirmação e oferece restauração. Para estilo avançado da barra original, inclui um preset para **Windows 11 Taskbar Styler (Windhawk)** com seletores do Explorer; sua instalação e aplicação são opcionais e manuais. Consulte [docs/MOD_REAL_WINDOWS.md](docs/MOD_REAL_WINDOWS.md). Nenhuma modificação é aplicada automaticamente durante build, teste ou inicialização.

## Prism Studio v0.5.0-preview — interface premium integrada

- Navegação lateral, cartões em camadas, efeitos suaves, controles vetoriais e janela expandida com conteúdo rolável.
- Mídia GSMTC: escolha de player, metadados, capa quando disponibilizada, controle de reprodução, busca na faixa quando permitida e volume global.
- Painel de desempenho com **dados locais reais** de CPU, RAM, disco e rede; ausência de dado é exibida como indisponível.
- Dock Flow com posição superior/inferior e opacidade configuráveis dentro do Prism; o botão Studio reabre o próprio app.
- Controles internos de opacidade da ilha, restauração do visual, e sessões de foco de 15, 25 ou 50 minutos.
- Desktop Atelier aplica apenas opções nativas previamente existentes com confirmação e restauração. Não abre páginas de Configurações do Windows.
- Notificações globais continuam dependendo de identidade de pacote/permissões específicas; sem inventar eventos.
- O aplicativo permanece uma **prévia**, ainda sujeito a validação visual e de players no PC.

## Prism Audio Motion v0.6.0 — prévia

- Visualizador 2D com barras luminosas em ritmo de amplitude REAL da saída de áudio (WASAPI), com suavização de picos, atualização leve e sem gravação, arquivos ou transmissão.
- Equalizador na área de mídia e no entalhe compacto quando uma sessão compatível estiver tocando.
- Mini visualizador independente opcional quando o entalhe se auto-oculta: **sempre visível durante a música** ou **ocultar junto com o entalhe**. Respeita a regra de tela cheia.
- Personalização no Studio: cinco cores, hexadecimal, largura do entalhe, largura do Studio, intensidade e velocidade do movimento. Atualização visual imediata e persistida por usuário.
- Botões com transições animadas ao passar o cursor, realce de seleção, mudança de abas com fade e superfícies com acabamento refinado.
- Todos os controles ficam no aplicativo; nenhum botão redireciona para páginas de Configurações do Windows.
- Captura local da saída de áudio inicia quando uma sessão de mídia reproduz e pode ser desativada no player. Sem sessão ou acesso à saída de áudio, não afirma estar sincronizado à música.

Testes automatizados: 20 testes de domínio; compilação WPF e QA visual devem passar antes da promoção da prévia.
