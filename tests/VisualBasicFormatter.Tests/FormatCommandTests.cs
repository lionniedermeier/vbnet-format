using VisualBasicFormatter;
using VisualBasicFormatter.Cli;

namespace VisualBasicFormatter.Tests;

public sealed class FormatCommandTests : IDisposable
{
    private const int ExitOk = 0;
    private const int ExitWouldChange = 1;

    private const string Unformatted =
        "Module M\r\nSub S()\r\nDim x = 1\r\nEnd Sub\r\nEnd Module\r\n";

    private readonly string _root = Path.Combine(
        Path.GetTempPath(),
        "vbfmt-tests",
        Guid.NewGuid().ToString("n")
    );

    public FormatCommandTests() => Directory.CreateDirectory(_root);

    public void Dispose() => Directory.Delete(_root, recursive: true);

    [Fact]
    public void RewritesTheFileInPlace()
    {
        var file = Write("Sample.vb", Unformatted);
        var output = new StringWriter();

        Run(output, verbose: true);

        Assert.Equal(Formatted(Unformatted), File.ReadAllText(file));
        Assert.Matches(@"^Sample\.vb \d+ms$", Line(output, "Sample.vb"));
        Assert.DoesNotContain("Dim x = 1", output.ToString());
    }

    [Fact]
    public void ReportsAnAlreadyFormattedFileAsUnchanged()
    {
        var file = Write("Sample.vb", Formatted(Unformatted));
        var output = new StringWriter();

        Run(output, verbose: true);

        Assert.Equal(Formatted(Unformatted), File.ReadAllText(file));
        Assert.Matches(@"^Sample\.vb \d+ms \(unchanged\)$", Line(output, "Sample.vb"));
    }

    [Fact]
    public void UsesForwardSlashesForNestedPaths()
    {
        Directory.CreateDirectory(Path.Combine(_root, "sub"));
        Write(Path.Combine("sub", "Nested.vb"), Unformatted);
        var output = new StringWriter();

        Run(output, verbose: true);

        Assert.Matches(@"^sub/Nested\.vb \d+ms$", Line(output, "Nested.vb"));
    }

    [Fact]
    public void PrintsASummaryLine()
    {
        Write("Changed.vb", Unformatted);
        Write("Kept.vb", Formatted(Unformatted));
        var output = new StringWriter();

        Run(output, summary: true);

        Assert.Contains("1 formatted, 1 unchanged in ", output.ToString());
    }

    [Fact]
    public void IsSilentWithoutVerboseOrSummary()
    {
        var file = Write("Sample.vb", Unformatted);
        var output = new StringWriter();

        Run(output);

        Assert.Equal(Formatted(Unformatted), File.ReadAllText(file));
        Assert.Equal(string.Empty, output.ToString());
    }

    [Fact]
    public void SummaryWithoutVerbosePrintsNoPerFileLine()
    {
        Write("Changed.vb", Unformatted);
        var output = new StringWriter();

        Run(output, summary: true);

        Assert.Contains("1 formatted, 0 unchanged in ", output.ToString());
        Assert.DoesNotContain("Changed.vb", output.ToString());
    }

    [Fact]
    public void CheckLeavesTheFileUntouchedAndReportsIt()
    {
        var file = Write("Sample.vb", Unformatted);
        var output = new StringWriter();

        var exitCode = Run(output, mode: RunMode.Check);

        Assert.Equal(ExitWouldChange, exitCode);
        Assert.Equal(Unformatted, File.ReadAllText(file));
        Assert.Contains("Sample.vb: would be reformatted.", output.ToString());
    }

    [Fact]
    public void CheckOnAnAlreadyFormattedFileReturnsSuccessWithNoOutput()
    {
        var file = Write("Sample.vb", Formatted(Unformatted));
        var output = new StringWriter();

        var exitCode = Run(output, mode: RunMode.Check);

        Assert.Equal(ExitOk, exitCode);
        Assert.Equal(Formatted(Unformatted), File.ReadAllText(file));
        Assert.Equal(string.Empty, output.ToString());
    }

    [Fact]
    public void DiffPrintsAUnifiedDiffAndLeavesTheFileUntouched()
    {
        var file = Write("Sample.vb", Unformatted);
        var output = new StringWriter();

        var exitCode = Run(output, mode: RunMode.Diff);

        Assert.Equal(ExitWouldChange, exitCode);
        Assert.Equal(Unformatted, File.ReadAllText(file));
        Assert.Contains($"--- {file}", output.ToString());
        Assert.Contains($"+++ {file}", output.ToString());
    }

    [Fact]
    public void FormatCommandNoLongerHasAWriteOption()
    {
        var options = CliCommands.CreateFormatCommand().Options;

        Assert.DoesNotContain(
            options,
            option => option.Name == "--write" || option.Aliases.Contains("-w")
        );
    }

    [Fact]
    public void CheckCommandAcceptsDiff()
    {
        var parseResult = CliCommands.CreateCheckCommand().Parse(["--diff"]);

        Assert.Empty(parseResult.Errors);
    }

    private int Run(
        TextWriter output,
        RunMode mode = RunMode.Format,
        bool verbose = false,
        bool summary = false
    ) =>
        Program.RunFiles(
            [_root],
            _root,
            IgnoreSet.Empty,
            new FormatterEngine(new OptionOverrides()),
            mode,
            verbose,
            summary,
            output
        );

    private static string[] Lines(TextWriter output) =>
        (output.ToString() ?? string.Empty)
            .Split('\n')
            .Select(line => line.TrimEnd('\r'))
            .ToArray();

    private static string Line(TextWriter output, string contains) =>
        Lines(output).Single(line => line.Contains(contains));

    private static string Formatted(string source) => VbFormatter.Format(source).Text;

    private string Write(string name, string content)
    {
        var path = Path.Combine(_root, name);
        File.WriteAllText(path, content);
        return path;
    }
}
