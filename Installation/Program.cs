internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var solutionDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));

            var supportedRevitVersions = new List<int> { 2023, 2026 };

            var manifestFileGenerator = new ManifestFileGenerator(solutionDirectory);

            var outputPaths = new SupportedRevitVersionsOutputPathManager(
                solutionDirectory,
                supportedRevitVersions,
                manifestFileGenerator
                );

            Console.WriteLine(outputPaths.PrintOutputPathsFiles());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
        }

        Console.WriteLine($"Press any key to exit.");

        Console.ReadLine();
    }
}