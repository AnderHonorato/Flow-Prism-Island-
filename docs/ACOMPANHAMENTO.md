# Acompanhamento — Ander Flow Prism Island

**Versão de código:** 0.2.0-dev
**Release pública:** NÃO PUBLICADA
**Data:** 2026-11-18 (America/Sao_Paulo)
**Repositório GitHub:** aguardando criação na conta AnderHonorato
**Branch de trabalho:** local

## Situação
- Pasta Windows criada e código WPF nativo escrito.
- Tests de domínio RED/GREEN executados; estado detalhado em docs/testes/RESULTADOS.md.
- Executável Windows autocontido gerado em dist/portable/AnderFlowPrismIsland.exe, build sem erros.
- Processo iniciou na sessão Pichau (desconectada); validação visual e de interação ainda não realizada.
- Sem release estável, testes de mídia real nem aprovação de release gate.

## Implementação 0.2.0 em validação
- Mídia via Windows GSMTC, comandos no player, volume do sistema, animação vinculada ao estado de reprodução e modo de captura de amplitude WASAPI opcional, apenas após clique.
- Dock Flow com launchers e troca de janelas; wallpaper opcional reversível.
- Alertas próprios e pedido de permissão ao listener Windows, sem acesso oculto.
- Ainda requer compilação CI e teste visual/manual; NÃO marcar recursos como concluidos.

## Prioridade única
Implementar e verificar mídia GSMTC em player real. Foco, controles nativos e compatibilidade ultrawide continuam sujeitos aos testes de experiência.

## Impedimento GitHub
Conector GitHub autenticado na conta AnderHonorato, mas não dispõe de ação de criação de repositório. O navegador remoto não tem sessão GitHub autenticada, e o PC não possui credencial Git armazenada recuperável. Não declarar repo criado.

## Checklist
Fonte de verdade: docs/backlog/TAREFAS.json. Mesmo com código compilado, recursos que exigem teste visual permanecem em andamento ou aguardando teste.

## Integração Prism v0.3.0 (18/11/2026)
- [x] Fonte do usuário: PATCH/ZIP Prism UI v2 recebido e incorporado em worktree isolada.
- [x] Correção dos conflitos de Button entre WPF e Windows Forms no módulo de cópias.
- [x] Tema Prism e ícones, atividade compacta, auto-ocultação, tela cheia, multi-monitor básico e histórico de cópias integrados no código.
- [x] Atraso de ocultação configurável em 1500, 2500 e 5000 ms; persistência com normalização para preferências antigas/inválidas.
- [x] Compilação de desenvolvimento em Windows 11 via .NET 10, sem avisos/erros; 11 testes de lógica passando.
- [ ] Validar visualmente a interface em múltiplos DPI/monitores, incluindo ultrawide.
- [ ] Validar o executável distribuído em máquina Windows limpa, com players reais e autoinício.
- [ ] Validar o instalador pelo pipeline CI e publicar prévia GitHub distinta da versão 0.2.0.
- [ ] Estilização avançada e reversível da barra de tarefas e janelas Windows (fora desta entrega).

## Mod Windows v0.4.0 (19/11/2026)
- [x] Ações nativas no Windows 11: tema de apps/sistema, cor de contorno, alinhamento de ícones da taskbar.
- [x] Backup não sobrescrito por usuário, restauração explícita, confirmação antes de alterar; nenhuma alteração global/admin automática.
- [x] Regras de estilo Taskbar Styler geradas para Windhawk e documentadas, com importação manual.
- [x] Aba Desktop com rolagem, controles reais separados do Dock Flow auxiliar.
- [x] 14 testes automatizados Windows aprovados, incluindo backup não invasivo.
- [ ] Validar visualmente todos os controles na sessão Lil; a compilação/testes ocorre no ambiente remoto Pichau.
- [ ] Aplicar e verificar Windhawk manualmente no Explorer após instalação e consentimento do usuário.
- [ ] Validar instalação/distribuição Windows em máquina limpa antes de chamar release estável.
