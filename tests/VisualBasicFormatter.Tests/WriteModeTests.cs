using VisualBasicFormatter;
using VisualBasicFormatter.Cli;

namespace VisualBasicFormatter.Tests;

public sealed class WriteModeTests : IDisposable
{
    private const int ExitOk = 0;

    private const string Unformatted =
        "Module M\r\nSub S()\r\nDim x = 1\r\nEnd Sub\r\nEnd Module\r\n";

    private readonly string _root = Path.Combine(
        Path.GetTempPath(), "vbnet-format-tests", Guid.NewGuid().ToString("n"));

    public WriteModeTests() => Directory.CreateDirectory(_root);

    public void Dispose() => Directory.Delete(_root, recursive: true);

    [Fact]
    public void PrintsTheFormattedSourceToStandardOutput()
    {
        var file = Write("Sample.vb", Unformatted);
        var output = new StringWriter();

        Run(output);

        Assert.Equal(Formatted(Unformatted), output.ToString());
    }

    [Fact]
    public void LeavesTheFileUntouchedWithoutWrite()
    {
        var file = Write("Sample.vb", Unformatted);

        Run(new StringWriter());

        Assert.Equal(Unformatted, File.ReadAllText(file));
    }

    [Fact]
    public void PrintsAFileThatIsAlreadyFormatted()
    {
        var formatted = Formatted(Unformatted);
        Write("Sample.vb", formatted);
        var output = new StringWriter();

        Run(output);

        Assert.Equal(formatted, output.ToString());
    }

    [Fact]
    public void ConcatenatesEveryFile()
    {
        Write("A.vb", Unformatted);
        Write("B.vb", Unformatted);
        var output = new StringWriter();

        Run(output);

        Assert.Equal(Formatted(Unformatted) + Formatted(Unformatted), output.ToString());
    }

    [Fact]
    public void WriteRewritesTheFileInPlace()
    {
        var file = Write("Sample.vb", Unformatted);
        var output = new StringWriter();

        Run(output, write: true);

        Assert.Equal(Formatted(Unformatted), File.ReadAllText(file));
        Assert.Contains($"{file}: formatted.", output.ToString());
        Assert.DoesNotContain("Dim x = 1", output.ToString());
    }

    [Fact]
    public void WriteLeavesAnAlreadyFormattedFileAlone()
    {
        Write("Sample.vb", Formatted(Unformatted));
        var output = new StringWriter();

        Run(output, write: true);

        Assert.DoesNotContain(": formatted.", output.ToString());
    }

    [Fact]
    public void PrintingReturnsSuccess()
    {
        Write("Sample.vb", Unformatted);

        Assert.Equal(ExitOk, Run(new StringWriter()));
    }

    private int Run(TextWriter output, bool write = false) =>
        Program.RunFiles([_root], IgnoreSet.Empty, new FormatterOptions(), write, check: false, diff: false, output);

    private static string Formatted(string source) => VbFormatter.Format(source).Text;

    private string Write(string name, string content)
    {
        var path = Path.Combine(_root, name);
        File.WriteAllText(path, content);
        return path;
    }
}
