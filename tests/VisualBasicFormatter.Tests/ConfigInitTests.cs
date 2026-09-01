using VisualBasicFormatter;
using VisualBasicFormatter.Cli;

namespace VisualBasicFormatter.Tests;

public sealed class ConfigInitTests : IDisposable
{
    private const int ExitOk = 0;
    private const int ExitError = 2;

    private readonly string _root = Path.Combine(
        Path.GetTempPath(), "vbnet-format-tests", Guid.NewGuid().ToString("n"));

    private string ConfigPath => Path.Combine(_root, ".vbnet-format.json");

    public ConfigInitTests() => Directory.CreateDirectory(_root);

    public void Dispose() => Directory.Delete(_root, recursive: true);

    [Fact]
    public void WritesAFileThatLoadsBackAsTheDefaults()
    {
        Assert.Equal(ExitOk, Program.RunInit(_root, force: false));

        var loaded = ConfigFile.Load(ConfigPath).ApplyTo(new FormatterOptions());

        Assert.Equal(new FormatterOptions(), loaded);
    }

    [Fact]
    public void WritesEveryOption()
    {
        Program.RunInit(_root, force: false);

        var config = ConfigFile.Load(ConfigPath);

        Assert.NotNull(config.MaxLineLength);
        Assert.NotNull(config.IndentSize);
        Assert.NotNull(config.UseTabs);
        Assert.NotNull(config.EndOfLine);
        Assert.NotNull(config.LanguageVersion);
        Assert.NotNull(config.OrganizeImports);
    }

    [Fact]
    public void RefusesToOverwriteWithoutForce()
    {
        File.WriteAllText(ConfigPath, "{ \"IndentSize\": 2 }");

        Assert.Equal(ExitError, Program.RunInit(_root, force: false));
        Assert.Equal("{ \"IndentSize\": 2 }", File.ReadAllText(ConfigPath));
    }

    [Fact]
    public void ForceOverwritesAnExistingFile()
    {
        File.WriteAllText(ConfigPath, "{ \"IndentSize\": 2 }");

        Assert.Equal(ExitOk, Program.RunInit(_root, force: true));

        var loaded = ConfigFile.Load(ConfigPath).ApplyTo(new FormatterOptions());

        Assert.Equal(new FormatterOptions(), loaded);
    }
}
