using System.Runtime.CompilerServices;

namespace VisualBasicFormatter.Tests;

/// <summary>Finds the golden-file cases under <c>TestData</c>.</summary>
public static class TestCases
{
    /// <summary>
    /// Source directory rather than the output directory, so that regenerating the expectation
    /// files hits the files in the repository.
    /// </summary>
    public static string Directory { get; } = Path.GetDirectoryName(ThisFile())!;

    /// <summary>All input files; the corresponding <c>*.expected.vb</c> are excluded.</summary>
    public static TheoryData<string> Names()
    {
        var data = new TheoryData<string>();

        foreach (var name in All())
        {
            data.Add(name);
        }

        return data;
    }

    /// <inheritdoc cref="Names"/>
    public static IEnumerable<string> All() =>
        System.IO.Directory.EnumerateFiles(Directory, "*.vb")
            .Where(f => !f.EndsWith(".expected.vb", StringComparison.OrdinalIgnoreCase))
            .Order(StringComparer.Ordinal)
            .Select(Path.GetFileNameWithoutExtension)
            .Select(name => name!);

    public static string ReadInput(string name) =>
        File.ReadAllText(Path.Combine(Directory, name + ".vb"));

    public static string ExpectedPath(string name) =>
        Path.Combine(Directory, name + ".expected.vb");

    private static string ThisFile([CallerFilePath] string path = "") => path;
}
