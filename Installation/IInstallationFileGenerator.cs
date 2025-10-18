using System.Text;

internal interface IInstallationFileGenerator
{
    string SolutionDirectoryPath { get; set; }
    string OutputDirectoryPath { get; set; }
    string FileFullPath { get; set; }
    StringBuilder DataCollector { get; set; }
    void GenerateFile();
}