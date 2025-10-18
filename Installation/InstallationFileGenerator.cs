using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class InstallationFileGenerator : IInstallationFileGenerator
{
    public string SolutionDirectoryPath { get; set; }
    public string OutputDirectoryPath { get; set; }
    public string FileFullPath { get; set; }
    public StringBuilder DataCollector { get; set; } = new StringBuilder();
    public InstallationFileGenerator
    (
        string solutionDirectoryPath,
        string fileExtension
    )
    {
        SolutionDirectoryPath = solutionDirectoryPath;
        OutputDirectoryPath = Path.Combine(SolutionDirectoryPath, "Installation", "bin", "Release", "net9.0-windows");
        FileFullPath = Path.Combine(OutputDirectoryPath, $"{Constants.AppName}.{fileExtension}");
    }

    public void GenerateFile()
    {
        var manifestFilePath = Path.Combine(OutputDirectoryPath, FileFullPath);
        File.WriteAllText(manifestFilePath, DataCollector.ToString());
    }
}