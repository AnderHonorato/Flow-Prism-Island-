#define NomeApp "Ander Flow Prism Island"
#define VersaoApp "0.4.0"
#define Executavel "AnderFlowPrismIsland.exe"

[Setup]
AppId={{6A8E4294-A759-4C39-A228-ECF9044F1925}
AppName={#NomeApp}
AppVersion={#VersaoApp}
AppVerName={#NomeApp} {#VersaoApp}
AppPublisher=Ander Flow
DefaultDirName={localappdata}\Programs\Ander Flow\Prism Island
DefaultGroupName=Ander Flow
DisableProgramGroupPage=yes
PrivilegesRequired=lowest
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
OutputDir=..\dist
OutputBaseFilename=Ander-Flow-Prism-Island-v0.4.0-win-x64-setup
SetupIconFile=..\apps\desktop\Assets\prism.ico
UninstallDisplayIcon={app}\{#Executavel}
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
SetupLogging=yes
CloseApplications=yes
RestartApplications=no
UsePreviousAppDir=yes
DisableDirPage=no
DisableWelcomePage=no
AllowNoIcons=yes
MinVersion=10.0
ChangesAssociations=no
ChangesEnvironment=no
ShowLanguageDialog=no
LanguageDetectionMethod=uilanguage
VersionInfoVersion=0.4.0.0
VersionInfoCompany=Ander Flow
VersionInfoDescription=Instalador do Ander Flow Prism Island
VersionInfoProductName={#NomeApp}

[Languages]
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"

[Tasks]
Name: "desktopicon"; Description: "Criar atalho na área de trabalho"; GroupDescription: "Atalhos:"; Flags: unchecked

[Files]
Source: "..\dist\portable\{#Executavel}"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\Ander Flow Prism Island"; Filename: "{app}\{#Executavel}"; WorkingDir: "{app}"
Name: "{autodesktop}\Ander Flow Prism Island"; Filename: "{app}\{#Executavel}"; WorkingDir: "{app}"; Tasks: desktopicon

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueName: "AnderFlowPrismIsland"; Flags: uninsdeletevalue

[Run]
Filename: "{app}\{#Executavel}"; Description: "Abrir Ander Flow Prism Island"; Flags: nowait postinstall skipifsilent