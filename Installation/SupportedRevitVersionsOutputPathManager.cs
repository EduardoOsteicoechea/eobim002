using System.Text;
internal class SupportedRevitVersionsOutputPathManager
{
    private string SolutionDirectory { get; set; } = string.Empty;
    private List<int> SupportedRevitVersions { get; set; } = new List<int>();
    private IInstallationFileGenerator? ManifestFileGenerator { get; set; } = null;
    private ISSFileGenerator? ISSFileGenerator { get; set; } = null;
    private ECompilationConfiguration? CompilationConfiguration { get; set; } = ECompilationConfiguration.Release;
    private Dictionary<string, string> OutputDirectoriesPaths { get; } = new Dictionary<string, string>();
    private List<Dictionary<string, List<string>>> OutputPathsFilesPaths { get; set; } = new List<Dictionary<string, List<string>>>();

    public SupportedRevitVersionsOutputPathManager
    (
        string solutionDirectory,
        List<int> supportedRevitVersions,
        IInstallationFileGenerator manifestFileGenerator,
        ECompilationConfiguration compilationConfiguration = ECompilationConfiguration.Release
    )
    {
        SetCriticalVariables(
            solutionDirectory,
            supportedRevitVersions,
            manifestFileGenerator,
            compilationConfiguration
            );

        GeneratePaths();

        GetOutputPathsFilesPaths();

        GenerateManifestFile();

        GenerateISSFile();
    }

    public void SetCriticalVariables
    (
        string solutionDirectory,
        List<int> supportedRevitVersions,
        IInstallationFileGenerator manifestFileGenerator,
        ECompilationConfiguration compilationConfiguration
    )
    {
        SolutionDirectory = solutionDirectory;
        SupportedRevitVersions = supportedRevitVersions;
        ManifestFileGenerator = manifestFileGenerator;
        CompilationConfiguration = compilationConfiguration;
    }

    public void GenerateManifestFile()
    {
        if (ManifestFileGenerator is null)
        {
            throw new ArgumentNullException(nameof(ManifestFileGenerator));
        }

        ManifestFileGenerator?.GenerateFile();
    }

    public void GenerateISSFile()
    {
        ISSFileGenerator = new ISSFileGenerator(SolutionDirectory, OutputDirectoriesPaths);
        ISSFileGenerator.GenerateFile();
    }

    public Dictionary<string, string> GeneratePaths()
    {
        foreach (int version in SupportedRevitVersions)
        {
            var path = string.Empty;
            var compilationConfiguration = CompilationConfiguration.Equals(ECompilationConfiguration.Release) ? "Release" : "Debug";

            if (version <= 2024)
            {
                path = Path.Combine(
                    SolutionDirectory,
                    $"Revit{version}",
                    "bin",
                    compilationConfiguration,
                    "net48"
                    );
            }
            else
            {
                path = Path.Combine(
                    SolutionDirectory,
                    $"Revit{version}",
                    "bin",
                    compilationConfiguration,
                    "net8.0-windows7.0"
                    );
            }

            OutputDirectoriesPaths.Add(version.ToString(), path);
        }

        return OutputDirectoriesPaths;
    }

    public string PrintOutputPaths() => string.Join('\n', OutputDirectoriesPaths);

    public string PrintOutputPathsStatus()
    {
        var result = new StringBuilder();

        foreach (KeyValuePair<string, string> item in OutputDirectoriesPaths)
        {
            if (!DirectoryPathIsValid(item.Value))
            {
                result.AppendLine($"[FAIL] {item.Value}");
            }
            else
            {
                result.AppendLine($"[OK] {item.Value}");
            }
        }

        return result.ToString();
    }

    public bool DirectoryPathsAreValid()
    {
        foreach (KeyValuePair<string, string> item in OutputDirectoriesPaths)
        {
            if (!DirectoryPathIsValid(item.Value))
            {
                return false;
            }
        }

        return true;
    }

    public bool DirectoryPathIsValid(string path)
    {
        if (!Directory.Exists(path))
        {
            Console.WriteLine($"Not exists: {path}");
            return false;
        }

        return true;
    }

    public bool FilePathIsValid(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"Not exists: {path}");
            return false;
        }

        return true;
    }

    public List<Dictionary<string, List<string>>> GetOutputPathsFilesPaths()
    {
        foreach (KeyValuePair<string, string> item in OutputDirectoriesPaths)
        {
            var dictionary = new Dictionary<string, List<string>>();
            dictionary.Add(item.Key, Directory.GetFiles(item.Value).ToList());
            OutputPathsFilesPaths.Add(dictionary);
        }

        return OutputPathsFilesPaths;
    }

    public string PrintOutputPathsFiles()
    {
        var result = new StringBuilder();

        foreach (Dictionary<string, List<string>> item in OutputPathsFilesPaths)
        {
            foreach (KeyValuePair<string, List<string>> item2 in item)
            {
                result.AppendLine();
                result.AppendLine(item2.Key);
                result.AppendLine();
                foreach (string item3 in item2.Value)
                {
                    if (!FilePathIsValid(item3))
                    {
                        result.AppendLine($"[FAIL] {item3}");
                    }
                    else
                    {
                        result.AppendLine($"[OK] {item3}");
                    }
                }
            }
        }

        return result.ToString();
    }
}