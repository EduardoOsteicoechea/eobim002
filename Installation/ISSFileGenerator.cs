internal class ISSFileGenerator : InstallationFileGenerator
{
    public ISSFileGenerator
    (
        string solutionDirectoryPath,
        Dictionary<string, string> outputDirectoriesPaths,
        string fileExtension = "iss"
    )
        : base(solutionDirectoryPath, fileExtension)
    {
        DataCollector.AppendLine("[Setup]");
        DataCollector.AppendLine($"AppName = {Constants.AppName}.Installer");
        DataCollector.AppendLine($"OutputBaseFilename = {Constants.AppName}.Installer");
        DataCollector.AppendLine($"UninstallDisplayName = {Constants.AppName}.Installer");
        DataCollector.AppendLine($"AppVersion = 0.0.1");
        DataCollector.AppendLine($"WizardStyle = modern");
        DataCollector.AppendLine($@"DefaultDirName = {{autopf}}\Eduardoos\{Constants.AppName}");
        DataCollector.AppendLine($@"DefaultGroupName = Eduardoos");
        DataCollector.AppendLine($@"Compression = lzma2");
        DataCollector.AppendLine($@"SolidCompression = yes");
        DataCollector.AppendLine($@"LanguageDetectionMethod = uilanguage");
        DataCollector.AppendLine($@"ShowLanguageDialog = auto");
        DataCollector.AppendLine($@"UsePreviousLanguage = no");
        DataCollector.AppendLine($@"DisableDirPage = yes");
        DataCollector.AppendLine($@"Uninstallable = yes");
        DataCollector.AppendLine($@"CreateUninstallRegKey = yes");

        DataCollector.AppendLine($@"[Dirs]");
        foreach (KeyValuePair<string, string> item in outputDirectoriesPaths)
        {
            DataCollector.AppendLine($@"Name:""{{userappdata}}\Autodesk\Revit\Addins\{item.Key}""");
            DataCollector.AppendLine($@"Name:""{{userappdata}}\Autodesk\Revit\Addins\{item.Key}\Eduardoos""");
        }

        DataCollector.AppendLine($@"[Setup]");
        DataCollector.AppendLine($"OutputDir = {OutputDirectoryPath}");

        DataCollector.AppendLine($@"[Files]");
        foreach (KeyValuePair<string, string> item in outputDirectoriesPaths)
        {
            DataCollector.AppendLine($@"Source:""{item.Value}\*""; DestDir:""{{userappdata}}\Autodesk\Revit\Addins\{item.Key}\Eduardoos""; Flags: ignoreversion");
            DataCollector.AppendLine($@"Source:""{OutputDirectoryPath}\*.addin""; DestDir:""{{userappdata}}\Autodesk\Revit\Addins\{item.Key}""; Flags: ignoreversion");
        }
    }
}