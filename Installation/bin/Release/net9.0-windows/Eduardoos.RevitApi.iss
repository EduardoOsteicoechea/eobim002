[Setup]
AppName = Eduardoos.RevitApi.Installer
OutputBaseFilename = Eduardoos.RevitApi.Installer
UninstallDisplayName = Eduardoos.RevitApi.Installer
AppVersion = 0.0.1
WizardStyle = modern
DefaultDirName = {autopf}\Eduardoos\Eduardoos.RevitApi
DefaultGroupName = Eduardoos
Compression = lzma2
SolidCompression = yes
LanguageDetectionMethod = uilanguage
ShowLanguageDialog = auto
UsePreviousLanguage = no
DisableDirPage = yes
Uninstallable = yes
CreateUninstallRegKey = yes
[Dirs]
Name:"{userappdata}\Autodesk\Revit\Addins\2023"
Name:"{userappdata}\Autodesk\Revit\Addins\2023\Eduardoos"
Name:"{userappdata}\Autodesk\Revit\Addins\2026"
Name:"{userappdata}\Autodesk\Revit\Addins\2026\Eduardoos"
[Setup]
OutputDir = C:\Users\eduar\Documents\work\internal\eobim002\Installation\bin\Release\net9.0-windows
[Files]
Source:"C:\Users\eduar\Documents\work\internal\eobim002\Revit2023\bin\Release\net48\*"; DestDir:"{userappdata}\Autodesk\Revit\Addins\2023\Eduardoos"; Flags: ignoreversion
Source:"C:\Users\eduar\Documents\work\internal\eobim002\Installation\bin\Release\net9.0-windows\*.addin"; DestDir:"{userappdata}\Autodesk\Revit\Addins\2023"; Flags: ignoreversion
Source:"C:\Users\eduar\Documents\work\internal\eobim002\Revit2026\bin\Release\net8.0-windows7.0\*"; DestDir:"{userappdata}\Autodesk\Revit\Addins\2026\Eduardoos"; Flags: ignoreversion
Source:"C:\Users\eduar\Documents\work\internal\eobim002\Installation\bin\Release\net9.0-windows\*.addin"; DestDir:"{userappdata}\Autodesk\Revit\Addins\2026"; Flags: ignoreversion
