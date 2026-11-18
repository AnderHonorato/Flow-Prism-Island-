# ADR-001 — Stack do desktop

Data: 2026-11-18. Status: decisão provisória para o primeiro incremento.

## Contexto
O superprompt prioriza Tauri 2 + Rust + React/TS, porém no PC Windows Pichau há SDK .NET 10 e não há rustc/cargo/MSVC identificados no PATH. O objetivo imediato é entregar uma janela overlay real, compilável e com testes locais.

## Alternativas avaliadas
- Tauri 2 + Rust + React: UI web flexível, interoperabilidade Rust, precisa toolchain Rust/MSVC/WebView2; não medido.
- .NET 10 + WPF: build disponível, API nativa Windows, tray e janela transparente sem dependências externas; escolhido para este incremento; não medido quanto à RAM/CPU idle.
- Rust + Skia/wgpu: controle fino de desenho, maior complexidade e dependências; não medido.

## Decisão
WPF/.NET 10 apenas para entregar e testar a primeira fatia nativa sem instalar ferramentas/alterar políticas de execução. A mudança frente à stack preferida do superprompt deve ser reavaliada antes de módulos avançados. Testar consumo de RAM/CPU, multimonitor, fullscreen e GSMTC antes de fixar arquitetura de longo prazo.

## Riscos
.NET 10 self-contained é maior que runtime compartilhado; WPF é exclusivo Windows; o superprompt propõe separação front/backend em Tauri. Não relatar Tauri como implementado.