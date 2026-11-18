# SUPERPROMPT MESTRE — ANDER FLOW PRISM ISLAND

> **Documento de execução para GPT-6.2 Astra (caso disponível), Claude Opus, Grok, modelos futuros e orquestradores compatíveis com agentes.**  
> **Produto:** Ander Flow Prism Island  
> **Versão inicial do produto:** `v0.1.0`  
> **Versão deste documento:** `1.0.0`  
> **Data de elaboração:** 18 de novembro de 2026  
> **Criador / marca:** Ander Flow  
> **Plataforma-alvo:** Windows 11 (prioritário) e Windows 10 compatível, x64; avaliar ARM64 em trilha própria.  
> **Repositório proposto:** `https://github.com/AnderHonorato/Ander-Flow-Prism-Island` (ENDEREÇO PROPOSTO, **NÃO CRIADO NESTE DOCUMENTO**).  
> **Idioma:** português brasileiro, incluindo interface, código comentado quando útil, arquivos de orientação e documentação.  
> **Status:** plano executável e material de referência; **não significa que código, repo, testes ou releases já existam**.

---

## 00. COMO USAR ESTE DOCUMENTO

1. Entregue **este arquivo integral** à IA orquestradora escolhida e diga: `Execute o SUPERPROMPT MESTRE, não apenas resuma. Inicie pela auditoria de fontes, gere o repositório após validar autorização e acesso, implemente a primeira fatia real, teste e atualize o checklist.`
2. Se a plataforma suportar equipes/agentes paralelos, instancie os especialistas definidos abaixo com isolamento de escopo, contrato de tarefas, revisões cruzadas e responsabilidades comprováveis. Se não suportar, execute os mesmos papéis sequencialmente **sem fingir subagentes ou ferramentas inexistentes**.
3. Verifique os acessos GitHub, internet, máquinas Windows, ferramentas de build e plugins antes de planejar operações. Use conectores instalados apropriados; nunca exponha tokens, cookies, senhas, chaves de API ou dados de terceiros.
4. **Não faça um relatório substituindo implementação.** A meta é software real, instalável, modular, utilizável e visualmente bem resolvido. Ao finalizar cada ciclo, entregue provas e prossiga para o próximo item priorizado enquanto a execução estiver disponível.
5. Nenhum modelo deve declarar `feito`, `validado`, `sincronizado`, `commitado`, `publicado` ou `testado no Windows` sem evidência técnica correspondente. Diferencie protótipo visual, mock, código parcial, build, teste automatizado, teste real e release.
6. Quando um link não puder ser lido, marque `FONTE INACESSÍVEL`, registre a URL, procure repositório oficial/espelho/README/release/changelog relacionado e **não invente** recursos nem licenças.

### Convenções normativas

- **DEVE** = requisito obrigatório para a entrega respectiva.
- **PREFERIR** = escolha padrão, salvo justificativa documentada.
- **NÃO DEVE** = proibição.
- **EXPERIMENTAL** = somente em módulo opt-in, nunca como funcionalidade comprovada.
- **NÃO VERIFICADO** = hipótese, página inacessível, alegação publicitária ou recurso ainda não testado.
- **Fonte** = URL, título, autor, data consultada, data publicada quando identificável, evidência e nível de confiança.

---

## 01. IDENTIDADE DO PRODUTO E NORTE DO PROJETO

**Missão:** criar para Windows uma Ilha Dinâmica de alto nível, compacta, interativa, modular e animada, com o cuidado visual do projeto **HeyyCzer/windows-dynamic-island** como **referência principal de linguagem de interação**, incorporando funcionalidades úteis investigadas nos demais projetos e uma personalização opcional do desktop. O resultado deve parecer um produto coeso da **Ander Flow**, não uma colagem de aplicativos.

**Nome público:** `Ander Flow Prism Island`  
**ID interno:** `br.anderflow.prismisland`  
**Slug do repositório:** `Ander-Flow-Prism-Island`  
**Executável sugerido:** `AnderFlowPrismIsland.exe`  
**Artefatos:** `Ander-Flow-Prism-Island-v0.1.0-win-x64-setup.exe` e `Ander-Flow-Prism-Island-v0.1.0-win-x64-portable.zip`, após build e validação.

**Regra de unicidade:** antes de criar o repositório, pesquisar existência de projeto/repo e nome de pacote. Se o slug estiver ocupado pelo titular ou conflitar com um projeto existente, usar uma variação única documentada, mantendo `Ander`, `Flow`, `Prism` e versão nos releases. Nunca sobrescrever repositório de outro projeto. O **nome do app mantém identidade estável**; **a versão** segue sequência versionada, não cria novo repositório por atualização.

### Principais resultados esperados

- Ilha Dinâmica real sobre o desktop, com estados recolhido, atividade compacta, prévia transitória, painel expandido, painel fixado e ocultação inteligente.
- Módulos funcionais: mídia, notificações, clipboard, arquivos, agenda, temporizadores, áudio, sistema, ferramentas, pesquisa, IA/agentes, GitHub, ações rápidas e outros descobertos na pesquisa.
- Visual 2D premium com modos `Notch Preto`, `Prism Flow`, `Vidro Fosco` e `Minimal`; animações suaves; modularidade de verdade.
- Personalização **opcional, reversível e segura** de dock, barra superior, widgets, atalhos, papéis de parede e organização de janelas; sem injetar código no Explorer por padrão.
- Instalador e ZIP portátil; inicialização automática silenciosa com Windows; tray funcional; recuperação limpa; atualização confiável; logs locais protegidos; consumo de recursos medido.
- GitHub com código-fonte, documentação, issues, projetos/checklists, CI, releases numeradas, changelog, provas de testes, screenshots e links verificáveis.

### Limites obrigatórios

- **Não** alegar que um overlay do Windows transforma fisicamente a câmera em Dynamic Island: é uma interface desenhada sobre a tela, independente de recorte físico.
- **Não** copiar código fechado, instaladores, recursos gráficos ou marcas de produtos pagos; implementar recursos semelhantes de maneira independente, após verificar licenças e termos.
- **Não** misturar GPL com licença incompatível nem remover créditos/cabeçalhos. Se criar derivação de HeyyCzer GPL, cumprir integralmente as obrigações da GPL-3.0-or-later aplicáveis à distribuição do derivado.
- **Não** tratar controle de mídia, leitura de notificações, integração Discord ou alterações de shell como garantidos em qualquer máquina: verificar APIs, permissões, versões e limitações.
- **Não** usar imagens criadas artificialmente como substituto de componentes reais de interface; ícones originais em SVG, vetores, CSS e componentes funcionais são preferidos.
- **Não** instalar versões beta, alterar registro, modificar shell, copiar arquivos do usuário, expor APIs na rede ou ativar qualquer custo/serviço pago sem necessidade e autorização.

---

## 02. PADRÃO VISUAL ANDER FLOW — CONTRATO DE DESIGN

O visual-base é **editorial 2D, moderno, compacto, polido, quente e sofisticado**. A referência primária de microinteração/estrutura é o HeyyCzer: cápsula preta discreta, painel aberto bem hierarquizado, cartões arejados, alternância rápida de módulos, animações fluidas e foco em informações reais. A identidade final deve ser original da Ander Flow.

| Token | Valor inicial | Uso |
|---|---|---|
| `--flow-orange` | `#E8622A` | realce principal, progresso, foco e ações importantes |
| `--flow-black` | `#0A0A0F` | superfície principal da cápsula |
| `--flow-graphite` | `#141418` | painéis, cartões e superfícies profundas |
| `--flow-warm-white` | `#F5F5F0` | texto principal em modo escuro / fundos claros |
| `--flow-soft-ivory` | `#F0F0EB` | superfícies do modo claro |
| `--flow-muted` | a definir por contraste | textos secundários, ícones inativos |
| `--flow-divider` | a definir por contraste | contornos finos, separadores |
| `--flow-danger` | acessível, não neon | erro real |
| `--flow-success` | acessível, discreto | sucesso real, sem tornar a interface verde |

### Regras visuais

1. **A cápsula é protagonista**, não uma barra enorme permanente. Recolhida mostra conteúdo útil e mínimo; expandida mostra controles contextualizados sem bloquear o desktop mais do que o necessário.
2. Evitar 3D, exagero gamer, glow excessivo, gradientes chamativos, verde dominante, emojis de sistema como iconografia final, sombras pesadas, vidro ilegível e bordas grossas.
3. Favorecer **SVG autoral** e ícones vetoriais coerentes, curvas refinadas, tipografia legível, pesos limitados, bordas estilo tinta, proporções consistentes e transições curtas.
4. Projetar 4 famílias de tema desde o início: `Clássico Preto`, `Prism Flow Laranja`, `Fosco Claro`, `Editorial Monocromático`. Permitir edição de cores, raios, opacidade e animações com preview ao vivo.
5. **Respeitar acessibilidade:** contraste mínimo WCAG AA sempre que aplicável, foco visível, navegação por teclado, atalhos configuráveis, modo redução de movimento, suporte a escala de fonte, leitura por tecnologias assistivas onde tecnicamente possível.
6. **Estados reais:** sem `tente novamente`, `resposta padrão`, `resposta local`, `prévia` ou placeholders de demonstração aparecendo como se fossem funções prontas. Quando dados estiverem ausentes, exibir estado vazio de produto, simples e honesto.
7. Exigir screenshot real e revisão visual para cada módulo nos estados vazio, carregando, ativo, erro, desabilitado, offline e permissões insuficientes.
8. Criar animações com física amortecida previsível: suavidade sem tremor, bounce com amplitude controlada, interrupção de animação segura e zero deriva espacial entre frames.

### Geometria e interação (valores **iniciais a validar**, não fatos de apps terceiros)

- Cápsula recolhida: alvo inicial de 174–228 × 32–40 px lógicos, adaptada ao conteúdo, DPI e fonte.
- Atividade compacta: ajuste de largura animado sem deslocamento brusco do centro.
- Expandida: largura inicial 360–520 px; crescimento vertical responsivo e limites por área disponível; suporte a painel médio/grande mediante necessidade.
- Transições: 140–260 ms em operações comuns, 250–420 ms em expansões complexas; interrompíveis e compatíveis com modo de movimento reduzido.
- Cantos arredondados orgânicos, borda de 1 px equivalente DPI; outline opcional, ruído sutil apenas se não reduzir legibilidade.
- Painel top-center inicialmente; permitir outros pontos e escolha explícita de monitor, sem presumir que `(0,0)` seja sempre a tela principal.
- Hover com margem de histerese para impedir que a ilha abra/feche repetidamente; clique para fixar; Esc para recolher; clique externo para fechar; teclado e mouse devem funcionar sem capturar input fora da área útil.
- Drag-and-drop só onde suportado; suporte a trackpad, rolagem, touch e navegação exclusivamente por teclado.
- Modo ultrawide 3440 × 1440 a até 165 Hz, Windows com escalas 100/125/150/200%, multi-monitor com DP/HDMI, telas com coordenadas negativas, wake/sleep e troca de monitor principal.

### Tokens e componentes de UI a implementar

`IslandShell`, `CollapsedCapsule`, `LiveActivityPill`, `PeekOverlay`, `ExpandedPanel`, `PinnedPanel`, `ModuleTabs`, `ModuleLauncher`, `SectionHeader`, `MediaCard`, `ActionChip`, `ProgressRing`, `MiniWaveform`, `ToastStack`, `WidgetGrid`, `EmptyState`, `PermissionCard`, `Skeleton`, `SafeDialog`, `ThemePreview`, `MonitorPicker`, `StatusDot`, `ActivityTimeline`, `ErrorBoundary`.

Definir catálogo no Storybook ou ferramenta equivalente, variações, props tipadas, contrastes e componentes aprovados. Não fazer cada módulo com estilos isolados.

---

## 03. REFERÊNCIAS OBRIGATÓRIAS — AUDITORIA DE 18/11/2026

> Esta tabela registra o **que foi possível identificar publicamente na data da pesquisa**. São pistas para auditoria, não atestados de que tudo foi instalado ou testado. O agente deverá revisitar fontes, releases, issues, commits e licenças no momento real da implementação.

| ID | Origem / URL | Evidência inicial / foco | Condição e cuidado |
|---|---|---|---|
| R01 | [NotNotch — Gumroad](https://bbalduzz.gumroad.com/l/notnotch) | inspiração de notch e possíveis gestos/recursos | Página não forneceu conteúdo legível na consulta; preço, licença, recursos e download **não verificados**. Não presumir que `gratuito` permita copiar código. |
| R02 | [DynamicWin — FlorianButz](https://github.com/FlorianButz/DynamicWin) | mídia, favoritos, calendário Google, file tray, Bluetooth e bateria, spring notch, troca de views, atualizador | README informa que o repositório atual **só hospeda releases e não contém código-fonte**. Licença CC BY-SA 4.0 exibida deve ser examinada no escopo exato; não assumir permissão sobre binários ou código indisponível. |
| R03 | [Cosmic-light — catálogo UStack](https://ustack.app/en/products/cosmic-light) | mídia, tempo real, agenda, IA, posição/monitor, vidro animado | Catálogo secundário. Ir ao [repositório do autor](https://github.com/uspraveen/Cosmic-light) para fonte e licença MIT, inspeção de implementação e execução. |
| R04 | [WinIsland-X — site enviado](https://fttawa.github.io/WinIsland-X/) | efeito Liquid Glass, renderização Rust/Skia, espectro, plugins, animação física | Conteúdo textual indexado descreve MIT e recursos, **mas a URL e `github.com/fttawa/WinIsland-X` não responderam na rechecagem**; registrar como fonte histórica/não confirmada. [fttawa/IslandX](https://github.com/fttawa/IslandX) é um projeto atualmente localizável, **não assumir que seja o mesmo código ou sucessor sem prova**. |
| R05 | [WinIsland — página AlternativeTo](https://alternativeto.net/software/winisland/about/) | cápsula multimídia com controles, arte, múltiplos monitores | A página remete a um app; **existem projetos homônimos distintos**. Identificar autor e URL de download real antes de atribuir funções/maioria. Examinar [zHeuzy2/WinIsland](https://github.com/zHeuzy2/WinIsland) e [WinIslandProject/WinIsland](https://github.com/WinIslandProject/WinIsland) como referências separadas, nunca trocar uma pela outra silenciosamente. |
| R06 | [Seelen UI](https://seelen.io/pt-BR/apps/seelen-ui) | dock, barra, início, widgets, janelas lado a lado, wallpapers animados, atalhos | Projeto de personalização geral; base Rust/Tauri divulgada. Recursos de shell devem ficar opcionais e reversíveis. |
| R07 | [Notchify](https://notchify.app/) | música/letras sincronizadas, notificações, clipboard, arquivos, gravação, leitura de tela, QR, Discord, transferência celular–PC, downloads e widgets | **Produto pago, com teste gratuito**. Estudar comportamento público; não extrair código fechado, assets nem contornar pagamento. |
| R08 | [MyDockFinder — Steam](https://store.steampowered.com/app/1787090/MyDockFinder/) | dock fluido, atalhos, arrastar arquivos, gerência de apps, barra e controles | Produto comercial. Não copiar código, marcas nem arquivos; inspiração de interação/UX apenas. |
| R09 | [WindowBlinds — Stardock](https://www.stardock.com/products/windowblinds/) | molduras, botões, skins, cores, fontes, transparências e presets | Produto comercial. Alterar estilo de janelas globalmente é de alto risco; módulo separado e opt-in, sem hacks destrutivos. |
| R10 | [WindowBlinds — URL com referer](https://www.stardock.com/products/windowblinds/?referer=wincustomize) | mesma página/família do R09 | Não contar como 11º aplicativo nem duplicar requisitos. |
| R11 | [HeyyCzer/windows-dynamic-island](https://github.com/HeyyCzer/windows-dynamic-island) | **REFERÊNCIA CENTRAL de layout/interação**: música, vídeo pop-out, IA/Claude Code, busca de texto na tela, tabs, clipboard/shelf, GitHub, estatísticas e API local | **GPL-3.0-or-later** segundo README. Verificar `LICENSE`, dependências, atribuições e direitos. Se derivar código, obedecer GPL, disponibilizar código correspondente e avisos. |

### Fontes adicionais de comparação — nunca substituir as 11 entradas acima

- [WinIslandProject/WinIsland](https://github.com/WinIslandProject/WinIsland) — Rust, plugins, licença GPL-3.0 declarada; base arquitetural possível somente após compatibilidade jurídica.
- [zHeuzy2/WinIsland](https://github.com/zHeuzy2/WinIsland) — C# + SkiaSharp, webcam, tarefas, foco, notificações, HUDs e instalador; licença MIT declarada no README.
- [fttawa/IslandX](https://github.com/fttawa/IslandX) — alternativa a verificar separadamente para movimento/visual, não confundível automaticamente com WinIsland-X.
- [Documentação oficial Win32](https://learn.microsoft.com/windows/win32/), [Windows App SDK](https://learn.microsoft.com/windows/apps/windows-app-sdk/), [Tauri](https://tauri.app/), [GitHub Actions](https://docs.github.com/actions), [GitHub Releases](https://docs.github.com/repositories/releasing-projects-on-github/about-releases).
- [Reddit r/desktops — relatos de conflitos com Seelen UI](https://www.reddit.com/r/desktops/comments/1rfppcs/any_seelen_ui_alternatives_that_look_similar/) — depoimentos anedóticos, não benchmarks; testar startup, suspensão e integração com shell.
- [Reddit r/windowsapps — relato do desenvolvedor Notchify](https://www.reddit.com/r/windowsapps/comments/1w7vwfh/notchify_dynamic_island_for_windows_just_got_its/) — alegações a verificar com métricas próprias, não transferir números de desempenho para nosso app.

### Regras de pesquisa para cada fonte

1. Abrir URL inicial, links internos de funcionalidades, documentação, FAQ, downloads, versões, changelog, privacidade, README, `LICENSE`, contribuição e política de segurança.
2. Capturar nome exato, autoria, domínio oficial, data, link permanente, release, commit SHA, licenciamento e limitações; screenshot apenas para uso interno de análise e com atribuição.
3. Para GitHub: revisar README, tags, Releases, Issues abertas/fechadas, Discussions, PRs, testes existentes, exemplos, organização de módulos e dependências. Jamais executar instaladores binários não verificados apenas para pesquisar.
4. Para fóruns: buscar Reddit, fóruns Stardock/Steam/Seelen, relatos de estabilidade, CPU/RAM, integrações com jogos e multi-monitor; registrar link, data, contexto e se relato é confirmado ou individual.
5. Para YouTube: localizar demos atuais por nome/versão; analisar descrição, data, áudio, legendas/transcrição disponíveis, gestos, timings de animação, estados visuais e possíveis inconsistências. Registrar título, canal, URL e **timestamps observados**. Não inventar falas ou timestamps de vídeo inacessível.
6. Procurar documentação Microsoft para qualquer API Windows citada. Conferir permissões de notificações, sessão de mídia, controle de volume, Bluetooth, OCR, captura, foco e compatibilidade Windows 10/11.
7. Anotar diferenças entre `funcionalidade anunciada`, `mostrada em vídeo`, `presente no código`, `compilável` e `verificada em execução real`. **Somente o último nível autoriza alegar funcionalidade testada.**
8. Separar fonte confiável (docs oficiais/código), média (README/issue/changelog do autor), limitada (página de terceiros/marketing) e anedótica (fórum). Nunca confundir métricas autoafirmadas com medição.

### Modelo mínimo por evidência

```yaml
id: R11-FEAT-001
fonte: https://github.com/HeyyCzer/windows-dynamic-island
pagina_especifica: README.md#features
coletado_em: 2026-11-18
commit_ou_versao: verificar_no_momento
categoria: musica
funcionalidade: controle_de_midias
origem_da_afirmacao: documentacao_do_autor
licenca_codigo: GPL-3.0-or-later_verificar
status_da_nossa_implementacao: nao_iniciado
status_do_nosso_teste: nao_testado
limites: verificar_Windows_GSMTC_e_players
observacoes: nao_significa_que_o_codigo_foi_reutilizado
```

---

## 04. ORDEM PARA O MODELO ORQUESTRADOR

> **A partir deste ponto, você é o ORQUESTRADOR TÉCNICO DO PROJETO ANDER FLOW PRISM ISLAND. Esta seção é um comando operacional à IA que receber o documento.**

Sua função não é apenas aconselhar: **planeje, pesquise, delegue, codifique, teste, revise, publique o que passou nos gates e reporte links reais.** Execute por incrementos verificáveis. Sua autoridade se limita às ferramentas realmente disponíveis e às permissões do usuário; não assuma acesso ao PC ou GitHub sem verificar.

### Instruções de decisão

1. **Primeiro faça inventário de ferramentas e skills** (ex.: `$codigo-profissional`, `$frontend-moderno`, `$backend-seguro`, `$fullstack-producao`, `$banco-dados-confiavel`, `$midia-visual-profissional`, se existirem/forem acessíveis; GitHub, Remote Desktop Commander, pesquisa web, repositório, CI). Se estiverem indisponíveis, siga os critérios técnicos equivalentes sem fingir execução.
2. Escolha **uma IA principal**: GPT-6.2 Astra (caso disponível), Claude Opus, Grok ou outro modelo selecionado. Não presuma capacidades especiais apenas pelo nome do modelo; use as ferramentas efetivamente presentes na sessão.
3. Gere `docs/planejamento/PLANO_MESTRE.md`, matriz de referência, ADRs, backlog com prioridades, owners, estados e critérios de aceite. Comece implementação **na mesma sessão** quando ferramentas permitirem.
4. Antes da primeira alteração, confirme qual repositório/pasta existe; preserve dados e `main` existente, nunca force-push e nunca apagar código de outro trabalho. Para novo repo autorizado, crie README, LICENSE juridicamente compatível, CONTRIBUTING, SECURITY, roadmap, templates e CI.
5. Para tarefas independentes, distribua a agentes de especialidade. Cada agente recebe escopo, branch, interfaces, limites, testes e saída obrigatória. Não podem editar o mesmo arquivo sem coordenação. Faça revisão cruzada com agentes de QA/segurança/design.
6. Use TDD quando envolver lógica: teste falhando → implementação mínima → teste passando → refatoração → CI → evidência visual/manual quando aplicável. Para overlays e animações, complemente com automação de UI, screenshots e avaliação humana, sem declarar testes só com mocks.
7. Atualize `docs/ACOMPANHAMENTO.md`, `docs/backlog/TAREFAS.csv` ou JSON e GitHub Project/Issues em toda atualização real. Todas as tarefas devem permanecer rastreáveis mesmo após reinício ou mudança de modelo.
8. Gere instalador/portátil Windows prioritariamente. **Não gerar APK Android como desvio de escopo**. Integração Android/iPhone por QR poderá existir dentro de um módulo Windows; aplicativo mobile nativo só mediante pedido posterior.
9. Se uma etapa falhar, diagnostique, preserve logs e retome da próxima ação concreta. Não marcar pendências como concluídas apenas para encerrar uma resposta. Sem execução em segundo plano, continue quando houver uma sessão ativa ou automação explicitamente criada e confirmada.
10. Ao fornecer links, diferencie `proposto`, `criado`, `build em CI`, `release em rascunho`, `release publicado`, `download verificado`, `teste real no PC`.

### Primeiros comandos de decisão, conceitualmente

```text
A. Detectar ferramentas, conexões e permissões acessíveis.
B. Revalidar as referências R01–R11 e coletar matriz de funções/licenças.
C. Definir caminho jurídico/técnico: fork GPL comprovadamente compatível OU código original independente.
D. Verificar nome único e criar (se autorizado/acessível) repo Ander-Flow-Prism-Island.
E. Inicializar estrutura + CI + checklist + ADR 001.
F. Implementar primeira fatia vertical: app abre > tray > ilha aparece > hover/click > tema > player real > ocultação fullscreen > instalador.
G. Testar em Windows real; capturar evidências; corrigir; versionar e publicar somente se passar nos gates.
H. Atualizar checklist, issue, PR e links; escolher próxima fatia sem perder trabalho anterior.
```

## 05. MALHA DE AGENTES — ORQUESTRAÇÃO PARALELA COM RESPONSABILIDADE

O orquestrador não deve repassar um pedido genérico de "faça o projeto". Cada agente deve possuir **ID, especialidade, entrada, branch/worktree, saídas concretas, prazo por etapa sem prometer entrega assíncrona, testes, risco e revisor**. Trabalho paralelo só quando não houver conflito de diretórios. Cada papel abaixo pode ser executado por modelo distinto (GPT, Claude, Grok etc., conforme acesso real) ou por uma mesma IA em turnos separados, registrando o que efetivamente ocorreu.

| Agente | Especialidade / posse principal | Entrega obrigatória | Revisor independente |
|---|---|---|---|
| A00 | Orquestrador/arquitetura | roadmap, dependências, decisões ADR, integração, prioridades, relatório de evidências | A16 |
| A01 | Pesquisa e inteligência de fontes | relatório R01–R11 + Reddit/YouTube/fóruns + matriz confiabilidade | A15 |
| A02 | Licenças, compliance e supply chain | inventário de licenças, SBOM, atribuições, decisões de reutilização | A14 |
| A03 | Diretor visual Ander Flow | tokens, Figma/Storybook opcional, componentes e auditoria visual | A17 |
| A04 | UX e acessibilidade | estados, fluxos, teclado, leitor de tela, redução de movimento | A03 |
| A05 | Frontend React/TypeScript | cápsula, launcher, abas, configurações, temas, layouts | A17 |
| A06 | Animações/renderer | springs, interpolação, compositor, redução de render em idle, benchmark | A17 |
| A07 | Windows nativo, Win32 e Tauri | janelas overlay, click-through, tray, monitor/DPI, autostart, fullscreen | A18 |
| A08 | Mídia/áudio | GSMTC, progressos, controles, visualizador, Spotify/browser e fallback | A18 |
| A09 | Notificações e clipboard | WinRT/identidade/permissões, histórico opt-in, privacidade | A14 |
| A10 | Dados locais e plugins | armazenamento, configurações, migrations, API localhost, SDK | A14 |
| A11 | Integrações externas | calendário, GitHub, Claude Code, IA/LLM, meteorologia, downloads | A14 |
| A12 | Shell/dock/desktop | widgets, gerenciador leve de janelas, wallpapers e integração opcional | A07 |
| A13 | Build/release/CI | pipelines Windows, empacotamento, assinatura quando disponível, release | A16 |
| A14 | Segurança e privacidade | ameaças, permissões, threat model, tokens, segurança API e updater | A02 |
| A15 | Benchmark e pesquisa comparativa | testes de alternativas, limites de fonte e custo/performance | A01 |
| A16 | QA funcional/E2E | matriz Windows, instalação, regressão, evidências e critérios de bloqueio | A18 |
| A17 | QA visual/performance | screenshots, DPI, ultrawide, frametime, memória, microinterações | A03 |
| A18 | Revisor integrador/red team | contratos, concurrency, regressão, riscos críticos, readiness final | A00 |
| A19 | Documentação e localização | ajuda PT-BR, README, guias de instalação/remoção e changelog | A16 |
| A20 | GitHub/Product operations | issues, labels, PRs, projetos, checklist versionado, links | A00 |

### Contrato genérico para despachar a cada agente

```yaml
id: T-0001
agente_responsavel: A07
objetivo: Implementar posicionamento confiável da ilha em monitores de DPI distinto
contexto:
  projeto: Ander Flow Prism Island
  versao_alvo: 0.1.0
  stack_aprovada: Tauri_React_TS_Rust
escopo:
  arquivos_permitidos:
    - apps/desktop/src-tauri/src/janelas/
    - apps/desktop/src-tauri/src/monitores/
  arquivos_proibidos:
    - docs/LICENCAS_TERCEIROS.md
    - packages/ui/src/tema/
interfaces_esperadas:
  - obterMonitores(): Monitor[]
  - posicionarIlha(monitorId, ancora, escala): Resultado
criterios_de_aceite:
  - funciona_em_100_125_150_200_por_cento_DPI
  - recupera_apos_desligar_monitor_ou_alterar_resolucao
  - nao_captura_mouse_fora_da_area_visivel
  - fallback_ao_monitor_principal_se_monitor_removido
obrigatorio:
  - testes_unitarios
  - teste_integracao
  - log_de_validacao_ou_instrucoes_de_teste_manual_reprodutiveis
  - commit_sha
  - link_da_PR
  - atualizacao_checklist
revisor: A18
status: a_fazer
```

### Regras de isolamento

- A00 mantém contratos e prioridades; agentes **não** alteram simultaneamente `package.json`, `Cargo.toml`, configuração de CI ou tokens globais sem fila de integração.
- Use **Git worktrees/branches por tarefa** para paralelismo. Nome: `feat/T-0042-ilha-media`, `fix/T-0071-wakeup`, `docs/T-0010-auditoria-fontes`.
- A05 não implementa APIs Windows no renderer; A07 não toma decisões estéticas sem consultar A03; A11 não introduz chamadas de rede sem aprovação de A14.
- A13 não altera licenças ou remove checks para fazer CI passar. A16 bloqueia release por falha P0. A02 bloqueia distribuição incompatível com licença.
- Agente que identificar limitação reabre a tarefa com evidência, cria teste de regressão quando aplicável e devolve ao owner original.
- Nenhum agente valida exclusivamente o próprio trabalho em algo crítico. Revisão cruzada é mandatória.

### Rodada de execução recomendada

```text
RODADA 0: A01 + A02 + A15 pesquisam paralelamente; A00 prepara ADRs.
RODADA 1: A03 + A04 definem UI; A07 prototipa overlay; A13 inicializa CI; A20 cria rastreio.
RODADA 2: A05 + A06 entregam cápsula; A08 entrega mídia; A10 prepara configurações.
RODADA 3: A16 + A17 + A18 testam em ambiente real e corrigem regressões.
RODADA 4: A09 + A11 + A12 entram em fatias independentes, reusando core aprovado.
RODADA N: benchmark → funcionalidade → testes → release → checklist → próxima prioridade.
```

### Protocolo de comunicação entre agentes

Cada mensagem deve ter: `Tarefa`, `O que mudou`, `Arquivos`, `API/contrato`, `Testes executados`, `Resultado`, `Problemas`, `Commit/PR`, `Evidências`, `Próximo passo`, `Atualização de status`. Não produzir diários prolixos nem planos que substituam código. Se não houver subagentes reais, registrar `papel exercido na mesma sessão` em vez de alegar paralelismo.

---

## 06. POLÍTICA DE LICENCIAMENTO E ESTRATÉGIA DE REUTILIZAÇÃO

### Escolher UM caminho e documentá-lo antes de importar código

**Caminho A — derivação do HeyyCzer, caso as condições sejam aceitas:**

1. Inspecionar `LICENSE`, avisos, dependências, direitos sobre assets, licença do plugin SDK e software de terceiros.
2. Se de fato copiar, traduzir, modificar ou derivar código coberto por GPL-3.0-or-later, usar licença compatível, preservar avisos e atribuições, disponibilizar o código-fonte correspondente ao binário distribuído e cumprir demais obrigações da licença.
3. Documentar fork upstream, commit SHA de base, alterações, avisos e arquivos incorporados; identificar onde assets possuem regras próprias.
4. Não insinuar que o app é oficial do HeyyCzer, Apple, Stardock, Spotify, Seelen ou Microsoft.
5. Reutilização de projetos MIT/Apache em derivação deve respeitar termos e inclusão de avisos; GPL em combinação exige avaliação caso a caso por licença e modalidade de integração.

**Caminho B — produto independente (padrão seguro quando houver dúvida):**

1. Estudar interfaces e comportamento em documentação/demos, projetar uma especificação própria, implementar do zero com bibliotecas licenciadas apropriadamente e ativos originais.
2. Não copiar arquivos CSS, componentes TSX, shaders, arte, layouts pixel-a-pixel como reprodução de obra protegida, strings extensas, branding nem trechos fechados de aplicativos pagos.
3. O fato de uma ideia funcional ser pública **não autoriza** copiar implementação proprietária.
4. Recursos de origem não verificável permanecem **inspiração de produto**, não dependência de código.

**Critério de decisão:** o usuário deseja fortemente o visual e comportamento do HeyyCzer. Se a derivação GPL for viável e adequada, pode ser mais eficiente aproveitar legalmente o código com atribuição. Caso o objetivo seja manter licença independente incompatível ou haja incertezas sobre assets/dependências, optar por implementação original inspirada na experiência, preservando o idioma visual Ander Flow. Não prometer licença MIT por padrão antes da auditoria.

### Checklist jurídico/supply chain por dependência

- Identificação, link oficial, versão/hash, autor, licença, textos NOTICE, origem do código e finalidade.
- Permissão para redistribuir código binário, fontes, ícones, shaders, bibliotecas e fontes tipográficas.
- Dependências transientes, vulnerabilidades conhecidas, build reproduzível onde viável e SBOM atualizado.
- Autenticidade do download, checksum e verificação de assinatura quando houver.
- Separação de serviços comerciais de ferramentas open-source; APIs com termos específicos (Spotify, Discord, IA, reconhecimento de música, lyrics, mapas, clima).
- Política para remover contribuições problemáticas antes de distribuir release.

**Arquivo obrigatório:** `docs/LICENCAS_TERCEIROS.md` com tabela `origem | versão | licença | arquivo LICENSE | finalidade | compatibilidade | decisão | responsável | data`.

---

## 07. ARQUITETURA RECOMENDADA — DESKTOP PRIMEIRO

### Stack padrão proposta

- **Desktop:** Tauri 2.x **desde que** o agente valide sua versão compatível atual, WebView2, permissões e suporte Windows. Rust no backend nativo; React + TypeScript + Vite na UI. A escolha é consistente com a referência HeyyCzer, mas não isenta de benchmark.
- **Windows interop:** Win32, WinRT/Windows App SDK, GSMTC, notificações e Desktop Window Manager, por bindings Rust bem encapsulados; C#/.NET sidecar somente se houver justificativa e impacto medido.
- **CSS:** tokens e módulos CSS separados por componente, com motion declarativa onde simples. Código de interface, lógica de estado e estilos em arquivos próprios. Identificadores podem seguir convenções exigidas pelas linguagens/SDKs; documentação e textos orientativos em PT-BR.
- **Estado:** máquina de estados explícita para a ilha e módulos; store tipada com persistência versionada. Sincronização por eventos; desacoplamento entre polling e UI.
- **Banco local:** SQLite com migrações verificadas para atividades, opções e histórico não sensível; dados altamente sensíveis em Windows Credential Manager/DPAPI quando apropriado; memória apenas para dados descartáveis.
- **Testes:** Vitest/React Testing Library, Playwright para UI e fluxos, `cargo test` para Rust, testes Windows com runner nativo e scripts de smoke test pós-instalação. Testes visuais com baseline controlado.
- **Empacotamento:** `.exe` instalador + `.zip` portátil. Avaliar MSI/MSIX somente quando requisitos de permissões/identidade do Windows exigirem; não instalar silenciosamente componentes privilegiados.
- **Integrações:** SDK/API local em localhost, endpoints autenticados ou capacidade por sessão; conectores externos opt-in, timeout e fallback.

### ADR obrigatório para validar alternativa nativa

Antes de congelar Tauri, o arquiteto deve comparar pelo menos:

1. Tauri + Rust + React (flexibilidade e manutenção de UI).
2. .NET 8/10 + WPF/WinUI 3 + render customizado (APIs nativas e overhead).
3. Rust + Skia/wgpu (maior controle gráfico, custo de complexidade e acessibilidade).

Avaliar cold start, RAM idle, CPU idle, uso GPU, overlay click-through, acessibilidade, blur, auto-hide fullscreen, SDK, integração multimídia, facilidade de updates e manutenção. Registrar medições ou `não medido`, sem inventar valores. Arquivar `docs/arquitetura/ADR-001-stack-desktop.md` com decisão, trade-offs e plano de reversão.

### Diagrama de responsabilidades

```text
Windows 10/11
  ├── API Nativas (Win32, WinRT, GSMTC, DWM, clipboard, notificações)
  │     ↓ eventos e permissões explícitas
  ├── Núcleo Rust / Tauri
  │     ├── Gerência de overlay, DPI, monitores, foco e fullscreen
  │     ├── Gerenciador de módulos (ciclo de vida, capabilities, event bus)
  │     ├── Serviços nativos (mídia, captura, sistema, Bluetooth, etc.)
  │     ├── Segurança (cofre, validação, rate limit, acesso local)
  │     ├── Dados (SQLite + migrations + caches + preferências)
  │     ├── Integrações sob consentimento (GitHub, IA, agenda, clima)
  │     └── Atualizador assinado / diagnóstico / recuperação
  │            ↓ IPC tipado, validado, com escopo mínimo
  └── Frontend React / TypeScript
        ├── Máquina de estados da ilha
        ├── Design system Ander Flow e tokens
        ├── Cápsula + atividade + peeks + painel + launcher
        ├── Componentes e módulos independentes
        ├── Configurações, permissões e acessibilidade
        └── Logs não sensíveis / erro / estado offline
```

### Regras de dependências

- Módulo de mídia não conhece CSS do launcher.
- Plugin de clima não pode ler clipboard.
- Eventos de sistema não devem depender de rede.
- API do renderer não executa comandos do sistema arbitrários, nem fornece shell genérico com entrada não sanitizada.
- Interrupção de módulo não pode derrubar o processo inteiro; UI com `ErrorBoundary`, backend com tratamento de erro e circuit breaker.
- Features incompletas não são registradas como prontas no manifest; flags internas são `experimental` com texto honesto.
- Features dependentes de Windows 11 ou builds específicos devem declarar compatibilidade e fallback.

### Estrutura de pastas detalhada sugerida

```text
Ander-Flow-Prism-Island/
├── .github/
│   ├── ISSUE_TEMPLATE/
│   │   ├── bug.yml
│   │   ├── melhoria.yml
│   │   └── funcionalidade.yml
│   ├── PULL_REQUEST_TEMPLATE.md
│   ├── CODEOWNERS
│   └── workflows/
│       ├── validar-pr.yml
│       ├── build-windows.yml
│       ├── auditoria-seguranca.yml
│       ├── versao-release.yml
│       └── nightly-experimental.yml
├── apps/
│   └── desktop/
│       ├── src/
│       │   ├── app/
│       │   │   ├── App.tsx
│       │   │   ├── maquina-de-estados.ts
│       │   │   └── inicializacao.ts
│       │   ├── ilha/
│       │   │   ├── IlhaDinamica.tsx
│       │   │   ├── IlhaDinamica.module.css
│       │   │   ├── EstadosDaIlha.ts
│       │   │   └── testes/
│       │   ├── modulos/
│       │   │   ├── musica/
│       │   │   ├── notificacoes/
│       │   │   ├── area-transferencia/
│       │   │   ├── bandeja-arquivos/
│       │   │   ├── calendario/
│       │   │   ├── foco-temporizadores/
│       │   │   ├── busca-tela/
│       │   │   ├── inteligencia-artificial/
│       │   │   ├── agentes/
│       │   │   ├── github/
│       │   │   ├── sistema/
│       │   │   ├── conectividade/
│       │   │   ├── clima/
│       │   │   ├── gravador/
│       │   │   ├── celulares/
│       │   │   ├── downloads/
│       │   │   └── ferramentas/
│       │   ├── personalizacao/
│       │   │   ├── dock/
│       │   │   ├── barra-superior/
│       │   │   ├── widgets/
│       │   │   ├── janelas/
│       │   │   └── papeis-de-parede/
│       │   ├── configuracoes/
│       │   ├── infraestrutura/
│       │   ├── i18n/
│       │   │   ├── pt-BR.json
│       │   │   └── en-US.json
│       │   └── testes/
│       ├── src-tauri/
│       │   ├── capabilities/
│       │   ├── src/
│       │   │   ├── main.rs
│       │   │   ├── comandos/
│       │   │   ├── janelas/
│       │   │   ├── monitores/
│       │   │   ├── audio/
│       │   │   ├── midia/
│       │   │   ├── notificacoes/
│       │   │   ├── clipboard/
│       │   │   ├── captura/
│       │   │   ├── plugins/
│       │   │   ├── integracoes/
│       │   │   ├── armazenamento/
│       │   │   ├── atualizador/
│       │   │   ├── inicializacao/
│       │   │   └── seguranca/
│       │   └── tauri.conf.json
│       └── package.json
├── packages/
│   ├── ui/
│   │   └── src/{componentes,estilos,tokens,icones,animacoes}/
│   ├── contratos/
│   │   └── src/{eventos,modulos,apis,tipos}/
│   ├── sdk-plugins/
│   │   └── src/{manifest,permissoes,helpers,testes}/
│   └── ferramentas-dev/
├── scripts/
│   ├── iniciar-desenvolvimento.ps1
│   ├── validar-ambiente.ps1
│   ├── testes-windows.ps1
│   ├── empacotar.ps1
│   └── conferir-versao.ps1
├── tests/
│   ├── e2e/
│   ├── smoke/
│   ├── acessibilidade/
│   ├── performance/
│   ├── visuais/
│   └── fixtures/
├── docs/
│   ├── ACOMPANHAMENTO.md
│   ├── PAINEL_DE_ENTREGA.md
│   ├── LICENCAS_TERCEIROS.md
│   ├── REFERENCIAS_E_EVIDENCIAS.md
│   ├── README_DESIGN_SYSTEM.md
│   ├── GUIA_INSTALACAO.md
│   ├── GUIA_DESINSTALACAO.md
│   ├── GUIA_SOLUCAO_PROBLEMAS.md
│   ├── arquitetura/{ADR-001-stack-desktop.md,ADR-002-licenca.md,ADR-003-plugins.md}
│   ├── pesquisa/{fontes.md,reddit.md,youtube.md,issues.md,matriz-funcionalidades.md}
│   ├── planejamento/{PLANO_MESTRE.md,ROADMAP.md,DEPENDENCIAS.md}
│   ├── backlog/{TAREFAS.csv,TAREFAS.json}
│   ├── testes/{MATRIZ_WINDOWS.md,RESULTADOS.md,EVIDENCIAS.md}
│   └── versoes/{v0.1.0.md,v0.1.1.md,...}
├── assets/
│   └── originais/{icones,logo,temas,sons-opcionais}/
├── .editorconfig
├── .gitignore
├── AGENTS.md
├── CLAUDE.md
├── CONTRIBUTING.md
├── SECURITY.md
├── CHANGELOG.md
├── LICENSE
├── README.md
└── package.json
```

**Observação:** nomes de pasta em português são preferidos para features, documentação e scripts; `src`, `package.json`, arquivos de configuração e diretórios exigidos por frameworks mantêm os nomes técnicos. Árvore é objetivo arquitetural, **não prova da existência dos arquivos**.

---

## 08. NÚCLEO DA ILHA: ESTADOS, EVENTOS E PRIORIDADES

### Máquina de estados obrigatória

```text
OCULTA (fullscreen/pausa/monitor indisponível)
   ↕ condição de exibição
RECOLHIDA (estática sem consumir frames desnecessários)
   ├── MEDIA_ATIVA (arte, título e progresso resumidos)
   ├── ATIVIDADE_ATIVA (download/build/timer/call)
   ├── PREVIA (notificação breve com expiração)
   └── EXPANDINDO → EXPANDIDA (módulo aberto)
                       ├── FIXADA (não fecha ao sair o mouse)
                       ├── MODAL_PERMISSAO (foco explícito)
                       ├── GRID_MODULOS
                       └── RECOLHENDO → RECOLHIDA
```

**Eventos mínimos:** `MOUSE_ENTER`, `MOUSE_LEAVE`, `CLICK`, `DOUBLE_CLICK`, `ESC`, `HOTKEY`, `MEDIA_CHANGED`, `MEDIA_ENDED`, `NOTIFICATION_RECEIVED`, `ACTIVITY_STARTED`, `ACTIVITY_UPDATED`, `ACTIVITY_ENDED`, `FULLSCREEN_ENTER`, `FULLSCREEN_EXIT`, `MONITOR_CHANGED`, `DPI_CHANGED`, `THEME_CHANGED`, `PLUGIN_ERROR`, `APP_SUSPEND`, `APP_RESUME`, `LOW_POWER`, `SETTINGS_CHANGED`, `PERMISSION_CHANGED`.

### Regras de precedência

1. **Segurança/privacidade e permissão de sistema** prevalecem: nunca abrir webcam/microfone/clipboard sem consentimento previsto.
2. Avisos críticos do próprio aplicativo (erro real de gravação, captura, baixa bateria) podem preceder música, sem spam.
3. Atividades persistentes (gravação, upload, foco, chamada) conservam sua identificação e controle; eventos temporários usam fila e prioridade.
4. Música ocupa a cápsula enquanto ativa; uma notificação não deve perder o estado do player.
5. Chamadas de voz/gravação têm botão claro de parar, se integração real existir.
6. Dois eventos simultâneos não devem piscar nem disputar foco; utilizar scheduler e coalescência por categoria.
7. Perder o foco não deve fechar painel em que usuário está clicando/arrastando.
8. Em tela cheia de jogo, padrão `ocultar completamente`, sem overlay que prejudique anti-cheat ou captura. Modo alternativo por app deve ser explícito.
9. Ao suspender o Windows, congelar timers visuais e reconciliar relógio de parede ao voltar, sem liberar notificações vencidas em enxurrada.

### Modelo de evento tipado (especificação, não código de produção)

```ts
type TipoEvento =
  | 'midia' | 'notificacao' | 'temporizador' | 'download'
  | 'gravacao' | 'chamada' | 'sistema' | 'agente' | 'plugin';

type EventoIlha = {
  id: string;
  tipo: TipoEvento;
  titulo: string;
  descricao?: string;
  prioridade: number;
  criadoEm: string; // ISO-8601
  expiraEm?: string;
  progresso?: number; // 0..1
  acoes?: { id: string; titulo: string; permissao?: string }[];
  origem: string;
  privacidade: 'publico' | 'sensivel' | 'oculto';
};
```

Implementar deduplicação, cancelamento, coalescência, queue limits, debounce, timeout, logs não sensíveis e testes de transição. Não incluir HTML arbitrário nos eventos. `titulo` e `descricao` precisam escapar conteúdo antes de renderizar; nunca executar comandos recebidos da interface ou de localhost sem validação/autorização.

### API para extensões locais

Endpoints propostos (**não afirmar compatibilidade binária com outras APIs até testar**):

```text
GET    /v1/status
POST   /v1/atividades
PATCH  /v1/atividades/{id}
DELETE /v1/atividades/{id}
POST   /v1/notificacoes
GET    /v1/modulos
GET    /v1/saude
```

Requisitos: bind `127.0.0.1` e/ou pipe local seguro; autenticação/token de sessão ou capacidade por app; proteção contra requisições cross-site ao localhost (validar `Origin`, `Host`, CORS, CSRF e headers); rate limit; JSON schema; limites de tamanho; logs auditáveis sem dados sensíveis; retorno claro e versionamento. Sem porta aberta em `0.0.0.0` por padrão. O endpoint HeyyCzer `http://127.0.0.1:5199` foi identificado na documentação do original, mas **não reservar esta porta sem verificar conflito**, nem copiar endpoints sem decisão explícita.

---

## 09. PERSONALIZAÇÃO DO WINDOWS — MÓDULO OPCIONAL E REVERSÍVEL

O usuário quer também modificar a aparência do Windows com qualidade premium; **não basta fazer uma cápsula**. Entretanto, personalizar janelas, taskbar e shell tem risco superior. Divida em níveis, com configuração e rollback.

### Nível 1: seguro (não altera componentes internos do Windows)

- Dock original Ander Flow com apps fixados, apps abertos, miniaturas, badges, arrastar e soltar, contextual, auto-hide, posicionamento por monitor.
- Barra discreta de informações: relógio, calendário, CPU/RAM, rede, som, Wi-Fi, bateria quando disponível, botões reais.
- Widgets arrastáveis na área de trabalho, temas globais e presets exportáveis, atalhos e workspaces de configurações.
- Painel de ações rápidas para abrir configurações oficiais do Windows sem fingir API privilegiada.
- Wallpapers com imagens/vídeos locais e HTML interativo **somente em sandbox**, com pausa automática em fullscreen e economia de recursos; não reproduzir vídeo protegido sem direitos.
- Personalização da própria Ilha, não de outras janelas: espessura, blur, contorno, sombra, som, hover/click, persistência, monitores.

### Nível 2: integração com shell (opt-in, bloqueada por QA)

- Estilização da taskbar por APIs suportadas quando possível, sem substituir/ocultar a barra original silenciosamente.
- Gerenciador de arranjo de janelas com presets `duas-colunas`, `três-colunas`, `grid`, `ultrawide-3`, `foco`, com undo e respeito a mínimos de janela.
- Alternância personalizada de janelas/desktop virtual sem interferir com Alt+Tab global por padrão.
- Menu inicial/launcher próprio como aplicativo separado; não tentar substituir arquivos protegidos ou reiniciar o Explorer sem autorização.
- Skin de molduras de outras janelas apenas se houver mecanismo suportado, compatível com versões e restaurável; se tecnicamente inviável sem injeções perigosas, declarar limitação e oferecer aplicação de temas no app/dock.
- Modo `Compatibilidade com Seelen UI/MyDockFinder/WindowBlinds`: detectar sobreposições, coordenar posição e oferecer desligar o módulo conflitante, **não** modificar instalações de terceiros.

### Rollback obrigatório

1. Botão `Restaurar aparência padrão do Windows` que reverta somente modificações realizadas pelo app.
2. Backup versionado de configurações originais antes de alterações persistentes.
3. Modo seguro iniciado com flag `--safe-mode`, sem módulos de shell nem plugins.
4. Se o app travar, desktop/taskbar padrão continua funcional.
5. Desinstalação remove inicialização própria e restaura mudanças sob controle do app; dados do usuário devem ter opção de manter ou excluir.
6. Não modificar políticas de execução PowerShell em escala global, não desativar Defender/UAC/SmartScreen e não abrir terminais visíveis periodicamente.

---

## 10. INTEGRAÇÕES REAIS — ESPECIFICAÇÕES MÍNIMAS

### 10.1 Mídia (MVP)

- Usar API de sessão global de mídia do Windows (`GlobalSystemMediaTransportControlsSessionManager`, GSMTC), com controle da sessão ativa e seleção de sessão quando coexistirem Spotify, navegador, Apple Music ou VLC. Verificar casos em que player não expõe sessão/seek/metadados.
- Ler título, artista, álbum, capa, estado, duração e posição; tratar dados nulos e imagem faltante.
- Implementar play/pause, anterior, próximo, seek quando permitido, mute/volume quando API autorizada, indicador de saída de áudio.
- Evitar polling intenso: preferir eventos de sessão, throttling de progresso, pausas em idle e suspensão do app.
- Visualizador de áudio com consentimento da captura do sistema e fallback animado não enganoso. Não dizer "espectro em tempo real" quando só existir animação decorativa.
- Letras sincronizadas são extensão opt-in: fonte licenciada, termos de serviço, idioma, precisão, cache e privacidade; não fazer scraping proibido.
- Vídeo YouTube em mini player exige verificação de termos, DRM, autoplay e integração real; nunca baixar/reproduzir conteúdo protegido por meios não autorizados.

### 10.2 Notificações Windows (P1)

- Verificar suporte Windows Notification Listener, identidade MSIX/registro e solicitações de permissão; a implementação original HeyyCzer documenta registro especial e modo de desenvolvedor para alguns cenários.
- Implementar permissão explicada em PT-BR, status real, opção `Abrir configurações oficiais`, fila de previews, histórico local opt-in, redigir dados sensíveis na tela bloqueada.
- Não contornar permissões com interceptação não autorizada ou hooks invasivos; fornecer alternativa local (`/v1/notificacoes`) quando leitura global não for possível.

### 10.3 Clipboard e bandeja de arquivos (P1)

- Histórico local opt-in e configurável: texto, links, imagem, arquivo, favoritos, busca, fixar, excluir, arrastar, reabrir, limite e expiração.
- Ignorar dados reconhecidos como sensíveis sempre que houver mecanismo confiável; oferecer pausa rápida, lista de aplicativos excluídos e limpeza total; **não prometer detectar todas as senhas automaticamente**.
- Bandeja por **referências a caminhos**, sem copiar arquivos silenciosamente para o banco. Alertar se arquivo foi removido ou caminho inacessível.
- Sanitizar caminhos; proibir execução involuntária de atalhos, scripts e `.exe` por simples hover/drop; confirmação explícita antes de executar.

### 10.4 IA, agentes e ferramentas de dev (P2)

- Painel de status local para Claude Code e, **somente onde existirem APIs ou logs autorizados**, Codex/GPT, Grok, outras IAs e projetos do usuário. Não inventar integração só porque o nome está no menu.
- Mostrar agente, projeto, atividade atual, último passo não sensível, tempo decorrido, build/teste em curso, erro, aguardando aprovação e finalização.
- Expor integração com hooks locais somente com consentimento, backup e rollback de arquivos de configuração existentes, sem modificar credenciais manualmente.
- Solicitações de aprovação devem mostrar comando, caminho e efeitos; ações destrutivas exigem confirmação visível. Nunca autorizar automaticamente comandos de alto risco.
- Chat na ilha via provedor efetivamente conectado, opt-in, guardando chave em cofre; se indisponível, estado claro `Conecte um provedor`, sem resposta simulada ou texto `resposta local`.
- Módulo `GitHub` para issues, PRs, commits, workflows e releases com OAuth/CLI/token protegido; sem enviar propostas/PRs sem autorização explícita.

### 10.5 Buscar na tela e OCR (P2)

- Atalho configurável que captura tela/janela/recorte com consentimento, faz reconhecimento local por API Windows ou mecanismo aprovado, destaca resultados e copia texto.
- Suporte a múltiplos monitores, escala DPI, imagens e texto com acentos; pesquisa insensível a caixa e acentos quando apropriado.
- Não capturar tela ociosa, não persistir sem necessidade, não transmitir a servidor externo sem opt-in; botão de cancelamento e indicador visível.
- QR codes: somente abrir URLs após exibir destino, evitar execução automática de comandos ou importação de Wi-Fi desconhecido.

### 10.6 Sistema e conectividade (P1)

- CPU, RAM, disco, rede, GPU: métricas reais, com denominadores e unidades corretas, sem alegar suporte universal a todos os sensores.
- Monitorar volume e áudio de saída; troca de dispositivo apenas via mecanismo Windows suportado e testado.
- Bluetooth: nome/conectividade/bateria **somente quando dispositivo e APIs expuserem**, com tratamento para ausente e desconectado.
- Indicadores de bateria devem sumir em desktops sem bateria; eventos plug/unplug só em hardware compatível.
- Modo jogo impede overlay e polling pesado em tela cheia; políticas por app configuráveis.

### 10.7 Agenda, tempo, clima, foco e tarefas (P2)

- Calendário local completo, agenda por arquivo `.ics` e integração OAuth oficial quando possível. **Não exigir URL iCal privada** se o usuário prefere OAuth; nunca logar link secreto.
- Tempo/clima opt-in: localização manual primeiro, consentimento para geolocalização e cache offline; provedor documentado, limite de requisições e fonte de dados.
- Pomodoro, contagem regressiva, cronômetro, lembretes e tarefas persistentes com alarmes locais, mesmo após reinício quando possível, sem alarme falso.
- Agendar notificação contextual (pré-reunião) com fuso horário, horário de verão e pausa em `Não Perturbe`.

### 10.8 Comunicação e dispositivos (P3)

- Discord: funções de voz/chamada somente com integração oficial/autorizada, sem automatizar conta pessoal via self-bot ou scraping de token.
- Celular–PC por QR: transferência local autenticada, código de pareamento temporário, HTTPS local ou canal criptografado conforme viável, firewall mínimo, expiração, limite de tamanho e barra de progresso real.
- Monitorar downloads: priorizar integração por extensão de navegador **com consentimento e escopo mínimo**; não interceptar tráfego de todas as aplicações.
- Webcam/microfone e gravador de tela: permissões Windows, indicadores visíveis, caminho de salvamento escolhido e controles reais de pausa/parada. Nunca iniciar gravação automaticamente.


---

## 11. INVENTÁRIO DE FUNCIONALIDADES — CHECKLIST INICIAL RASTREÁVEL

**Importante:** os itens abaixo são uma **especificação de capacidades a investigar e implementar**, NÃO uma alegação de que o produto já as possui, nem de que todos os concorrentes listados anunciam cada item. O agente de pesquisa deve adicionar `fonte_exata`, `versão`, `status de evidência`, `licença`, `complexidade`, `necessidade de permissão`, `teste`, `commit` e `link da issue` ao backlog real. A coluna `Origem` identifica inspiração por grupo, não comprovação individual.

**Status permitidos:** `[ ] A FAZER`, `[~] EM ANDAMENTO`, `[x] FEITO+TESTADO`, `[!] ERRO/BLOQUEADO`, `[-] NÃO APLICÁVEL (justificado)`. Na versão inicial **todos estão A FAZER**. Um item não pode virar `[x]` por existir apenas em código, mock ou documentação; requer os testes especificados no módulo, evidência e revisão.

**Campos recomendados por item no backlog:** `ID`, `prioridade`, `owner`, `origens`, `evidencia_original`, `estado`, `subestado`, `critério_de_aceite`, `teste_automático`, `teste_real`, `commit`, `PR`, `versão`, `última_atualização`.

### 11.1 Ilhas, estados e comportamento — HEYYCZER COMO PRIORIDADE

Origem de referência: `R11 R07 R02 R04`. Prioridade padrão `P0` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-001` | `[ ] A FAZER` | Cápsula preta no topo central | P0 | `—` |
| `F-002` | `[ ] A FAZER` | Cápsula com borda Prisma Flow em laranja | P0 | `—` |
| `F-003` | `[ ] A FAZER` | Modo ilha flutuante sem notch pendurado | P0 | `—` |
| `F-004` | `[ ] A FAZER` | Expandir no hover com tolerância de borda | P0 | `—` |
| `F-005` | `[ ] A FAZER` | Expandir por clique | P0 | `—` |
| `F-006` | `[ ] A FAZER` | Expandir por atalho de teclado | P0 | `—` |
| `F-007` | `[ ] A FAZER` | Recolher com Escape | P0 | `—` |
| `F-008` | `[ ] A FAZER` | Fechar ao clicar fora sem roubar foco | P0 | `—` |
| `F-009` | `[ ] A FAZER` | Fixar painel aberto | P0 | `—` |
| `F-010` | `[ ] A FAZER` | Minimizar só o módulo atual | P0 | `—` |
| `F-011` | `[ ] A FAZER` | Retomar aba previamente usada | P0 | `—` |
| `F-012` | `[ ] A FAZER` | Reordenar abas por arrastar | P0 | `—` |
| `F-013` | `[ ] A FAZER` | Fixar ou desafixar módulos da barra | P0 | `—` |
| `F-014` | `[ ] A FAZER` | Grade de módulos não fixados | P0 | `—` |
| `F-015` | `[ ] A FAZER` | Contadores visíveis nos módulos | P0 | `—` |
| `F-016` | `[ ] A FAZER` | Voltar ao estado anterior sem jitter | P0 | `—` |
| `F-017` | `[ ] A FAZER` | Animação spring amortecida | P0 | `—` |
| `F-018` | `[ ] A FAZER` | Alteração fluida de largura por conteúdo | P0 | `—` |
| `F-019` | `[ ] A FAZER` | Prévia breve de evento relevante | P0 | `—` |
| `F-020` | `[ ] A FAZER` | Duas atividades simultâneas sem sobreposição | P0 | `—` |
| `F-021` | `[ ] A FAZER` | Fila e prioridade de eventos | P0 | `—` |
| `F-022` | `[ ] A FAZER` | Agrupar notificações repetidas | P0 | `—` |
| `F-023` | `[ ] A FAZER` | Ocultar em fullscreen/jogos | P0 | `—` |
| `F-024` | `[ ] A FAZER` | Ocultar em apresentações e vídeo fullscreen | P0 | `—` |
| `F-025` | `[ ] A FAZER` | Ocultar em apps excluídos | P0 | `—` |
| `F-026` | `[ ] A FAZER` | Restaurar quando sair de fullscreen | P0 | `—` |
| `F-027` | `[ ] A FAZER` | Modo não perturbe por horário | P0 | `—` |
| `F-028` | `[ ] A FAZER` | Captura de mouse limitada à ilha | P0 | `—` |
| `F-029` | `[ ] A FAZER` | Modo touch e trackpad | P0 | `—` |
| `F-030` | `[ ] A FAZER` | Acessibilidade por teclado | P0 | `—` |
| `F-031` | `[ ] A FAZER` | Posicionamento por monitor | P0 | `—` |
| `F-032` | `[ ] A FAZER` | Ancoragem superior esquerda/centro/direita | P0 | `—` |
| `F-033` | `[ ] A FAZER` | Ancoragem inferior e laterais opcional | P0 | `—` |
| `F-034` | `[ ] A FAZER` | Arrastar ilha quando não fixada | P0 | `—` |
| `F-035` | `[ ] A FAZER` | Salvar layout por perfil | P0 | `—` |
| `F-036` | `[ ] A FAZER` | Compatibilidade com escalas DPI distintas | P0 | `—` |

### 11.2 Temas, arte e microanimações

Origem de referência: `R11 R07 R04 R06`. Prioridade padrão `P0` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-037` | `[ ] A FAZER` | Tema Clássico Preto | P0 | `—` |
| `F-038` | `[ ] A FAZER` | Tema Prism Flow Laranja | P0 | `—` |
| `F-039` | `[ ] A FAZER` | Tema Vidro Fosco Escuro | P0 | `—` |
| `F-040` | `[ ] A FAZER` | Tema Fosco Claro | P0 | `—` |
| `F-041` | `[ ] A FAZER` | Tema Editorial Monocromático | P0 | `—` |
| `F-042` | `[ ] A FAZER` | Editor de cores com preview vivo | P0 | `—` |
| `F-043` | `[ ] A FAZER` | Editor de raio dos cantos | P0 | `—` |
| `F-044` | `[ ] A FAZER` | Borda fina e outline adaptativo | P0 | `—` |
| `F-045` | `[ ] A FAZER` | Opacidade e blur reguláveis | P0 | `—` |
| `F-046` | `[ ] A FAZER` | Grão visual muito sutil opt-in | P0 | `—` |
| `F-047` | `[ ] A FAZER` | Sombras equilibradas | P0 | `—` |
| `F-048` | `[ ] A FAZER` | Luz/brilho controlado sem neon | P0 | `—` |
| `F-049` | `[ ] A FAZER` | Gradiente animado opcional | P0 | `—` |
| `F-050` | `[ ] A FAZER` | Desligar glow e gradiente | P0 | `—` |
| `F-051` | `[ ] A FAZER` | Temas importáveis/exportáveis | P0 | `—` |
| `F-052` | `[ ] A FAZER` | Presets por usuário | P0 | `—` |
| `F-053` | `[ ] A FAZER` | Ativar tema claro/escuro automático | P0 | `—` |
| `F-054` | `[ ] A FAZER` | Seguir cor do sistema opcional | P0 | `—` |
| `F-055` | `[ ] A FAZER` | Reduzir movimento | P0 | `—` |
| `F-056` | `[ ] A FAZER` | Desativar som de interface | P0 | `—` |
| `F-057` | `[ ] A FAZER` | Transições reversíveis sem piscar | P0 | `—` |
| `F-058` | `[ ] A FAZER` | Estados hover/focus/pressed distintos | P0 | `—` |
| `F-059` | `[ ] A FAZER` | Skeleton para carregamento | P0 | `—` |
| `F-060` | `[ ] A FAZER` | Animações com 60/120 FPS configuráveis quando ativas | P0 | `—` |
| `F-061` | `[ ] A FAZER` | Sem renderização contínua quando idle | P0 | `—` |
| `F-062` | `[ ] A FAZER` | Animação de progresso sem números falsos | P0 | `—` |
| `F-063` | `[ ] A FAZER` | Aparência acessível em alto contraste | P0 | `—` |
| `F-064` | `[ ] A FAZER` | SVG autorais consistentes | P0 | `—` |
| `F-065` | `[ ] A FAZER` | Fontes com licença de redistribuição | P0 | `—` |
| `F-066` | `[ ] A FAZER` | Visualizador de tema em miniatura | P0 | `—` |

### 11.3 Música e áudio

Origem de referência: `R11 R07 R02 R03 R04 R05 R08`. Prioridade padrão `P0` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-067` | `[ ] A FAZER` | Detecção da sessão de mídia ativa no Windows | P0 | `—` |
| `F-068` | `[ ] A FAZER` | Trocar sessão entre Spotify e navegadores | P0 | `—` |
| `F-069` | `[ ] A FAZER` | Compatibilidade com Apple Music via GSMTC quando suportada | P0 | `—` |
| `F-070` | `[ ] A FAZER` | Compatibilidade com VLC via GSMTC quando suportada | P0 | `—` |
| `F-071` | `[ ] A FAZER` | Exibir música e artista na ilha recolhida | P0 | `—` |
| `F-072` | `[ ] A FAZER` | Exibir capa do álbum | P0 | `—` |
| `F-073` | `[ ] A FAZER` | Exibir duração e posição atual | P0 | `—` |
| `F-074` | `[ ] A FAZER` | Reproduzir/pausar | P0 | `—` |
| `F-075` | `[ ] A FAZER` | Faixa anterior/próxima | P0 | `—` |
| `F-076` | `[ ] A FAZER` | Buscar posição na faixa quando suportado | P0 | `—` |
| `F-077` | `[ ] A FAZER` | Lidar com sessão sem seeking | P0 | `—` |
| `F-078` | `[ ] A FAZER` | Controle de volume mestre | P0 | `—` |
| `F-079` | `[ ] A FAZER` | Mute/unmute | P0 | `—` |
| `F-080` | `[ ] A FAZER` | Selecionar dispositivo de saída compatível | P0 | `—` |
| `F-081` | `[ ] A FAZER` | Exibir identificação do player | P0 | `—` |
| `F-082` | `[ ] A FAZER` | Indicador de fones/alto-falantes | P0 | `—` |
| `F-083` | `[ ] A FAZER` | Mini equalizador decorativo rotulado como tal | P0 | `—` |
| `F-084` | `[ ] A FAZER` | Visualizador real de espectro após permissão | P0 | `—` |
| `F-085` | `[ ] A FAZER` | Visualizador espectro 6 bandas como opção | P0 | `—` |
| `F-086` | `[ ] A FAZER` | Cor ambiente derivada da capa opcional | P0 | `—` |
| `F-087` | `[ ] A FAZER` | Letras sincronizadas com fonte legal | P0 | `—` |
| `F-088` | `[ ] A FAZER` | Clique para ir à linha de letra quando permitido | P0 | `—` |
| `F-089` | `[ ] A FAZER` | Pin de widget de letra | P0 | `—` |
| `F-090` | `[ ] A FAZER` | Persistir preferência de player | P0 | `—` |
| `F-091` | `[ ] A FAZER` | Atualizar dados por eventos e sem polling abusivo | P0 | `—` |
| `F-092` | `[ ] A FAZER` | Mini player de vídeo com termos permitidos | P0 | `—` |
| `F-093` | `[ ] A FAZER` | Mini player always-on-top arrastável | P0 | `—` |
| `F-094` | `[ ] A FAZER` | Snapping do mini player nas bordas | P0 | `—` |
| `F-095` | `[ ] A FAZER` | Controle de intervalo de polling e power mode | P0 | `—` |
| `F-096` | `[ ] A FAZER` | Estado sem sessão com instrução útil | P0 | `—` |

### 11.4 Notificações, alertas e atividades

Origem de referência: `R11 R07 R02 R03 R05`. Prioridade padrão `P1` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-097` | `[ ] A FAZER` | Receber eventos do sistema pelo caminho permitido | P1 | `—` |
| `F-098` | `[ ] A FAZER` | Assistente de permissão de notificações | P1 | `—` |
| `F-099` | `[ ] A FAZER` | Notificações locais do próprio app | P1 | `—` |
| `F-100` | `[ ] A FAZER` | Prévia que desaparece com timeout | P1 | `—` |
| `F-101` | `[ ] A FAZER` | Fila de notificações concorrentes | P1 | `—` |
| `F-102` | `[ ] A FAZER` | Histórico opt-in com pesquisa | P1 | `—` |
| `F-103` | `[ ] A FAZER` | Agrupamento por aplicativo | P1 | `—` |
| `F-104` | `[ ] A FAZER` | Swipe/deslizar ou botão descartar | P1 | `—` |
| `F-105` | `[ ] A FAZER` | Abrir app de origem quando API permitir | P1 | `—` |
| `F-106` | `[ ] A FAZER` | Não mostrar corpo sensível na tela bloqueada | P1 | `—` |
| `F-107` | `[ ] A FAZER` | Progressos persistentes por ID | P1 | `—` |
| `F-108` | `[ ] A FAZER` | Atualizar progresso existente por ID | P1 | `—` |
| `F-109` | `[ ] A FAZER` | Cancelar atividade com comando real | P1 | `—` |
| `F-110` | `[ ] A FAZER` | Download com taxa e ETA real | P1 | `—` |
| `F-111` | `[ ] A FAZER` | Carga/descarga de bateria quando existir | P1 | `—` |
| `F-112` | `[ ] A FAZER` | Aviso de fone Bluetooth conectado | P1 | `—` |
| `F-113` | `[ ] A FAZER` | Aviso de bateria Bluetooth apenas se disponível | P1 | `—` |
| `F-114` | `[ ] A FAZER` | Alerta de CPU/RAM sustentada e fonte identificada | P1 | `—` |
| `F-115` | `[ ] A FAZER` | Barra de volume temporária | P1 | `—` |
| `F-116` | `[ ] A FAZER` | Indicador caps lock e num lock opt-in | P1 | `—` |
| `F-117` | `[ ] A FAZER` | Aviso de microfone/câmera em uso com fonte verificável | P1 | `—` |
| `F-118` | `[ ] A FAZER` | Não perturbe por aplicativo | P1 | `—` |
| `F-119` | `[ ] A FAZER` | Prioridade P0 vs rotina | P1 | `—` |
| `F-120` | `[ ] A FAZER` | API de notificação em localhost segura | P1 | `—` |
| `F-121` | `[ ] A FAZER` | Retomar atividade depois de reinício quando aplicável | P1 | `—` |

### 11.5 Clipboard e bandeja de arquivos

Origem de referência: `R11 R07 R02`. Prioridade padrão `P1` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-122` | `[ ] A FAZER` | Histórico de clipboard de texto opt-in | P1 | `—` |
| `F-123` | `[ ] A FAZER` | Histórico de imagens opt-in | P1 | `—` |
| `F-124` | `[ ] A FAZER` | Histórico de arquivos/links opt-in | P1 | `—` |
| `F-125` | `[ ] A FAZER` | Limite configurável de entradas | P1 | `—` |
| `F-126` | `[ ] A FAZER` | Retenção temporal configurável | P1 | `—` |
| `F-127` | `[ ] A FAZER` | Exclusão de aplicativos por lista | P1 | `—` |
| `F-128` | `[ ] A FAZER` | Pausa de monitoramento em um clique | P1 | `—` |
| `F-129` | `[ ] A FAZER` | Limpar histórico instantaneamente | P1 | `—` |
| `F-130` | `[ ] A FAZER` | Busca textual no clipboard | P1 | `—` |
| `F-131` | `[ ] A FAZER` | Fixar favoritos | P1 | `—` |
| `F-132` | `[ ] A FAZER` | Remover item individual | P1 | `—` |
| `F-133` | `[ ] A FAZER` | Copiar novamente com clique | P1 | `—` |
| `F-134` | `[ ] A FAZER` | Arrastar imagem para outro aplicativo | P1 | `—` |
| `F-135` | `[ ] A FAZER` | Arrastar arquivos de volta para Explorer | P1 | `—` |
| `F-136` | `[ ] A FAZER` | Miniatura de screenshot recente | P1 | `—` |
| `F-137` | `[ ] A FAZER` | Integrar screenshot capturada pelo Windows | P1 | `—` |
| `F-138` | `[ ] A FAZER` | Adicionar arquivo ao shelf por drag-and-drop | P1 | `—` |
| `F-139` | `[ ] A FAZER` | Adicionar pasta ao shelf por drag-and-drop | P1 | `—` |
| `F-140` | `[ ] A FAZER` | Shelf armazena referência não cópia oculta | P1 | `—` |
| `F-141` | `[ ] A FAZER` | Abrir item somente com ação explícita | P1 | `—` |
| `F-142` | `[ ] A FAZER` | Compartilhar por diálogo nativo quando suportado | P1 | `—` |
| `F-143` | `[ ] A FAZER` | Indicar item perdido ou inacessível | P1 | `—` |
| `F-144` | `[ ] A FAZER` | Enviar item à IA apenas por ação consentida | P1 | `—` |
| `F-145` | `[ ] A FAZER` | Auditoria de dados sensíveis e vazamento | P1 | `—` |
| `F-146` | `[ ] A FAZER` | Não disparar execução de script ao arrastar | P1 | `—` |

### 11.6 Claude Code, agentes, IA e ferramentas de dev

Origem de referência: `R11 R03 NOVO`. Prioridade padrão `P2` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-147` | `[ ] A FAZER` | Status de sessões Claude Code autorizadas | P2 | `—` |
| `F-148` | `[ ] A FAZER` | Identificação de projeto por sessão | P2 | `—` |
| `F-149` | `[ ] A FAZER` | Atividade atual com tipagem | P2 | `—` |
| `F-150` | `[ ] A FAZER` | Status aguardando permissão | P2 | `—` |
| `F-151` | `[ ] A FAZER` | Timer de sessão atual | P2 | `—` |
| `F-152` | `[ ] A FAZER` | Resumo de última solicitação não sensível | P2 | `—` |
| `F-153` | `[ ] A FAZER` | Contagem de respostas com fonte real | P2 | `—` |
| `F-154` | `[ ] A FAZER` | Contagem de tokens quando disponíveis | P2 | `—` |
| `F-155` | `[ ] A FAZER` | Gráfico de uso histórico com dados reais | P2 | `—` |
| `F-156` | `[ ] A FAZER` | Tempo até limite/reset quando exposto legalmente | P2 | `—` |
| `F-157` | `[ ] A FAZER` | Abrir projeto no VS Code via caminho validado | P2 | `—` |
| `F-158` | `[ ] A FAZER` | Abrir painel ao pedido de permissão opt-in | P2 | `—` |
| `F-159` | `[ ] A FAZER` | Autorizar/negar comando de baixo risco manualmente | P2 | `—` |
| `F-160` | `[ ] A FAZER` | Negar permanentemente ação por regra explícita | P2 | `—` |
| `F-161` | `[ ] A FAZER` | Restaurar hook anterior do Claude Code | P2 | `—` |
| `F-162` | `[ ] A FAZER` | Backup de settings antes de integração | P2 | `—` |
| `F-163` | `[ ] A FAZER` | Chat rápido por provedor realmente conectado | P2 | `—` |
| `F-164` | `[ ] A FAZER` | Resposta em streaming quando suporte existir | P2 | `—` |
| `F-165` | `[ ] A FAZER` | Anexar screenshot somente após consentimento | P2 | `—` |
| `F-166` | `[ ] A FAZER` | Anexar arquivos por drag-drop com confirmação | P2 | `—` |
| `F-167` | `[ ] A FAZER` | Estado IA offline e sem chave honesto | P2 | `—` |
| `F-168` | `[ ] A FAZER` | Integração opcional com Codex se acesso autorizado | P2 | `—` |
| `F-169` | `[ ] A FAZER` | Integração opcional com GitHub Copilot se API oficial | P2 | `—` |
| `F-170` | `[ ] A FAZER` | Suporte a GPT/Grok/Qwen como provedores quando APIs reais | P2 | `—` |
| `F-171` | `[ ] A FAZER` | Status de builds e CI no painel | P2 | `—` |
| `F-172` | `[ ] A FAZER` | Status de tarefas dos projetos Flow | P2 | `—` |
| `F-173` | `[ ] A FAZER` | Aprovação e retomada de tarefas sob controle | P2 | `—` |
| `F-174` | `[ ] A FAZER` | Sem leitura automática de credenciais das IAs | P2 | `—` |
| `F-175` | `[ ] A FAZER` | Não executar terminal arbitrário pelo chat | P2 | `—` |

### 11.7 Busca na tela, OCR, QR e captura

Origem de referência: `R11 R07`. Prioridade padrão `P2` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-176` | `[ ] A FAZER` | Hotkey para buscar texto na tela | P2 | `—` |
| `F-177` | `[ ] A FAZER` | Pesquisar texto em todos os monitores | P2 | `—` |
| `F-178` | `[ ] A FAZER` | Pesquisa em screenshot estático com permissão | P2 | `—` |
| `F-179` | `[ ] A FAZER` | OCR local offline quando disponível | P2 | `—` |
| `F-180` | `[ ] A FAZER` | Pesquisa sem diferenciar maiúsculas | P2 | `—` |
| `F-181` | `[ ] A FAZER` | Pesquisa sem diferenciar acentos | P2 | `—` |
| `F-182` | `[ ] A FAZER` | Destaque de ocorrências na tela | P2 | `—` |
| `F-183` | `[ ] A FAZER` | Ir à próxima ocorrência | P2 | `—` |
| `F-184` | `[ ] A FAZER` | Ir à ocorrência anterior | P2 | `—` |
| `F-185` | `[ ] A FAZER` | Atualizar busca após mudança de tela | P2 | `—` |
| `F-186` | `[ ] A FAZER` | Cancelar captura com Escape | P2 | `—` |
| `F-187` | `[ ] A FAZER` | Copiar texto de região selecionada | P2 | `—` |
| `F-188` | `[ ] A FAZER` | Copiar região como imagem | P2 | `—` |
| `F-189` | `[ ] A FAZER` | Salvar screenshot em caminho escolhido | P2 | `—` |
| `F-190` | `[ ] A FAZER` | Ler QR code em região | P2 | `—` |
| `F-191` | `[ ] A FAZER` | Exibir URL de QR antes de abrir | P2 | `—` |
| `F-192` | `[ ] A FAZER` | Isolamento de senhas/campos protegidos | P2 | `—` |
| `F-193` | `[ ] A FAZER` | Não persistir screenshot por padrão | P2 | `—` |
| `F-194` | `[ ] A FAZER` | Suporte a DPI 100–200% | P2 | `—` |
| `F-195` | `[ ] A FAZER` | Falha graciosa em tela protegida por DRM | P2 | `—` |

### 11.8 Calendário, clima, relógios, foco e tarefas

Origem de referência: `R11 R02 R03 R07`. Prioridade padrão `P2` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-196` | `[ ] A FAZER` | Relógio 12/24h | P2 | `—` |
| `F-197` | `[ ] A FAZER` | Calendário mês interativo | P2 | `—` |
| `F-198` | `[ ] A FAZER` | Selecionar dia e navegar mês | P2 | `—` |
| `F-199` | `[ ] A FAZER` | Número da semana | P2 | `—` |
| `F-200` | `[ ] A FAZER` | Contagem de dias até compromisso | P2 | `—` |
| `F-201` | `[ ] A FAZER` | Importar calendário .ics | P2 | `—` |
| `F-202` | `[ ] A FAZER` | Sincronizar Google Calendar com OAuth quando disponível | P2 | `—` |
| `F-203` | `[ ] A FAZER` | Assinar iCal com segredo protegido e aviso | P2 | `—` |
| `F-204` | `[ ] A FAZER` | Ver próximos eventos | P2 | `—` |
| `F-205` | `[ ] A FAZER` | Notificar 5 minutos antes quando configurado | P2 | `—` |
| `F-206` | `[ ] A FAZER` | Converter fuso horário corretamente | P2 | `—` |
| `F-207` | `[ ] A FAZER` | Clima atual por cidade manual | P2 | `—` |
| `F-208` | `[ ] A FAZER` | Clima por localização com opt-in | P2 | `—` |
| `F-209` | `[ ] A FAZER` | Animação visual leve de chuva/nuvens opt-in | P2 | `—` |
| `F-210` | `[ ] A FAZER` | Exibir vento/umidade/precipitação quando provido | P2 | `—` |
| `F-211` | `[ ] A FAZER` | Alertas meteorológicos somente com fonte confiável | P2 | `—` |
| `F-212` | `[ ] A FAZER` | Cache offline do último clima | P2 | `—` |
| `F-213` | `[ ] A FAZER` | Cronômetro | P2 | `—` |
| `F-214` | `[ ] A FAZER` | Contagem regressiva | P2 | `—` |
| `F-215` | `[ ] A FAZER` | Pomodoro | P2 | `—` |
| `F-216` | `[ ] A FAZER` | Pausa curta/longa | P2 | `—` |
| `F-217` | `[ ] A FAZER` | Checklist de tarefas | P2 | `—` |
| `F-218` | `[ ] A FAZER` | Tarefas com prazo e lembrete | P2 | `—` |
| `F-219` | `[ ] A FAZER` | Filtro de tarefas concluídas | P2 | `—` |
| `F-220` | `[ ] A FAZER` | Importar/exportar calendário/tarefas | P2 | `—` |
| `F-221` | `[ ] A FAZER` | Não soar alarme falso após suspensão | P2 | `—` |

### 11.9 Sistema, monitores e bateria

Origem de referência: `R11 R06 R05 R07`. Prioridade padrão `P1` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-222` | `[ ] A FAZER` | CPU total com amostragem real | P1 | `—` |
| `F-223` | `[ ] A FAZER` | Uso de CPU por processo sem privilégio excessivo | P1 | `—` |
| `F-224` | `[ ] A FAZER` | RAM usada e total | P1 | `—` |
| `F-225` | `[ ] A FAZER` | Disco livre/ocupado com unidade correta | P1 | `—` |
| `F-226` | `[ ] A FAZER` | Tráfego de rede em tempo real | P1 | `—` |
| `F-227` | `[ ] A FAZER` | Latência de rede opt-in e explicada | P1 | `—` |
| `F-228` | `[ ] A FAZER` | Uso de GPU quando API suportar | P1 | `—` |
| `F-229` | `[ ] A FAZER` | Gráfico de 60 segundos sem custo exagerado | P1 | `—` |
| `F-230` | `[ ] A FAZER` | Aviso de CPU sustentada em limite | P1 | `—` |
| `F-231` | `[ ] A FAZER` | Aviso de RAM sustentada em limite | P1 | `—` |
| `F-232` | `[ ] A FAZER` | Mini widget CPU/RAM | P1 | `—` |
| `F-233` | `[ ] A FAZER` | Temperatura somente por sensor confiável | P1 | `—` |
| `F-234` | `[ ] A FAZER` | Volume geral e mute | P1 | `—` |
| `F-235` | `[ ] A FAZER` | Indicador de dispositivo de saída | P1 | `—` |
| `F-236` | `[ ] A FAZER` | Wi-Fi conectado/desconectado | P1 | `—` |
| `F-237` | `[ ] A FAZER` | Nome da rede sujeito a permissão | P1 | `—` |
| `F-238` | `[ ] A FAZER` | Status de Bluetooth | P1 | `—` |
| `F-239` | `[ ] A FAZER` | Bateria do notebook, somente se existir | P1 | `—` |
| `F-240` | `[ ] A FAZER` | Bateria de periférico quando disponível | P1 | `—` |
| `F-241` | `[ ] A FAZER` | Múltiplos monitores por ID estável | P1 | `—` |
| `F-242` | `[ ] A FAZER` | Monitores com coordenadas negativas | P1 | `—` |
| `F-243` | `[ ] A FAZER` | Monitor removido com app aberto | P1 | `—` |
| `F-244` | `[ ] A FAZER` | Retorno após sleep/wake | P1 | `—` |
| `F-245` | `[ ] A FAZER` | Troca 60/120/165 Hz sem alterar render incorretamente | P1 | `—` |
| `F-246` | `[ ] A FAZER` | Teste com janela em ultrawide 3440x1440 | P1 | `—` |

### 11.10 Arquivos, downloads e transferência móvel

Origem de referência: `R07 R02 NOVO`. Prioridade padrão `P2` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-247` | `[ ] A FAZER` | Shelf de arquivos recentes sem copiar dados sem consentimento | P2 | `—` |
| `F-248` | `[ ] A FAZER` | Transferência PC->celular por QR local | P2 | `—` |
| `F-249` | `[ ] A FAZER` | Transferência celular->PC por QR local | P2 | `—` |
| `F-250` | `[ ] A FAZER` | Autenticação de pareamento temporário | P2 | `—` |
| `F-251` | `[ ] A FAZER` | Expiração de sessão de transferência | P2 | `—` |
| `F-252` | `[ ] A FAZER` | Verificação de integridade por hash | P2 | `—` |
| `F-253` | `[ ] A FAZER` | Progresso real de transferência | P2 | `—` |
| `F-254` | `[ ] A FAZER` | Cancelar transferência | P2 | `—` |
| `F-255` | `[ ] A FAZER` | Limite configurável de tamanho | P2 | `—` |
| `F-256` | `[ ] A FAZER` | Salvar no diretório escolhido | P2 | `—` |
| `F-257` | `[ ] A FAZER` | Bloquear traversal e arquivo executável suspeito | P2 | `—` |
| `F-258` | `[ ] A FAZER` | Detectar múltiplos celulares sem conflitar sessões | P2 | `—` |
| `F-259` | `[ ] A FAZER` | Integração opcional de downloads do navegador | P2 | `—` |
| `F-260` | `[ ] A FAZER` | Mostrar origem e nome de download | P2 | `—` |
| `F-261` | `[ ] A FAZER` | Mostrar taxa/ETA e progresso real | P2 | `—` |
| `F-262` | `[ ] A FAZER` | Pausar e retomar somente quando API permitir | P2 | `—` |
| `F-263` | `[ ] A FAZER` | Cancelar download com confirmação | P2 | `—` |
| `F-264` | `[ ] A FAZER` | Sem interceptar tráfego criptografado do navegador | P2 | `—` |
| `F-265` | `[ ] A FAZER` | Configurar permissão de firewall mínima | P2 | `—` |
| `F-266` | `[ ] A FAZER` | Sem expor serviço na LAN sem confirmação | P2 | `—` |

### 11.11 Discord, chamadas, webcam e gravador

Origem de referência: `R07 R05 NOVO`. Prioridade padrão `P3` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-267` | `[ ] A FAZER` | Mostrar membros de canal de voz por API permitida | P3 | `—` |
| `F-268` | `[ ] A FAZER` | Exibir mute/deafen quando API permitir | P3 | `—` |
| `F-269` | `[ ] A FAZER` | Controles Discord apenas por integrações suportadas | P3 | `—` |
| `F-270` | `[ ] A FAZER` | Não solicitar token de conta Discord | P3 | `—` |
| `F-271` | `[ ] A FAZER` | Aviso de chamada ativa com permissão | P3 | `—` |
| `F-272` | `[ ] A FAZER` | Prévia de webcam dentro da ilha opt-in | P3 | `—` |
| `F-273` | `[ ] A FAZER` | Botão visível desligar webcam | P3 | `—` |
| `F-274` | `[ ] A FAZER` | Indicador de câmera ativa na interface | P3 | `—` |
| `F-275` | `[ ] A FAZER` | Controle de dispositivo webcam quando suportado | P3 | `—` |
| `F-276` | `[ ] A FAZER` | Gravação de tela iniciada manualmente | P3 | `—` |
| `F-277` | `[ ] A FAZER` | Gravar áudio do sistema com consentimento | P3 | `—` |
| `F-278` | `[ ] A FAZER` | Gravar microfone com consentimento | P3 | `—` |
| `F-279` | `[ ] A FAZER` | Indicar duração e estado de gravação | P3 | `—` |
| `F-280` | `[ ] A FAZER` | Pausar/retomar quando suporte existir | P3 | `—` |
| `F-281` | `[ ] A FAZER` | Parar e salvar gravação | P3 | `—` |
| `F-282` | `[ ] A FAZER` | Escolher pasta e formato de saída | P3 | `—` |
| `F-283` | `[ ] A FAZER` | Reproduzir gravação salva | P3 | `—` |
| `F-284` | `[ ] A FAZER` | Excluir gravação com confirmação | P3 | `—` |
| `F-285` | `[ ] A FAZER` | Ocultar ilha do vídeo somente se verificado | P3 | `—` |
| `F-286` | `[ ] A FAZER` | Nunca gravar em segundo plano ocultamente | P3 | `—` |

### 11.12 Dock e personalização visual desktop

Origem de referência: `R06 R08 R09`. Prioridade padrão `P2` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-287` | `[ ] A FAZER` | Dock inferior autoral com apps favoritos | P2 | `—` |
| `F-288` | `[ ] A FAZER` | Dock lateral opcional | P2 | `—` |
| `F-289` | `[ ] A FAZER` | Auto-hide do dock | P2 | `—` |
| `F-290` | `[ ] A FAZER` | Ícones SVG e imagens com licença | P2 | `—` |
| `F-291` | `[ ] A FAZER` | Aplicativos abertos destacados | P2 | `—` |
| `F-292` | `[ ] A FAZER` | Abrir app fixado | P2 | `—` |
| `F-293` | `[ ] A FAZER` | Reordenar apps no dock | P2 | `—` |
| `F-294` | `[ ] A FAZER` | Janela miniatura quando API permitir | P2 | `—` |
| `F-295` | `[ ] A FAZER` | Arrastar arquivo para abrir com app | P2 | `—` |
| `F-296` | `[ ] A FAZER` | Atalhos de pastas e arquivos | P2 | `—` |
| `F-297` | `[ ] A FAZER` | Indicadores de apps minimizados | P2 | `—` |
| `F-298` | `[ ] A FAZER` | Barra superior compacta | P2 | `—` |
| `F-299` | `[ ] A FAZER` | Widget CPU/RAM/rede na barra | P2 | `—` |
| `F-300` | `[ ] A FAZER` | Widget relógio/calendário na barra | P2 | `—` |
| `F-301` | `[ ] A FAZER` | Launcher de aplicativos próprio | P2 | `—` |
| `F-302` | `[ ] A FAZER` | Pesquisa local de apps autorizados | P2 | `—` |
| `F-303` | `[ ] A FAZER` | Atalhos de teclado configuráveis | P2 | `—` |
| `F-304` | `[ ] A FAZER` | Configuração de wallpapers locais | P2 | `—` |
| `F-305` | `[ ] A FAZER` | Wallpaper WebM/MP4 sob consumo limitado | P2 | `—` |
| `F-306` | `[ ] A FAZER` | Wallpaper HTML em sandbox | P2 | `—` |
| `F-307` | `[ ] A FAZER` | Pausa de wallpaper durante games | P2 | `—` |
| `F-308` | `[ ] A FAZER` | Layout de janelas 2/3 colunas | P2 | `—` |
| `F-309` | `[ ] A FAZER` | Layout ultrawide 3 regiões | P2 | `—` |
| `F-310` | `[ ] A FAZER` | Salvar e restaurar layout de janelas | P2 | `—` |
| `F-311` | `[ ] A FAZER` | Integração opcional com workspaces | P2 | `—` |
| `F-312` | `[ ] A FAZER` | Presets de cores e fontes | P2 | `—` |
| `F-313` | `[ ] A FAZER` | Presets de borda/transparência do app | P2 | `—` |
| `F-314` | `[ ] A FAZER` | Explorador de skins sem baixar material ilegal | P2 | `—` |
| `F-315` | `[ ] A FAZER` | Reverter shell com um clique | P2 | `—` |
| `F-316` | `[ ] A FAZER` | Detecção de conflito com Seelen e MyDockFinder | P2 | `—` |

### 11.13 Plugins, automações e extensibilidade

Origem de referência: `R11 R04 R03 NOVO`. Prioridade padrão `P2` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-317` | `[ ] A FAZER` | Manifest de módulo versionado | P2 | `—` |
| `F-318` | `[ ] A FAZER` | Permissões declaradas por módulo | P2 | `—` |
| `F-319` | `[ ] A FAZER` | Ativar/desativar sem reinício quando possível | P2 | `—` |
| `F-320` | `[ ] A FAZER` | Ordem de módulos personalizada | P2 | `—` |
| `F-321` | `[ ] A FAZER` | SDK TypeScript com tipos | P2 | `—` |
| `F-322` | `[ ] A FAZER` | Eventos padronizados e contratos | P2 | `—` |
| `F-323` | `[ ] A FAZER` | API localhost autenticada | P2 | `—` |
| `F-324` | `[ ] A FAZER` | Rate limit por plugin | P2 | `—` |
| `F-325` | `[ ] A FAZER` | Manifest com origem e licença | P2 | `—` |
| `F-326` | `[ ] A FAZER` | Catálogo local de plugins confiáveis | P2 | `—` |
| `F-327` | `[ ] A FAZER` | Importar plugin apenas por autorização | P2 | `—` |
| `F-328` | `[ ] A FAZER` | Desinstalação e limpeza de plugin | P2 | `—` |
| `F-329` | `[ ] A FAZER` | Sandbox de scripts/HTML quando aplicável | P2 | `—` |
| `F-330` | `[ ] A FAZER` | Logs por plugin sem dados sensíveis | P2 | `—` |
| `F-331` | `[ ] A FAZER` | Tratamento de crash isolado | P2 | `—` |
| `F-332` | `[ ] A FAZER` | Exemplo plugin timer | P2 | `—` |
| `F-333` | `[ ] A FAZER` | Exemplo plugin build progress | P2 | `—` |
| `F-334` | `[ ] A FAZER` | Exemplo plugin notificação local | P2 | `—` |
| `F-335` | `[ ] A FAZER` | Compatibilidade por versão de SDK | P2 | `—` |
| `F-336` | `[ ] A FAZER` | Controle de uso de memória por plugin | P2 | `—` |
| `F-337` | `[ ] A FAZER` | Evitar execução remota arbitrária | P2 | `—` |
| `F-338` | `[ ] A FAZER` | Versionamento da API externa | P2 | `—` |

### 11.14 Segurança, privacidade, acessibilidade

Origem de referência: `R11 R07 R06 NOVO`. Prioridade padrão `P0` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-339` | `[ ] A FAZER` | Aplicativo funciona sem conta obrigatória | P0 | `—` |
| `F-340` | `[ ] A FAZER` | Sem telemetria por padrão | P0 | `—` |
| `F-341` | `[ ] A FAZER` | Telemetria opt-in se for implementada | P0 | `—` |
| `F-342` | `[ ] A FAZER` | Armazenamento de tokens com proteção do sistema | P0 | `—` |
| `F-343` | `[ ] A FAZER` | Nenhum segredo enviado a logs | P0 | `—` |
| `F-344` | `[ ] A FAZER` | Nenhum token em Git | P0 | `—` |
| `F-345` | `[ ] A FAZER` | Proteção contra localhost CSRF e DNS rebinding | P0 | `—` |
| `F-346` | `[ ] A FAZER` | CORS e validação de Origin corretos | P0 | `—` |
| `F-347` | `[ ] A FAZER` | Schema de validação em IPC | P0 | `—` |
| `F-348` | `[ ] A FAZER` | Limites de payload API | P0 | `—` |
| `F-349` | `[ ] A FAZER` | Cancelamento e timeouts por integração | P0 | `—` |
| `F-350` | `[ ] A FAZER` | Capacidades por plugin com menor privilégio | P0 | `—` |
| `F-351` | `[ ] A FAZER` | Permissões específicas de câmera/mic | P0 | `—` |
| `F-352` | `[ ] A FAZER` | Permissões específicas de localização | P0 | `—` |
| `F-353` | `[ ] A FAZER` | Permissões específicas de captura de tela | P0 | `—` |
| `F-354` | `[ ] A FAZER` | Permissões específicas de notificações | P0 | `—` |
| `F-355` | `[ ] A FAZER` | Acesso clipboard opt-in | P0 | `—` |
| `F-356` | `[ ] A FAZER` | Apagar todos os dados locais | P0 | `—` |
| `F-357` | `[ ] A FAZER` | Exportar backup de configurações | P0 | `—` |
| `F-358` | `[ ] A FAZER` | Política de retenção local | P0 | `—` |
| `F-359` | `[ ] A FAZER` | Conformidade de licença/atribuição | P0 | `—` |
| `F-360` | `[ ] A FAZER` | Auditoria dependências/SBOM | P0 | `—` |
| `F-361` | `[ ] A FAZER` | Atalhos de teclado remapeáveis | P0 | `—` |
| `F-362` | `[ ] A FAZER` | Navegação por teclado e foco visível | P0 | `—` |
| `F-363` | `[ ] A FAZER` | Leitor de tela nas ações principais | P0 | `—` |
| `F-364` | `[ ] A FAZER` | Modo de alto contraste | P0 | `—` |
| `F-365` | `[ ] A FAZER` | Modo redução de movimento | P0 | `—` |
| `F-366` | `[ ] A FAZER` | Sem piscadas/flicker incômodos | P0 | `—` |
| `F-367` | `[ ] A FAZER` | Legibilidade 125/150/200% DPI | P0 | `—` |
| `F-368` | `[ ] A FAZER` | Mensagens e ajuda em PT-BR natural | P0 | `—` |

### 11.15 Instalação, inicialização, atualizações e GitHub

Origem de referência: `R11 R02 R05 NOVO`. Prioridade padrão `P0` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-369` | `[ ] A FAZER` | Instalador Windows x64 funcional | P0 | `—` |
| `F-370` | `[ ] A FAZER` | ZIP portátil com instruções | P0 | `—` |
| `F-371` | `[ ] A FAZER` | Não exigir admin no modo usuário quando viável | P0 | `—` |
| `F-372` | `[ ] A FAZER` | Atalho iniciar padrão | P0 | `—` |
| `F-373` | `[ ] A FAZER` | Inicializar com Windows opt-in | P0 | `—` |
| `F-374` | `[ ] A FAZER` | Iniciar silenciosamente sem terminal visível | P0 | `—` |
| `F-375` | `[ ] A FAZER` | Não abrir/fechar console periodicamente | P0 | `—` |
| `F-376` | `[ ] A FAZER` | Ícone e menu na bandeja do sistema | P0 | `—` |
| `F-377` | `[ ] A FAZER` | Sair do app via tray | P0 | `—` |
| `F-378` | `[ ] A FAZER` | Modo safe-mode para recuperação | P0 | `—` |
| `F-379` | `[ ] A FAZER` | Reabrir após restart sem travar Explorer | P0 | `—` |
| `F-380` | `[ ] A FAZER` | Atualizador com pacote assinado quando disponível | P0 | `—` |
| `F-381` | `[ ] A FAZER` | Verificar hash/assinatura do update | P0 | `—` |
| `F-382` | `[ ] A FAZER` | Changelog no app e no GitHub | P0 | `—` |
| `F-383` | `[ ] A FAZER` | Notificar update sem reinício forçado | P0 | `—` |
| `F-384` | `[ ] A FAZER` | Instalador preserva preferências | P0 | `—` |
| `F-385` | `[ ] A FAZER` | Desinstalador remove autostart | P0 | `—` |
| `F-386` | `[ ] A FAZER` | Desinstalador não apaga dados sem perguntar | P0 | `—` |
| `F-387` | `[ ] A FAZER` | Logs locais rotativos e protegidos | P0 | `—` |
| `F-388` | `[ ] A FAZER` | Build CI Windows reproduzível | P0 | `—` |
| `F-389` | `[ ] A FAZER` | Verificar hash dos artefatos | P0 | `—` |
| `F-390` | `[ ] A FAZER` | Tag Git sem sobrescrever | P0 | `—` |
| `F-391` | `[ ] A FAZER` | GitHub Release v0.1.0 validada | P0 | `—` |
| `F-392` | `[ ] A FAZER` | README e ajuda PT-BR | P0 | `—` |
| `F-393` | `[ ] A FAZER` | Issues e PRs com referência a tasks | P0 | `—` |
| `F-394` | `[ ] A FAZER` | Checklist sincronizado a cada mudança | P0 | `—` |
| `F-395` | `[ ] A FAZER` | Screenshots reais de estados principais | P0 | `—` |
| `F-396` | `[ ] A FAZER` | Testes de suspensão/wake | P0 | `—` |
| `F-397` | `[ ] A FAZER` | Teste de uso prolongado | P0 | `—` |
| `F-398` | `[ ] A FAZER` | Não publicar release com teste P0 falhando | P0 | `—` |

### 11.16 Funcionalidades originais Ander Flow, além dos concorrentes

Origem de referência: `NOVO`. Prioridade padrão `P3` (reclassificar somente com justificativa).

| ID | Status | Funcionalidade/resultado desejado | Prioridade | Evidência da NOSSA implementação |
|---|---|---|---|---|
| `F-399` | `[ ] A FAZER` | Painel de controle de todos os módulos em uma tela | P3 | `—` |
| `F-400` | `[ ] A FAZER` | Perfis Trabalho/Jogo/Filmes/Minimal | P3 | `—` |
| `F-401` | `[ ] A FAZER` | Mudança automática por aplicativo com opt-in | P3 | `—` |
| `F-402` | `[ ] A FAZER` | Diagnóstico de conflitos de overlays | P3 | `—` |
| `F-403` | `[ ] A FAZER` | Modo ultrawide com layout inteligente | P3 | `—` |
| `F-404` | `[ ] A FAZER` | Regras por monitor e resolução | P3 | `—` |
| `F-405` | `[ ] A FAZER` | Sessões de automação local com consentimento | P3 | `—` |
| `F-406` | `[ ] A FAZER` | Hub de commits/workflows dos projetos Ander Flow | P3 | `—` |
| `F-407` | `[ ] A FAZER` | Marcadores de progresso de build e instalação | P3 | `—` |
| `F-408` | `[ ] A FAZER` | Aviso de agente aguardando aprovação real | P3 | `—` |
| `F-409` | `[ ] A FAZER` | Hotkeys para módulos favoritos | P3 | `—` |
| `F-410` | `[ ] A FAZER` | Configuração de animação por módulo | P3 | `—` |
| `F-411` | `[ ] A FAZER` | Exportação/importação de tema próprio | P3 | `—` |
| `F-412` | `[ ] A FAZER` | Perfis offline/energia baixa | P3 | `—` |
| `F-413` | `[ ] A FAZER` | Pausa de integrações de rede em um clique | P3 | `—` |
| `F-414` | `[ ] A FAZER` | Controles de privacidade por fonte de dados | P3 | `—` |
| `F-415` | `[ ] A FAZER` | Painel saúde do app (uso CPU/RAM e erros) | P3 | `—` |
| `F-416` | `[ ] A FAZER` | Restaurar padrão Ander Flow | P3 | `—` |
| `F-417` | `[ ] A FAZER` | Assistente guiado de primeira execução | P3 | `—` |
| `F-418` | `[ ] A FAZER` | Configuração totalmente em português brasileiro | P3 | `—` |

**Total inicial: 418 critérios funcionais rastreáveis**, agrupados em 16 frentes. Esse número é inventário de objetivo, não quantidade implementada nem auditoria concluída. Agentes devem **adicionar itens** descobertos nas fontes, não remover ou esquecer os existentes; deduplicar com mapeamento de ID.

---

## 12. ORDEM DE IMPLEMENTAÇÃO — FATIAMENTO VERTICAL, NÃO POR TELAS FALSAS

A lista de 418 critérios é o inventário-alvo, não uma obrigação de implementar tudo antes de um primeiro release. O produto deve crescer de forma acumulativa, com versões sequenciais, sem sacrificar qualidade para acumular checkboxes.

### Fase 0 — Fundação verificável (`v0.1.0-dev` antes de qualquer release público)

- Auditoria R01–R11, fontes extras, licenças e escolha documentada de arquitetura.
- Verificar acesso GitHub e nome único; criar repositório público/privado conforme autorização vigente; nunca inferir visibilidade desejada de outra conversa ou de projetos diferentes. Se criação estiver explicitamente solicitada pelo pedido corrente, efetuar somente quando acesso e identidade estiverem confirmados.
- Criar README, LICENSE compatível, CODEOWNERS, CONTRIBUTING, SECURITY, templates issues/PR, projetos, backlog rastreável, pipeline CI Windows e branch de desenvolvimento.
- Criar esqueleto Tauri/React/Rust **compilável** e design tokens Ander Flow.
- Demonstrar `janela overlay real → cápsula → clique/hover → painel expandido → voltar`, com atalho, ícone de tray, fechar corretamente e mudança de tema.
- Enviar commit/PR e publicar evidência de build apenas; ainda **não** etiquetar release estável antes dos gates.

**Critério F0:** instala/roda de fato em Windows de teste; screenshot do aplicativo real, não imagem ilustrativa; teste de clique externo sem bloquear desktop; sem terminal oscilando; CI verde; checklist atualizado.

### Fase 1 — Primeiro produto útil (`v0.1.0`, se gates aprovados)

- Captura de sessão de mídia real GSMTC, música atual, capa, play/pause, próximo/anterior, progress bar e seek quando suportado.
- Estados de ilha, abas, launcher inicial, tema claro/escuro e Flow Orange, animações previsíveis e redução de movimento.
- Multi-monitor básico, DPI, fullscreen auto-hide, inicialização automática opcional silenciosa, configurações persistentes, tray e saída.
- Instalador, ZIP portátil, versão coerente, nota de release e teste de instalação/desinstalação.

**Gate de aceite F1:** um tester abre Spotify/navegador local e comanda sessão real; não depender de mock; funciona em monitor ultrawide ou em ambiente representativo com validação posterior obrigatória no ultrawide; teste Windows real documentado.

### Fase 2 — Produtividade diária (`v0.1.1`, `v0.1.2`, ...)

- Clipboard privado opt-in, shelf de arquivos, notificações locais, relógio/calendário, temporizador e widgets de sistema.
- Busca no histórico, ações rápidas, localização por monitor, perfis de tema, configurações por módulo, feedbacks de erro honestos.
- Testes de regressão de sono/retorno, monitores desconectados, jogos e instalação.

### Fase 3 — Integrações profundas (`v0.2.x` quando justificável)

- Notificações Windows **com permissão/identidade corretas**.
- GitHub, Claude Code/agentes, chat opt-in, API local segura, clima, calendário com integração autorizada.
- Busca textual na tela/OCR com permissão, status de downloads e eventos externos.
- Revisar consumo idle e CPU/GPU com funções extras habilitadas; nenhum módulo de IA deve fazer rede inesperada em repouso.

### Fase 4 — Personalização avançada (`v0.3.x`)

- Dock, widgets, launcher, ações rápidas, layouts ultrawide de janelas e wallpapers com pausa automática.
- Compatibilidade com Seelen UI, MyDockFinder e WindowBlinds por convivência, não modificando os programas.
- Modo recuperação, backups e botão reversão visual.

### Fase 5 — Recursos premium sem custo obrigatório (`v0.4.x` até `v0.9.x`)

- Temas avançados, microanimações físicas, spectrum real, letras sincronizadas legalmente, transferências celulares, gravador e chamadas quando factíveis.
- Plugin SDK documentado e seguro, API local, atalhos e integração de projetos Flow, benchmark sustentado.
- Pesquisa complementar de funcionalidades emergentes em fóruns/YouTube, sempre evitando adicionar recursos dispensáveis ao custo de estabilidade.

### Marco de maturidade (`v1.0.0`)

Considerar apenas com funcionalidades essenciais verificadas, crash rate aceitável medido, governança de licenças, segurança, testes Windows e documentação de instalação/reversão completos. O uso de `v1.0.0` não deve ser antecipado para mascarar tarefas incompletas.

---

## 13. TESTES REAIS E QUALIDADE — MATRIZ OBRIGATÓRIA

**Regra absoluta:** um print de uma página HTML no navegador **não prova** overlay no Windows. Build de CI **não prova** que a função opera em um desktop real. Mock de GSMTC **não prova** controle do Spotify. Os níveis de evidência devem ser claramente separados.

### 13.1 Escada de evidência

| Nível | Rótulo | O que comprova | Pode marcar FEITO+TESTADO? |
|---|---|---|---|
| E0 | Só planejamento | intenção | Não |
| E1 | Protótipo/maquete | aparência proposta | Não |
| E2 | Código compilando | sintaxe e dependências | Não, se requer uso real |
| E3 | Teste unitário/integrado | lógica e contratos simulados | Parcial, depende do requisito |
| E4 | E2E automatizado em Windows | fluxo real naquele ambiente | Em grande parte, se cobrir requisito |
| E5 | Teste manual em Windows real com logs/screenshots | experiência no hardware alvo | Sim, combinado aos demais gates |
| E6 | Release publicado e download revalidado | distribuição verificável | Sim, para entrega da versão, não para todas as funções |

### 13.2 Matriz mínima de hardware/ambiente

1. Windows 11 atualizado, arquitetura x64, usuário padrão, permissões limitadas.
2. Windows 10 compatível, arquitetura x64; Windows 11 com escala 125%, 150%, 200%.
3. Monitores 1920×1080, 2560×1440, **3440×1440 ultrawide**, diferentes taxas 60/120/165 Hz quando hardware permitir.
4. Dois monitores com DPI distinto, um à esquerda (coordenadas negativas), um principal modificado em runtime.
5. DisplayPort e HDMI quando disponível; alternância de modo PC/AV não deve mudar funcionalidade do app nem ser manipulada sem pedido.
6. Janela fullscreen exclusiva, borderless, desktop comum; jogos com anti-cheat: testar sem injeção no processo e sem overlay quando houver risco.
7. Suspend/resume, bloqueio/desbloqueio, reiniciar Explorer, troca de sessão, energia baixa, DPI/resolução alterados.
8. Spotify desktop, YouTube em navegador e um segundo player suportado: provar metadados/controles reais, observar variações entre apps.
9. Rede offline, rede lenta, provedor externo indisponível, erro de token, rate limit e cancelamento.
10. Ambiente com e sem Seelen UI/MyDockFinder/WindowBlinds instalados **apenas se essas ferramentas estiverem legitimamente disponíveis**; jamais instalar software pago sem autorização.

### 13.3 Cenários E2E mínimos (exemplo de IDs para testes)

| Teste | Ação | Resultado de aceite | Evidência mínima |
|---|---|---|---|
| TST-001 | Abrir app pela primeira vez | ilha visível sem bloquear outros cliques | vídeo curto + log |
| TST-002 | Hover, sair do mouse e reentrar rapidamente | sem jitter, fechamento retardado corretamente | captura de interação |
| TST-003 | Clicar na aba de música | conteúdo real e sem placeholder | screenshot + log GSMTC |
| TST-004 | Play/pause, próximo/anterior | player real responde | gravação + assert |
| TST-005 | Arrastar barra de seek | posição muda somente em sessão com suporte | captura de teste |
| TST-006 | Abrir jogo em tela cheia | ilha oculta e sem processar frames desnecessários | log + benchmark |
| TST-007 | Sair do jogo | ilha retorna sem duplicação | screenshot + estado |
| TST-008 | Mudar escala DPI | UI não corta, posição e clique corretos | screenshot por DPI |
| TST-009 | Desconectar monitor-alvo | app migra para monitor válido | vídeo + log |
| TST-010 | Suspender/reacordar o PC | serviços reconectam sem travar | log + fluxo |
| TST-011 | Iniciar com Windows | sem terminal piscando; tray e ilha corretos | vídeo + prova do autostart |
| TST-012 | Desativar autostart e reiniciar | app não inicia sozinho | verificação pós-login |
| TST-013 | Limpar clipboard | histórico apagado sem reversão acidental | teste funcional |
| TST-014 | Negar permissão de notificação | módulo apresenta fallback claro | print + validação |
| TST-015 | Dado local malicioso na API | rejeição sem executar código | teste de segurança |
| TST-016 | Recuperar de crash/erro de plugin | ilha continua ou reinicia em safe-mode | logs + teste |
| TST-017 | Instalar nova versão | mantém preferências, atualiza binário | teste instalação |
| TST-018 | Desinstalar com restauração | remove autostart e alterações do próprio app | comparação de estado |
| TST-019 | Trocar tema escuro/claro | contraste, tokens e persistência corretos | screenshots |
| TST-020 | Navegar apenas com teclado | sem armadilha de foco e Esc fecha | checklist acessibilidade |
| TST-021 | Ativar redução de movimento | desativa física intensa sem quebrar UI | teste visual |
| TST-022 | Deixar idle por período definido | CPU/RAM/GPU medidas, sem vazamento progressivo | relatório quantitativo |
| TST-023 | Habilitar plugins e desabilitar | sem perda de estado/erros não tratados | logs |
| TST-024 | Alterar relógio/fuso horário | timers seguem o relógio correto | asserções |
| TST-025 | Abrir app desconectado da internet | núcleo e funções locais operam | vídeo + logs |
| TST-026 | Trocar idioma | todos os textos críticos em PT-BR | auditoria textual |
| TST-027 | Conectar dispositivo Bluetooth sem bateria exposta | interface não inventa porcentagem | vídeo e estado |
| TST-028 | Enviar arquivo por QR e cancelar | cancelamento efetivo, nenhum arquivo corrompido publicado | logs de transferência |
| TST-029 | Login de outra conta Windows | dados do usuário não vazam entre sessões | teste com usuários de QA |
| TST-030 | Baixar release publicada do GitHub | hash, versão, instalação e link corretos | URL + checksum + instalação |

### 13.4 Orçamento de desempenho — metas a medir, não promessas

- CPU idle com cápsula recolhida: **objetivo de projeto** abaixo de 1% em máquina de referência, quando APIs e hardware permitirem; registrar média/p95 e perfil da máquina. Se inviável, justificar com benchmark.
- RAM idle: orçamento inicial de **até 150 MB** em build padrão, ou explicar com provas por que o runtime exige mais. Comparar com alternativa .NET/Rust antes de sacrificar recursos.
- Animação ativa: projetar para 60 FPS de base, habilitar 120 FPS somente se medição sustentar; **não forçar render a 165 Hz constantemente** só porque o monitor aceita 165 Hz.
- Tempo de resposta de hover/click: alvo de percepção imediata, medir tempo até primeiro frame e até estado estável.
- Sem vazamento de memória e sem crescimento sistemático de handles/GDI após teste prolongado.
- Sem polling de IA/API em background quando módulo está desligado ou sem token.
- Benchmark em release build, depois de aquecimento, perfis energia/idle/atividade, com metodologia reproduzível e erro de medição reportado.

### 13.5 Critérios visuais de bloqueio

- Elementos cortados no topo, cruzamento com taskbar ou apps fullscreen.
- Ilha tremendo, piscando, mudando de centro, alternando hover/close sem ação.
- Texto de debug/placeholder visível em produção.
- Overlays invisíveis interceptando clique fora da cápsula.
- Falta de contraste, tab inacessível, ícones sem descrição, tooltip tapando controles.
- Tema divergindo do guia Ander Flow, excesso de verde ou 3D, uso inadequado de emojis.
- Foto/avatar/ícone falso ou dados fake sem etiqueta quando app é apresentado como produto real.

---

## 14. SEGURANÇA, PRIVACIDADE E CONFIANÇA DE DISTRIBUIÇÃO

### Threat model inicial

| Risco | Impacto | Mitigação verificável |
|---|---|---|
| API localhost atacada por site aberto no navegador | execução de ações não autorizadas | autenticação, checagem Origin/Host, CSRF, limites, localhost-only |
| Plugin malicioso | roubo de tokens/arquivos | sandbox/capabilities, assinatura ou revisão, desabilitar por padrão |
| Clipboard contendo segredo | exposição de dados | opt-in, retenção curta, exclusões, pausa/limpeza, sem upload automático |
| Atualizador adulterado | supply chain compromise | HTTPS, checksum e assinatura, comparação de origem, rollback |
| Upload de arquivo por LAN | path traversal/sobrescrita | normalize paths, allowlist destino, limites, confirmação |
| WebView2 com IPC amplo | ações privilegiadas indevidas | Tauri capabilities mínimas, CSP, sanitização, sem shell genérico |
| Alteração global do shell | travar área de trabalho | opt-in, backup, reversão, safe-mode, fallback Explorer |
| Captura de tela/gravação | violação de privacidade | consentimento explícito, indicador, sem captura passiva |
| Hooks de Claude Code | mudanças inesperadas em settings | backup, diff, opção desligar, escopo mínimo, não ler secrets |
| Notificações pessoais | exibição sensível em público | regras de privacidade, bloquear prévia na lock screen, anonimização |
| SDK/API de terceiros | mudança de termos / bloqueio | oficial primeiro, fallback e desabilitação segura |
| Agente IA com acesso a GitHub | publicação indesejada/custo | mínimo privilégio, PR, confirmação para mudanças destrutivas |

### Verificações de segurança

1. Validar dependências e licença antes de introduzir; usar lockfiles committed e revisão de updates.
2. Nenhuma senha no código/README/logs. Arquivos `.env` reais ignorados; incluir somente `.env.example` sem credenciais.
3. Nunca solicitar que o usuário desative antivírus, UAC, SmartScreen ou política de execução global para "resolver" o app.
4. Ações que exigem permissões de administrador devem ser exceção explicada, reversível e autorizada.
5. Auto-start via mecanismo legítimo por usuário; aplicativo GUI sem console visível. Para scripts PowerShell no desenvolvimento, usar alternativas como `npm.cmd`/`npx.cmd` quando existir bloqueio de execução de `.ps1`, sem relaxar segurança global.
6. Quando houver cloud/IA, informar origem da requisição, dados enviados, custo/quotas e botão de desligar.
7. Padrão offline-first: player e UI funcionam sem internet; recursos conectados têm estados offline honestos.
8. Política de atualização: somente artefatos publicados por pipeline confiável; não autoexecutar scripts baixados de fóruns.
9. Manter `SECURITY.md`, SBOM, matriz de permissões e instruções de denúncia de vulnerabilidades.

---

## 15. GITHUB — REPOSITÓRIO, CHECKLIST, ISSUES E RELEASES

### Criação inicial

1. Checar se o GitHub conectado está autenticado como a conta alvo e possui permissão para criar repositórios. O nome pretendido é `Ander-Flow-Prism-Island` no namespace `AnderHonorato`. **Se a conta não estiver disponível, não afirmar que o repositório foi criado.**
2. Conferir disponibilidade do slug; criar um repositório novo sem sobrescrever `main` de outro projeto, conforme visibilidade aprovada ou opção definida pelo usuário.
3. Proteger `main` com PR/review/CI quando disponível e não exigir proteção incompatível com limites do plano.
4. Criar primeiro commit de infraestrutura e docs, registrar URL real de repo e commit SHA. Não publicar releases vazias como produto pronto.
5. Criar labels: `tipo:bug`, `tipo:feature`, `tipo:design`, `tipo:seguranca`, `prioridade:P0`, `P1`, `P2`, `P3`, `estado:a-fazer`, `em-andamento`, `bloqueado`, `qa`, `concluido`, `release:vX.Y.Z`, `area:ilha`, `area:midia`, `area:windows`, `area:integracoes`, `area:personalizacao`.
6. Organizar um GitHub Project (se disponível) com os campos `ID`, `Título`, `Prioridade`, `Responsável`, `Estado`, `Versão-alvo`, `Fonte`, `Critério de aceite`, `Teste`, `PR`, `Data`.

### Estados oficiais do checklist

- `[ ] A FAZER` — precisa implementação; pode ter pesquisa concluída separada.
- `[~] EM ANDAMENTO` — branch/issue/owner e trabalho verificável vinculados.
- `[!] ERRO` — execução falhou; descrever erro, log, responsável, próxima tentativa.
- `[!] BLOQUEADO` — dependência técnica, licença, permissão ou acesso; declarar como desbloquear.
- `[?] AGUARDANDO TESTE` — implementado, mas falta prova no Windows.
- `[x] FEITO + VALIDADO` — commit/PR mergeado, testes necessários aprovados e evidência acessível.
- `[-] NÃO APLICÁVEL` — apenas com justificativa aprovada, sem deletar histórico.

**Não usar `FEITO` para código escrito sem teste.** Quando o serviço externo não está disponível, manter `bloqueado` ou `aguardando teste`, jamais alterar a verdade só para fechar uma meta.

### Estrutura do arquivo de acompanhamento (`docs/ACOMPANHAMENTO.md`)

```md
# Ander Flow Prism Island — acompanhamento

**Versão de código:** v0.1.0-dev  
**Release pública:** NÃO PUBLICADA  
**Última atualização:** YYYY-MM-DD HH:mm (America/Sao_Paulo)  
**Commit:** SHA real ou `nenhum`

## Resumo
- A fazer: [número calculado]
- Em andamento: [número calculado]
- Aguardando teste: [número calculado]
- Erros: [número calculado]
- Bloqueados: [número calculado]
- Feito e validado: [número calculado]

## Prioridade única atual
- Tarefa: T-XXXX
- Razão: impacto e dependências
- Critério de conclusão: ...
- Agente: ...
- Branch/PR: ...

## Itens alterados nesta atualização
| ID | Antes | Agora | Evidência | Commit | Revisor |
|---|---|---|---|---|---|
| F-001 | A FAZER | EM ANDAMENTO | issue/branch real | SHA, se houver | A16 |

## Impedimentos / riscos
- [ ] Descrição + ação de desbloqueio + owner

## Links verificáveis
- Repositório: ...
- PR/commit: ...
- CI: ...
- Release: `não publicada` ou URL real
- Instalador: `não disponível` ou URL de release validada
- Testes Windows: URL/arquivo de evidência real
```

### Backlog estruturado (`docs/backlog/TAREFAS.json`)

```json
{
  "projeto": "Ander Flow Prism Island",
  "schemaVersao": 1,
  "versaoAtual": "0.1.0-dev",
  "ultimaAtualizacao": "a preencher durante execução",
  "tarefas": [
    {
      "id": "F-001",
      "titulo": "Cápsula preta no topo central",
      "area": "ilha",
      "prioridade": "P0",
      "status": "a-fazer",
      "owner": null,
      "origem": ["R11"],
      "criteriosAceite": ["Overlay real em Windows", "Sem bloqueio de clique externo"],
      "evidencias": [],
      "issues": [],
      "pullRequests": [],
      "commits": [],
      "testes": [],
      "erros": [],
      "versaoAlvo": "0.1.0"
    }
  ]
}
```

O array acima é **exemplo de schema**; a automação deverá **gerar entradas para todos os F-001 a F-418**, e novos IDs acrescentados após a pesquisa, sem perder continuidade. O Markdown exibe a visão humana, mas JSON/CSV deve ser a fonte de verdade para cálculo automático.

### Fluxo Git inegociável

```text
Issue com ID -> branch por tarefa -> implementação + testes -> PR com checklist
-> revisão de especialista independente -> CI verde -> merge controlado
-> atualizar backlog no mesmo PR ou PR sincronizada -> changelog
-> tag vX.Y.Z -> build Release no Windows -> verificação hash/instalação
-> publicação -> revalidação do link -> próxima prioridade
```

### Versionamento sequencial obrigatório

- Branch de desenvolvimento pode usar `0.1.0-dev` enquanto não houver release.
- Primeira versão pública validada: `v0.1.0`.
- Correção: `v0.1.1`, depois `v0.1.2`, depois `v0.1.3`.
- Nova fatia relevante: `v0.2.0` após decisão documentada; não pular versões aleatoriamente, não usar versão falsa.
- Tag Git, versão Tauri/package, arquivo `.exe`, ZIP, README, CHANGELOG e tela `Sobre` devem ser coerentes.
- Toda release tem **artefatos versionados**, checksum SHA-256, notas de versão, lista de tarefas fechadas, regressões conhecidas e instruções de atualização/reversão.
- Preserve versões anteriores no GitHub Releases; não reusar um tag para binários diferentes.
- Publicação de prereleases `-alpha`, `-beta` e `-rc` só com etiqueta clara e instalador identificado como experimental.
- Se houver falha em release candidata, guardar artefato de CI para investigação, **não** promovê-lo a release estável.

### Exemplo de emissão de release (após validação)

```text
Ander Flow Prism Island — v0.1.0
Data: YYYY-MM-DD
Commit: <sha>
Status: ESTÁVEL (somente se os gates passaram)

Novidades:
- Ilha dinâmica com UI real no Windows
- Controle de mídia via API Windows
- Temas Ander Flow

Testes:
- CI: <URL>
- Windows real: <URL evidência>
- Segurança/licenças: <URL>

Downloads:
- Setup: <URL verificada>
- Portable: <URL verificada>
- SHA-256: <hash calculado>

Limitações conhecidas:
- <limitações verdadeiras e específicas>
```

### CI recomendado (sem inventar permissões/conexões)

- `validar-pr`: instalação determinística de dependências, lint, typecheck, testes Rust e JS, auditoria de secrets/atualizações.
- `build-windows`: runner `windows-latest` com toolchain Rust, Node e WebView2 onde necessário; cache e hashes; construir **exatamente** a revisão da PR/tag.
- `testes-windows`: smoke e E2E viáveis no runner; deixar testes que dependem de hardware (Bluetooth, áudio real, webcam, dois monitores físicos, 165 Hz) como `AGUARDANDO TESTE REAL`, nunca mock verde fingindo validação.
- `versao-release`: dispara por tag coerente; confere assinatura/artefatos, calcula hashes, prepara draft; publica stable somente com gate/ação aprovada.
- Evitar custos externos. GitHub Actions sujeito a limites do plano e disponibilidade; monitorar consumo e não ativar runners pagos sem autorização.

---

## 16. CRITÉRIO DE PRIORIDADE ÚNICA — ESCOLHER O PRÓXIMO TRABALHO

**Não iniciar 30 recursos paralelos que dependem do mesmo núcleo instável.** Priorizar uma única próxima ação integradora enquanto especialistas executam subtarefas independentes.

Pontuação de priorização sugerida (ajustável com justificativa):

```text
P = (4 × impacto_para_o_usuario
     + 3 × desbloqueio_de_dependencias
     + 2 × risco_reduzido
     + 2 × valor_visual_ou_uso_diario)
    / (1 + esforco_estimado + risco_de_integracao)
```

Cada termo normalizado de 1 a 5; usar números como heurística documentada, não métrica científica. P0 inclui crash, perda de dados, shell quebrado, bloqueio do mouse, vazamento de segredos e CI/release falhando. Features cosméticas entram depois de estabilidade da ilha, exceto a fidelidade visual mínima para aprovação do MVP.

**Definition of Ready:** fonte/objetivo claros, licença compatível quando aplicável, owner, arquivo/branch previsto, contrato, teste, reversão.  
**Definition of Done:** implementação real, teste adequado, segurança, acessibilidade, review cruzada, CI, checklist, changelog e evidência vinculada. Se a tarefa precisa hardware não disponível, fica em `AGUARDANDO TESTE`, mesmo que código esteja pronto.

---

## 17. MODELOS E PROMPTS OPERACIONAIS DOS AGENTES

### 17.1 Mensagem para o orquestrador principal

```text
ATUE COMO ORQUESTRADOR A00 do projeto ANDER FLOW PRISM ISLAND, criado por Ander Flow.
A fonte de verdade é o SUPERPROMPT MESTRE anexado, incluindo identidade visual,
418 critérios iniciais, política de licenças, tarefas, testes e governança GitHub.
Não entregue apenas ideias. Faça auditoria de ferramentas reais e pesquisas R01–R11,
crie a estrutura se tiver autorização/acesso, implemente a fatia vertical P0,
execute testes em ambientes disponíveis, registre limites honestamente e
atualize backlog/checklist. Delegue as tarefas independentes aos agentes A01–A20.
Não finja subagentes, builds, publicação, screenshots, repos, integração ou uso do PC.
O primeiro objetivo é software Windows funcionando, com visual HeyyCzer +
identidade Ander Flow; o restante é evolução modular sem regressões.
```

### 17.2 Mensagem para pesquisador A01

```text
Você é A01, pesquisador técnico. Abra cada uma das 11 fontes R01–R11 e
seus links internos de features, docs, changelog, FAQ, repositórios, issues,
releases, políticas e licenças. Pesquise Reddit, YouTube, fóruns e documentação
oficial Microsoft, com data e URLs reais. Produza matriz feature-a-feature,
autor, licença, versão, evidência, possível API, riscos e limitações. Separe
recursos anunciados, observados e testados. Não invente funcionalidades de
páginas inacessíveis. Seu relatório deve atualizar docs/pesquisa/ e gerar
novas tarefas no backlog para lacunas com ID único.
```

### 17.3 Mensagem para diretor de design A03

```text
Você é A03, diretor visual Ander Flow. Use HeyyCzer como referência principal
de estados e microinteração, não como desculpa para copiar ativos indevidos.
Aplique #E8622A, #0A0A0F, #141418, #F5F5F0, #F0F0EB em UI 2D editorial.
Faça tokens, variantes, layouts de ilha recolhida/ativa/expandida, grid de
módulos, dock e configurações. Reduza texto, preserve contraste, sem 3D,
sem verde dominante, sem emojis nativos, sem jitter. Revise screenshots
REAIS e anote correções. Entregue design system e especificações mensuráveis.
```

### 17.4 Mensagem para Windows A07

```text
Você é A07, engenheiro Windows nativo. Implemente overlay sempre no topo da
área correta, click-through fora do hitbox, monitores/DPI, tray, autostart
silencioso e fullscreen auto-hide. Não injete no Explorer nem assuma admin.
Use APIs Windows documentadas, testes Rust, logs diagnósticos e edge cases.
Teste com dual monitor, sleep/resume, mudança de DPI e aplicações fullscreen.
Relate limitações do ambiente real, não confunda sucesso do CI com sucesso
no monitor/PC do usuário.
```

### 17.5 Mensagem para mídia A08

```text
Você é A08, engenheiro de mídia. Faça integração GSMTC REAL com sessão
ativa, título, artista, capa, progresso e controles. Não use música fake.
Teste players compatíveis e não compatíveis. A UI deve lidar com pausa,
seek indisponível, nenhuma sessão, duas sessões, suspensão e retomada.
Documente fontes de API e custo de CPU. Entregue serviço Windows,
contratos de eventos, componentes revisados e testes.
```

### 17.6 Mensagem para segurança A14

```text
Você é A14, segurança e privacidade. Revise permissões Tauri/Win32/WinRT,
plugin SDK, segredos, captura, clipboard, localhost API e atualizador.
Crie testes negativos e uma tabela ameaça/mitigação/evidência. Exija
Origin/Host/CORS/CSRF corretos na API local e consentimento para recursos
sensíveis. Não aprove release com vazamento de token, execução arbitrária,
rede inesperada ou código/asset de licença inadequada.
```

### 17.7 Mensagem para QA A16/A17/A18

```text
Você é revisor independente. Seu trabalho não é elogiar a implementação,
mas tentar quebrá-la: hover jitter, escala DPI, jogos fullscreen, lock/unlock,
monitor desconectado, modo offline, memória/CPU, permissões, instalação e
rollback. Reexecute os testes e capture evidências reproduzíveis.
Atribua nível E0–E6 a cada claim. Reabra tarefas até que os critérios
passem; não promova `[x] FEITO + VALIDADO` sem prova suficiente.
```

### 17.8 Mensagem para GitHub A20

```text
Você é A20, responsável por rastreabilidade. Se houver GitHub conectado e
autorizações válidas, crie/atualize issues e PRs para tarefas reais;
sincronize TAREFAS.json e ACOMPANHAMENTO.md sem editar contagens à mão.
Defina versão, changelog, tags e release conforme gates. Verifique
cada URL antes de exibir. Se não houver acesso, documente comandos
reproduzíveis e marque 'NÃO EXECUTADO'; não forneça URLs inventadas.
```

### 17.9 Política de modelos e custos

- Use modelos mais capazes para decisões de arquitetura, licenças, revisão adversarial e integrações críticas; agentes menores para extração de tabelas, localização, docs e testes triviais.
- Orquestrador avalia custo real, janela de contexto, limites de rate e qualidade; não presumir que nome de modelo significa capacidade de subagentes.
- Evitar duplicar leitura do mesmo repositório em cinco agentes sem compartilhar resultados. Reusar relatórios versionados com URL/commit SHA.
- Não disparar criação massiva de agentes ou workflows que consumam orçamento sem limites explícitos. Implementar por tarefas com orçamento e resultado verificável.
- Se o contexto for compactado, carregar do GitHub/arquivos de progresso, não confiar em memória textual imprecisa.

---

## 18. RELATÓRIO DE ATUALIZAÇÃO — FORMATO OBRIGATÓRIO AO FINAL DE CADA CICLO

```md
# Atualização Ander Flow Prism Island — <data/hora>

**Modelo/orquestrador:** <modelo real>
**Versão atual:** <vX.Y.Z, ou dev>
**Repo real:** <URL ou NÃO CRIADO>
**Commit:** <SHA ou NÃO DISPONÍVEL>
**CI:** <URL/status ou NÃO EXECUTADO>
**Instalador:** <URL ou NÃO GERADO>
**Status de teste Windows real:** <APROVADO / PARCIAL / NÃO TESTADO>

## Realmente executado nesta rodada
| ID | Trabalho | Arquivos/PR | Teste | Estado |
|---|---|---|---|---|
| F-001 | <descrição> | <sha/URL> | <E4 ou E5> | <estado> |

## Checklist agregado
- [ ] A FAZER: <n>
- [~] EM ANDAMENTO: <n>
- [?] AGUARDANDO TESTE: <n>
- [!] ERROS: <n>
- [!] BLOQUEADOS: <n>
- [x] FEITO + VALIDADO: <n>

## Falhas reais e como estão sendo tratadas
- <erro + log resumido + issue + owner + próxima ação>

## Próxima prioridade ÚNICA
- <ID + motivo + critério de aceite + owner>

## Fontes novas verificadas
- <URL exata + o que mudou e confiança>
```

**Proibições no relatório:** dizer `100% concluído` com tarefas não testadas; esconder erro; afirmar que o arquivo `.exe` instala sem ter executado; transformar screenshot de protótipo em "app pronto"; criar links supostos; escrever textos genéricos sobre progresso sem artefatos.

---

## 19. ROTEIRO INICIAL CONCRETO — O QUE A IA DEVE FAZER NO PRIMEIRO TURNO DE EXECUÇÃO

1. **Checar ferramentas:** web, GitHub, ambiente Windows, editores de arquivos, runner de CI, agentes e recursos de pesquisa. Registrar disponíveis e indisponíveis em um parágrafo conciso.
2. **Auditar fontes R01–R11:** extrair recursos, licenças e pontos de design com fonte oficial; tratar especialmente NotNotch não legível, DynamicWin sem código-fonte e WinIsland-X link histórico/inacessível. Não se deter mais que o necessário na primeira fatia de código; abrir tarefas para pesquisa restante.
3. **Decidir arquitetura e licença:** ADR-001 e ADR-002, preferindo o caminho que realmente possa ser compilado/validado.
4. **Verificar e criar o repo** `Ander-Flow-Prism-Island` na conta correta quando a ferramenta GitHub permitir; escolher visibilidade com base em autorização e requisitos de eventual GPL. Registrar URL de criação.
5. **Gerar arquivos reais** com as pastas previstas, README, LICENSE apropriada e design tokens; commit inicial.
6. **Implementar um componente real de ilha** em janela Tauri, com overlay, estados, tray, hover/click, Escape, tema e módulo de música nativo. TDD onde cabível.
7. **Executar `typecheck`, lint, testes Rust/JS e build Windows**. Resolver erros. Não deixar interface com assets de demonstração em produção.
8. **Testar no Windows real** se a máquina/runner permitir; avaliar click-through, hover, mídia, fullscreen e posicionamento. Se houver apenas runner, usar `AGUARDANDO TESTE LOCAL` para hardware-alvo.
9. **Gerar checklist** com os IDs F-001 a F-418, subestados e evidências; status inicial `A FAZER`, depois modificar apenas itens realmente executados.
10. **Abrir PR e acompanhar CI**, integrar após revisão, criar release estável somente se o gate permitir.
11. **Responder ao usuário com links reais**, estatística honesta de status, falhas, uma prioridade seguinte e instruções de instalação em português. Se não houver PC/CI/GitHub, produzir código ou arquivos locais e relatar precisamente o bloqueio.

---

## 20. INSTRUÇÕES DE TESTE NO PC DO USUÁRIO (SOMENTE SE HOUVER ACESSO REAL)

O usuário historicamente prefere **Remote Desktop Commander**, não Work, para execução local, e não quer terminais abrindo/fechando na tela. Para este projeto, quando esse conector estiver **realmente conectado e autorizado**:

1. Verificar status do computador, sessão `pichau` e diretório antes de editar. **Não assumir online, sessão ou permissão com base em conversa anterior.**
2. Local sugerido para clone: pasta `Documentos/Projetos/Ander Flow Prism Island` do usuário ativo, após verificar caminho existente; usar caminhos Windows reais e não sobrescrever projetos existentes.
3. Executar operações de forma silenciosa/não intrusiva, preservando aplicativos em uso. Não roubar foco sem necessidade, não reiniciar máquina e não interromper jogos fullscreen sem autorização explícita.
4. Build e teste em modo dev podem usar ferramentas CLI sem console visível quando suportado pela ferramenta de controle remoto; não tentar ocultar intencionalmente solicitações de permissão ou avisos de segurança.
5. Para rotina `Iniciar com Windows`, configurar via mecanismo por usuário aprovado e validar após reinicialização quando autorizado. Evitar PowerShell `.ps1` bloqueado alterando política global; preferir executável GUI, tarefas apropriadas ou chamadas `.cmd` confiáveis quando necessário.
6. Gravar screenshots de janelas de teste **somente para avaliar a interface do app**. Não capturar outros aplicativos, notificações privadas ou dados sensíveis desnecessários.
7. Guardar gravações/logs de QA em pasta prevista e linkar no checklist; limpar arquivos temporários gerados pelo processo.
8. Se a conexão falhar, não alegar testes locais: deixar `BLOQUEADO: PC não acessível` e prosseguir com CI Windows quando possível.

---

## 21. ERROS CONHECIDOS QUE O ORQUESTRADOR DEVE EVITAR

- Substituir implementação por um protótipo HTML sem funcionalidade Windows.
- Copiar/rebatizar `.exe` de software de terceiro e dizer que virou produto próprio.
- Usar repositório com URL idêntica e fingir que forks foram criados.
- Usar screenshot renderizado artificialmente como prova de funcionalidade.
- Publicar `.exe` antes de testar instalação, desinstalação, tray, autostart e segurança.
- Dizer que WinIsland-X está definitivamente licenciado MIT sem confirmar repositório atual.
- Afirmar que DynamicWin fornece código-fonte utilizável apesar do aviso no README de que seu repo só tem releases.
- Usar Notchify/MyDockFinder/WindowBlinds como fonte de código fechado ou contornar licença.
- Aplicar GPL a código que não foi examinado ou escolher MIT em derivado GPL incompatível.
- Criar 20 agentes que editam os mesmos arquivos em conflito.
- Não preservar `main`, perder tarefas ao compactar contexto ou sobrescrever release anterior.
- Falar que todas as 418 tarefas estão feitas só porque foram listadas.
- Repetir a mesma tarefa sem criar regressão/teste/diagnóstico do erro.
- Deixar captions em inglês, misturar idioma ou exibir mensagens de placeholder.
- Forçar render contínuo consumindo CPU/GPU em games e ultrawide.
- Bloquear cliques em todo o topo da tela por usar janela transparente com hitbox incorreta.
- Fazer a ilha sumir para sempre após remover monitor ou acordar do sleep.
- Criar um autostart via terminal que fica piscando ao longo do dia.
- Alterar shell e deixar Windows sem barra de tarefas na saída/crash.
- Usar promessas de multi-modelo sem APIs/documentação reais ou solicitar senha em texto.
- Copiar segredo do clipboard para logs ou enviar dados pessoais para serviço externo.
- Lançar intervalos recorrentes/polling sem cancelar ao desligar módulo.
- Não publicar instruções de remoção e recuperação do tema original.

---

## 22. CHECKLIST DE RELEASE GATE — APROVAÇÃO FINAL OBRIGATÓRIA

### Código e projeto

- [ ] Repositório real criado/confirmado na conta autorizada.
- [ ] Branch/PR vinculadas a tarefas, sem force-push no `main`.
- [ ] Arquitetura ADR e opção de licença documentadas.
- [ ] Terceiros e atribuições documentados.
- [ ] Typecheck/lint/testes Rust/JS aprovados.
- [ ] Dependências escaneadas sem risco crítico não tratado.
- [ ] Triggers de plugins e integrações têm permissões mínimas.
- [ ] API localhost protegida contra origem externa e requisição maliciosa.
- [ ] Logs limpos de credenciais/dados pessoais.

### Produto e experiência

- [ ] App GUI real abre e fecha sem console visível.
- [ ] Overlay não rouba mouse/click fora da interface.
- [ ] Hover/click/teclado/retorno funcionam.
- [ ] Música e controles validados em player real.
- [ ] Fullscreen e jogo respeitados, sem interferência.
- [ ] DPI/multi-monitor/suspensão tratados e testados no ambiente declarado.
- [ ] Consumo de recursos medido com dados e metodologia.
- [ ] Temas aderentes ao padrão Ander Flow, sem 3D e verde dominante.
- [ ] Sem placeholders mentirosos, textos de debug ou dados falsos em produção.
- [ ] PT-BR completo nas funcionalidades distribuídas.
- [ ] Redução de movimento, contraste, teclado e escalabilidade verificados.

### Distribuição

- [ ] Setup e ZIP portável **realmente gerados** em runner adequado.
- [ ] Teste de instalação e desinstalação aprovado.
- [ ] Autostart opcional, silencioso e removível.
- [ ] Atualização segura sem destruir configurações.
- [ ] Hash SHA-256 calculado e conferido.
- [ ] Tag, versão do binário, nome de arquivo e CHANGELOG coerentes.
- [ ] GitHub Release publicado **somente após gate**.
- [ ] Links diretos abertos/verificados após publicação.
- [ ] Checklist F-001...F-418 atualizado com estados verdadeiros.
- [ ] Questões não concluídas permanecem abertas, com próxima prioridade e owner.

---

## 23. MAPA DE PESQUISA PARA REDDIT, YOUTUBE, GITHUB E FÓRUNS

A pesquisa deve ser executada quando o orquestrador tiver web. Use as consultas seguintes como **pontos de partida**, atualizando ano/versão no momento de execução; não dependa apenas de resumos de buscadores.

### Consultas no YouTube

```text
"HeyyCzer windows dynamic island" desktop walkthrough
"DynamicWin FlorianButz" animations file tray Bluetooth
"Cosmic-light" windows dynamic island demo
"WinIsland X" rust skia liquid glass demo
"WinIsland" Windows Dynamic Island media comparison
"Seelen UI" 2026 Windows 11 docks window manager benchmark
"Notchify" 2026 dynamic island widgets notifications
"MyDockFinder" Windows 11 full setup dock finder
"WindowBlinds 11" themes SkinStudio tutorial
"Windows dynamic island" latency memory FPS performance
```

**Extração obrigatória:** URL real do vídeo, canal, data, versão apresentada, 3–10 interações visíveis, timestamps verificados e limitações. Não concluir que o recurso existe atualmente só porque um vídeo antigo o mostrou.

### Consultas no Reddit e fóruns

```text
site:reddit.com/r/windowsapps "dynamic island" Windows bugs
site:reddit.com/r/Windows11 "dynamic island" notification performance
site:reddit.com "HeyyCzer" "island"
site:reddit.com "Seelen UI" taskbar startup sleep bug
site:reddit.com "Notchify" idle CPU memory
site:reddit.com "DynamicWin" Bluetooth file tray
site:reddit.com "MyDockFinder" CPU ultrawide fullscreen
site:steamcommunity.com/app/1787090 MyDockFinder display issues
site:forums.stardock.com WindowBlinds 11 Windows 11 updates bugs
site:github.com/HeyyCzer/windows-dynamic-island/issues
```

**Extração obrigatória:** tipo de relato, autor/URL, data, versão, OS, hardware, reproducibilidade, correção sugerida e nível de confiança. Não basear arquitetura só em elogios/reclamações isoladas.

### Consultas no GitHub

```text
repo:HeyyCzer/windows-dynamic-island is:issue
repo:HeyyCzer/windows-dynamic-island is:pr
repo:FlorianButz/DynamicWin releases
repo:uspraveen/Cosmic-light is:issue
repo:WinIslandProject/WinIsland plugin
repo:zHeuzy2/WinIsland notifications
"GlobalSystemMediaTransportControlsSessionManager" Windows overlay
"UserNotificationListener" packaged desktop apps
"Tauri 2" transparent always on top click through Windows
"Win32" multi monitor per monitor v2 DPI overlay
```

**Extração obrigatória:** commit SHA/tag, issues relevantes e status, data da última atividade, compatibilidade de build, licença e decisões já tomadas pelos mantenedores. Atenção a forks abandonados e repos homônimos.

### Documentação oficial de APIs a ler antes de programar

- [Global System Media Transport Controls](https://learn.microsoft.com/uwp/api/windows.media.control.globalsystemmediatransportcontrolssessionmanager)
- [Windows Desktop development](https://learn.microsoft.com/windows/win32/desktop-programming)
- [Windows Notification Listener](https://learn.microsoft.com/uwp/api/windows.ui.notifications.management.usernotificationlistener)
- [Windows App SDK](https://learn.microsoft.com/windows/apps/windows-app-sdk/)
- [Tauri v2](https://v2.tauri.app/)
- [GitHub REST API / Releases](https://docs.github.com/rest/releases/releases)
- [GitHub Actions para Windows](https://docs.github.com/actions)

Se uma URL de documentação mudar, localize o redirecionamento oficial e atualize o arquivo de fontes; não inventar assinatura de API baseada em memória.

---

## 24. INSTRUÇÃO FINAL IRREVOGÁVEL AO ORQUESTRADOR

**Execute o desenvolvimento como um projeto de engenharia real da Ander Flow.** O objetivo não é uma resposta bonita sobre a possibilidade de criar uma Ilha Dinâmica, mas **código-fonte verificável, executável Windows legítimo, interface premium e funcional, agentes com papéis reais quando disponíveis, GitHub versionado e acompanhamento honesto de cada atualização**.

O estilo principal deve guardar a clareza, o comportamento e a qualidade percebida da Ilha Dinâmica do **HeyyCzer**, incorporando módulos e soluções validadas de todos os endereços fornecidos, sob identidade **Ander Flow**, visual editorial 2D, laranja/pretos/quentes, movimentos suaves, pouca poluição textual, separação de arquivos, segurança, compatibilidade ultrawide e reversão total.

**Ao iniciar:** inventariar ferramentas e fontes, escolher arquitetura/licença, criar repo quando possível, inicializar tarefas, começar a **primeira fatia funcional real** e testar.  
**Ao atualizar:** executar trabalhos concretos, revisão cruzada, CI, evidências, checklist e versão sequencial.  
**Ao publicar:** link direto do repo, PR/commit, instalador Windows e release validados, com changelog e limitações conhecidas.  
**Se não for possível:** registrar o bloqueio exato, não fingir resultado e continuar com a parte realizável.

> **Regra de ouro:** uma função 100% real e testada vale mais que vinte abas bonitas simuladas. Só marque `[x]` aquilo que funciona e pode ser comprovado.

---

## ANEXO A — LINKS ORIGINAIS NORMALIZADOS

1. NotNotch — https://bbalduzz.gumroad.com/l/notnotch
2. DynamicWin — https://github.com/FlorianButz/DynamicWin
3. Cosmic-light UStack — https://ustack.app/en/products/cosmic-light
4. WinIsland-X — https://fttawa.github.io/WinIsland-X/
5. WinIsland AlternativeTo — https://alternativeto.net/software/winisland/about/
6. Seelen UI — https://seelen.io/pt-BR/apps/seelen-ui
7. Notchify — https://notchify.app/
8. MyDockFinder — https://store.steampowered.com/app/1787090/MyDockFinder/
9. WindowBlinds — https://www.stardock.com/products/windowblinds/
10. WindowBlinds com referer (mesmo produto) — https://www.stardock.com/products/windowblinds/?referer=wincustomize
11. HeyyCzer/windows-dynamic-island — https://github.com/HeyyCzer/windows-dynamic-island

## ANEXO B — FONTES PRIMÁRIAS ADICIONAIS E LIMITAÇÕES DE VERIFICAÇÃO

- HeyyCzer README e licença, vistos em 18/11/2026: https://github.com/HeyyCzer/windows-dynamic-island — recurso de mídias, Claude Code, OCR/busca, clipboard, GitHub, notificações, API local, licenciamento GPL. **Não é teste do app instalado.**
- DynamicWin README, visto em 18/11/2026: https://github.com/FlorianButz/DynamicWin — aviso de repositório de releases sem código-fonte; licença de README CC BY-SA. **Não usar como fonte de código presumidamente reutilizável.**
- Cosmic-light repositório, visto em 18/11/2026: https://github.com/uspraveen/Cosmic-light — UI, mídia, clima, calendário/IA, licença MIT mostrada. **Funcionalidades anunciadas, não instaladas.**
- WinIsland-X, website capturado/indexado em consulta mas posteriormente inacessível; repo esperado retornou 404. Requer confirmação da origem atual antes de uso. URL recebida: https://fttawa.github.io/WinIsland-X/
- fttawa/IslandX, visto em 18/11/2026: https://github.com/fttawa/IslandX — **outro endereço atual localizável**, relação com WinIsland-X não comprovada no âmbito deste documento.
- WinIslandProject/WinIsland, visto em 18/11/2026: https://github.com/WinIslandProject/WinIsland — código e GPL-3.0 declarados.
- zHeuzy2/WinIsland, visto em 18/11/2026: https://github.com/zHeuzy2/WinIsland — outra implementação WinIsland, MIT e recursos de webcam/foco/alertas declarados.
- Seelen oficial, visto em 18/11/2026: https://seelen.io/pt-BR/apps/seelen-ui — dock, tiling, widgets, wallpaper e temas; **não foi testado aqui**.
- Notchify oficial, visto em 18/11/2026: https://notchify.app/ — recurso comercial com avaliação grátis, funções e claims do fornecedor; **não foi testado aqui**.
- MyDockFinder Steam, visto em 18/11/2026: https://store.steampowered.com/app/1787090/MyDockFinder/ — produto comercial.
- WindowBlinds Stardock, visto em 18/11/2026: https://www.stardock.com/products/windowblinds/ — produto comercial.
- Comparação comunitária/relato Seelen: https://www.reddit.com/r/desktops/comments/1rfppcs/any_seelen_ui_alternatives_that_look_similar/ — relato individual, útil para cenários de QA.
- Relato do desenvolvedor Notchify no Reddit: https://www.reddit.com/r/windowsapps/comments/1w7vwfh/notchify_dynamic_island_for_windows_just_got_its/ — tratar performance relatada como alegação até medir.

**A pesquisa desta versão do superprompt não incluiu instalação, engenharia reversa, medição de FPS, leitura de vídeos completos do YouTube ou coleta de cada subpágina/issue. O próprio superprompt delega isso explicitamente aos agentes, quando as ferramentas e os acessos permitirem.**

---

**FIM DO SUPERPROMPT MESTRE — ANDER FLOW PRISM ISLAND — DOCUMENTO 1.0.0**