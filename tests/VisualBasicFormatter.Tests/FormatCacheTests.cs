using System.Text.RegularExpressions;
using VisualBasicFormatter;
using VisualBasicFormatter.Cli;

namespace VisualBasicFormatter.Tests;

public sealed class FormatCacheTests : IDisposable
{
    private const string Unformatted =
        "Module M\r\nSub S()\r\nDim x = 1\r\nEnd Sub\r\nEnd Module\r\n";

    private const string Broken = "Module M\r\nSub S(\r\nEnd Module\r\n";

    private readonly string _root = Path.Combine(
        Path.GetTempPath(),
        "vbfmt-tests",
        Guid.NewGuid().ToString("n")
    );

    private readonly string _cachePath;

    public FormatCacheTests()
    {
        Directory.CreateDirectory(_root);
        _cachePath = Path.Combine(_root, "cache.json");
    }

    public void Dispose() => Directory.Delete(_root, recursive: true);

    [Fact]
    public void SecondRunReportsTheFileAsCached()
    {
        var directory = Path.Combine(_root, "src");
        Directory.CreateDirectory(directory);
        Write(directory, "Sample.vb", Unformatted);

        Run(directory);
        var output = new StringWriter();
        Run(directory, output);

        Assert.Contains("Sample.vb", Line(output, "Sample.vb"));
        Assert.Contains("(cached)", Line(output, "Sample.vb"));
    }

    [Fact]
    public void AnEditAfterTheFirstRunMissesTheCache()
    {
        var directory = Path.Combine(_root, "src");
        Directory.CreateDirectory(directory);
        var file = Write(directory, "Sample.vb", Unformatted);

        Run(directory);
        File.WriteAllText(file, Unformatted.Replace("Dim x = 1", "Dim y = 2"));
        var output = new StringWriter();
        Run(directory, output, verbose: true);

        Assert.DoesNotContain("(cached)", Line(output, "Sample.vb"));
    }

    [Fact]
    public void ADifferentPrintWidthMissesTheCache()
    {
        var directory = Path.Combine(_root, "src");
        Directory.CreateDirectory(directory);
        Write(directory, "Sample.vb", Unformatted);

        Run(directory);
        var output = new StringWriter();
        Run(directory, output, overrides: new OptionOverrides { PrintWidth = 80 });

        Assert.DoesNotContain("(cached)", Line(output, "Sample.vb"));
    }

    [Fact]
    public void SaveAndLoadRoundTripTheChecksum()
    {
        var directory = Path.Combine(_root, "src");
        Directory.CreateDirectory(directory);
        var file = Write(directory, "Sample.vb", Unformatted);

        Run(directory);

        var json = File.ReadAllText(_cachePath);
        Assert.Contains(file.Replace("\\", "\\\\"), json);

        var reloaded = FormatCache.Load(_cachePath);
        var checksum = FormatCache.Checksum(
            VbFormatter.Format(Unformatted).Text,
            new FormatterEngine(new OptionOverrides()).OptionsFor(file)
        );
        Assert.True(reloaded.IsUpToDate(file, checksum));
    }

    [Fact]
    public void ChecksumsAre16UppercaseHexDigits()
    {
        var directory = Path.Combine(_root, "src");
        Directory.CreateDirectory(directory);
        Write(directory, "Sample.vb", Unformatted);

        Run(directory);

        var json = File.ReadAllText(_cachePath);
        var matches = Regex.Matches(json, "\"([0-9A-F]{16})\"");
        Assert.NotEmpty(matches);
    }

    [Fact]
    public void ACorruptCacheFileLoadsAsEmpty()
    {
        File.WriteAllText(_cachePath, "{ not json");

        var cache = FormatCache.Load(_cachePath);

        Assert.False(cache.IsUpToDate("anything.vb", "0000000000000000"));
    }

    [Fact]
    public void AFileWithParseErrorsIsNotRecorded()
    {
        var directory = Path.Combine(_root, "src");
        Directory.CreateDirectory(directory);
        Write(directory, "Broken.vb", Broken);

        Run(directory);

        Assert.False(File.Exists(_cachePath));
    }

    [Fact]
    public void NoCacheIsOnlyOnTheFormatCommand()
    {
        var formatResult = CliCommands.CreateFormatCommand().Parse(["--no-cache"]);

        Assert.Empty(formatResult.Errors);
        Assert.DoesNotContain(
            CliCommands.CreateCheckCommand().Options,
            option => option.Name == "--no-cache"
        );
    }

    private int Run(
        string directory,
        TextWriter? output = null,
        bool verbose = true,
        OptionOverrides? overrides = null
    ) =>
        Program.RunFiles(
            [directory],
            directory,
            IgnoreSet.Empty,
            new FormatterEngine(overrides ?? new OptionOverrides()),
            RunMode.Format,
            verbose,
            summary: false,
            output ?? new StringWriter(),
            FormatCache.Load(_cachePath)
        );

    private static string Line(TextWriter output, string contains) =>
        (output.ToString() ?? string.Empty)
            .Split('\n')
            .Select(line => line.TrimEnd('\r'))
            .Single(line => line.Contains(contains));

    private static string Write(string directory, string name, string content)
    {
        var path = Path.Combine(directory, name);
        File.WriteAllText(path, content);
        return path;
    }
}
