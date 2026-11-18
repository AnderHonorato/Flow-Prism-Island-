# Segurança

Reporte vulnerabilidades por canal privado ao mantenedor do repositório antes de publicá-las.

O aplicativo atual não oferece API de rede e não faz captura de tela, áudio ou área de transferência. A opção de autoinício altera apenas HKCU\Software\Microsoft\Windows\CurrentVersion\Run, após clique do usuário. Não requer privilégios de administrador.

Não coloque senhas/tokens nos arquivos do repositório. Não habilite shell injection, listeners em 0.0.0.0 ou atualizações executáveis não verificadas.