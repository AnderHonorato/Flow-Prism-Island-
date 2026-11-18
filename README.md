# Ander Flow Prism Island

Ilha dinâmica nativa e gratuita para Windows 11, com foco em rapidez e personalização 2D, desenvolvida pela Ander Flow.

**Situação:** v0.1.0-dev (fase inicial; não é release estável).

## O que já existe no código
- Janela WPF real, transparente, sem moldura e sempre visível; cápsula compacta que expande no mouse/clique.
- Painel recolhível com estado fixado, animação de abertura e atalho global Ctrl+Shift+Espaço (se disponível).
- Temporizador real de 25 minutos, com iniciar, pausar e reiniciar.
- Hora, resolução do monitor principal, RAM consumida pelo aplicativo e tempo ativo do Windows.
- Temas Prism Flow, Fosco Claro, Monocromático e Preto Clássico.
- Ícone da bandeja com opção de mostrar, recolher e sair.
- Configurações locais por usuário; autoinício somente por escolha explícita.

## O que ainda não deve ser considerado pronto
Controle de mídia GSMTC, detecção de fullscreen, multi-monitor avançado, notificações de terceiros, instalador assinado e integrações externas. Consulte `docs/ACOMPANHAMENTO.md`.

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