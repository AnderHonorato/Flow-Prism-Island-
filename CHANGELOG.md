# Histórico de alterações

## v0.6.0-preview.1 — Audio Motion
- Visualizador luminoso com intensidade real via WASAPI no player e no entalhe compacto.
- Mini visualizador independente com opção de ficar presente quando a ilha oculta.
- Cores de destaque, entrada hexadecimal, tamanhos e controle de velocidade/intensidade no próprio Studio.
- Animações de hover, transições de aba e atualização instantânea de preferências.
- Conteúdo da área direita limitado ao viewport para evitar recorte em DPI 125% ou ultrawide.

# Histórico de alterações

## 0.5.0-preview — Prism Studio premium
- Interface redesenhada com sidebar, área de mídia ampliada, gradientes, sombra e cartões.
- Seletor de sessões de mídia do Windows, capa quando disponível e seek suportado.
- Painel de CPU, RAM, disco e rede com dados locais.
- Controles internos de transparência, dock superior/inferior e restauração do visual.
- Sessões rápidas de foco: 15/25/50 minutos.
- Removidos links de botões para Configurações do Windows; dock leva ao Studio interno.

# Histórico de alterações

## 0.3.0-dev — integração Prism v2
- Arquivos entregues por Claude integrados ao projeto Windows: design, estados compactos de música e foco, auto-ocultação, fullscreen e monitores múltiplos.
- Aba de cópias opcional e temporária (10 textos, desativada na inicialização, exclui ao desligar/sair).
- Corrigida ambiguidade WPF/WinForms no tipo Button que impedia a compilação.
- Novo ajuste de 1,5, 2,5 ou 5 segundos para ocultar automaticamente, com valor persistido e testes.
- Build Windows passou com 0 erros e 0 avisos; 11 testes de lógica aprovados.
- Empacotamento e teste visual do instalador ainda sujeitos à CI e verificação em máquina limpa.

## Não lançado — interface Prism v2 (branch feat/ui-prism-v2)
- Novo dicionário de recursos `Themes/Prism.xaml`: tokens de cor, ícones vetoriais e estilos únicos (aba, botão redondo, cartão, slider, barra de progresso).
- Abas com ícone de linha; controles de mídia como botões redondos (play/pausa e mudo trocam de ícone sozinhos).
- Slider de volume e barra de progresso redesenhados; foco de teclado visível em todos os botões.
- Atividade compacta na cápsula recolhida: equalizador animado com mídia tocando e tempo restante com sessão de foco ativa; a cápsula se alarga e volta ao tamanho normal sozinha.
- Ocultar automaticamente (ligado por padrão, opção em Ajustes): após 2,5 s sem uso a ilha sai completamente da tela e volta ao encostar o mouse no topo, no centro; o atalho Ctrl+Shift+Espaço e o ícone da bandeja também a trazem de volta. Fica sempre visível quando fixada ou aberta.
- Tela cheia: com jogo, vídeo ou apresentação em tela cheia (estado informado pelo Windows) a ilha some e não reaparece ao encostar o mouse; opção em Ajustes, ligada por padrão.
- Vários monitores: a ilha aparece no monitor em que o mouse encosta na borda superior central e se centraliza nele.
- Aba Cópias: histórico opcional da área de transferência (até 10 textos), só em memória, desligado a cada abertura; clique em um item para copiá-lo de novo. Respeita o sinal de conteúdo sensível dos gerenciadores de senha.
- Altura do painel expandido ajustada para 500 px (o conteúdo da aba Mídia não cabia em 395 px).
- Sem mudanças de lógica: todos os `x:Name` e manipuladores foram preservados. **Ainda não compilado nem testado visualmente no Windows.**

## 0.2.0-dev — 2026-11-18
- Mídia real pelo Windows GSMTC, volume/mudo via CoreAudio (NAudio), animação opcional por áudio (WASAPI loopback).
- Aba Alertas, Dock Flow opcional e reversível, troca de papel de parede com backup.

## 0.1.0-dev — 2026-11-18
- Base nativa WPF do Prism Island (cápsula e painel).
- Módulos locais de foco, sistema e ajustes, sem dados inventados.
- Estado fixado, hover com temporização, animação de abertura, bandeja e atalho global.
- Preferências por usuário e opção explícita para iniciar junto com Windows.
- Primeiros testes automatizados de domínio.

Nenhum release estável ou instalador assinado foi publicado.
## 0.4.0-dev — mod real do Windows 11
- Novos comandos reais de personalização do Windows por conta do usuário via HKCU: tema, contorno de janelas e alinhamento da taskbar.
- Confirmação visível, backup persistente de valores anteriores e restauração sem substituir o Explorer.
- Preset autoral do Windhawk Windows 11 Taskbar Styler para estilização avançada real da barra.
- Aba Desktop reorganizada com rolagem e distinção entre mod real e dock flutuante.
- 14 testes automatizados de lógica/backup executados em Windows; não substituem QA visual e funcional manual.
