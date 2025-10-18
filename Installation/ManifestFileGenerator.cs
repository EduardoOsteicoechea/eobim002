internal class ManifestFileGenerator : InstallationFileGenerator
{
    public ManifestFileGenerator
    (
        string solutionDirectoryPath,
        string fileExtension = "addin"
    )
        : base(solutionDirectoryPath, fileExtension)
    {
        DataCollector.AppendLine($"<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        DataCollector.AppendLine($"<RevitAddIns>");
        DataCollector.AppendLine($"<AddIn Type=\"{Constants.ApplicationType}\">");
        DataCollector.AppendLine($"<Name>{Constants.AppName}</Name>");
        DataCollector.AppendLine($"<Assembly>Eduardoos/{Constants.AppName}.dll</Assembly>");
        DataCollector.AppendLine($"<AddInId>{Constants.AddInId}</AddInId>");
        DataCollector.AppendLine($"<FullClassName>{Constants.AppName}.{Constants.BaseClassName}</FullClassName>");
        DataCollector.AppendLine($"<VendorId>{Constants.VendorId}</VendorId>");
        DataCollector.AppendLine($"<VendorDescription>{Constants.VendorDescription}</VendorDescription>");
        DataCollector.AppendLine($"</AddIn>");
        DataCollector.AppendLine($"</RevitAddIns>");
    }
}