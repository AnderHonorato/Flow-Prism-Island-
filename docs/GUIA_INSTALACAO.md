# Instalador Windows

**Status:** prévia de desenvolvimento `v0.1.0-preview.1`, não versão estável.

Baixe o instalador por **Releases** do repositório:
https://github.com/AnderHonorato/Flow-Prism-Island-/releases

O instalador `Ander-Flow-Prism-Island-v0.1.0-win-x64-setup.exe`:
- inclui o executável Win-x64 autocontido com runtime .NET.
- oferece instalação em `%LOCALAPPDATA%\Programs\Ander Flow\Prism Island`, sem direitos de administrador.
- cria atalho no Menu Iniciar e oferece atalho na Área de Trabalho.
- permite desinstalar em Configurações → Aplicativos → Aplicativos instalados.
- não ativa autoinício sem pedido do usuário.
- não precisa de npm, Rust, Python, Git ou SDK .NET no computador de quem instala.

**QA local de 18/11/2026:** criação do instalador Inno Setup 6.7.3 sem erros, instalação silenciosa em diretório temporário = código 0; aplicação encontrada; desinstalador encontrado e remoção = código 0. A conta Pichau estava com sessão gráfica desconectada, então teste visual de overlay no monitor real ainda está aberto.

Instalador ainda não assinado digitalmente, portanto o SmartScreen pode avisar. Não desative a proteção: só execute após verificar autoria e integridade.