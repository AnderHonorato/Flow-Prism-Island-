# Testes de primeira fatia — 2026-11-18

**Plataforma**: Windows 11, conta Pichau, .NET SDK 10.0.404.
**TDD**: compilação falhou inicialmente pela ausência de lógica; implementação mínima criada em seguida.

## Testes já executados
- Temporizador inicia com duração real: PASSOU
- Temporizador só desconta quando ativo: PASSOU
- Temporizador pausa, reinicia e para em zero: PASSOU
- Máquina de estados expande, fixa e não recolhe enquanto fixada: PASSOU

## Teste de inicialização nativa
- Publicação autocontida win-x64: executada sem falhas em 18/11/2026.
- Executável iniciou como processo do usuário Pichau, sessão Windows ID 2, sem encerramento inesperado no intervalo de observação (PID 10144, RAM aproximadamente 90 MB após inicialização).
- Sessão Windows Pichau estava DESCONETADA; Lil ocupava sessão console ativa. Por isso não houve inspeção visual E5, clique real no overlay ou screenshot. Não considerar teste E5 aprovado.

## Ainda sem evidência suficiente
- Abertura e fechamento visual em Windows físico.
- Tela ultrawide, DPI, múltiplos monitores, jogos fullscreen, atalho global sem conflito.
- Memória/CPU idle medidos, pipeline GitHub CI e controle de mídia real.

Nenhuma release estável autorizada por estes resultados isolados.
## QA v0.6.0 — 21/11/2026
- Build local Release em Windows 11 / .NET 10 com 20 testes de lógica aprovados (sem alegar teste visual completo).
- Fluxo de execução do WPF iniciado na sessão Pichau; painel e Aba Ajustes acessados pelo UI Automation, captura visual validada com PrintWindow.
- Correção de medição horizontal no Studio usando ScrollViewer.ViewportWidth.
- Ainda pendente: reproduzir um áudio real para comparar o movimento com o sinal WASAPI, conferir o mini overlay enquanto a ilha estiver oculta e testar interações físicas em DPI/monitor distintos.
