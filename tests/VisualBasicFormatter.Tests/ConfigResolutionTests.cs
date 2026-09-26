using VisualBasicFormatter;
using VisualBasicFormatter.Cli;

namespace VisualBasicFormatter.Tests;

public sealed class ConfigResolutionTests : IDisposable
{
    private readonly string _root = Path.Combine(
        Path.GetTempPath(),
        "vbfmt-tests",
        Guid.NewGuid().ToString("n")
    );

    public ConfigResolutionTests() => Directory.CreateDirectory(_root);

    public void Dispose() => Directory.Delete(_root, recursive: true);

    [Fact]
    public void ResolvesEachFileAgainstItsOwnNearestConfig()
    {
        WriteConfig(Path.Combine(_root, ".vbfmtrc"), """{ "printWidth": 100 }""");
        WriteConfig(Path.Combine(_root, "domain", ".vbfmtrc"), """{ "indentSize": 2 }""");
        var mainForm = WriteVb(Path.Combine(_root, "MainForm.vb"));
        var calcMgmt = WriteVb(Path.Combine(_root, "domain", "calc", "CalcMgmt.vb"));

        var engine = new FormatterEngine(new OptionOverrides());

        Assert.Equal(100, engine.OptionsFor(mainForm).PrintWidth);
        Assert.Equal(120, engine.OptionsFor(calcMgmt).PrintWidth);
        Assert.Equal(2, engine.OptionsFor(calcMgmt).IndentSize);
    }

    [Fact]
    public void DoesNotCascadeAnAncestorConfigIntoACloserOne()
    {
        WriteConfig(Path.Combine(_root, ".vbfmtrc"), """{ "printWidth": 100 }""");
        WriteConfig(Path.Combine(_root, "domain", ".vbfmtrc"), """{ "indentSize": 2 }""");
        var calcMgmt = WriteVb(Path.Combine(_root, "domain", "calc", "CalcMgmt.vb"));

        var options = new FormatterEngine(new OptionOverrides()).OptionsFor(calcMgmt);

        Assert.Equal(new FormatterOptions().PrintWidth, options.PrintWidth);
    }

    [Fact]
    public void AnEmptyConfigYieldsTheDefaults()
    {
        WriteConfig(Path.Combine(_root, ".vbfmtrc"), "{}");
        var file = WriteVb(Path.Combine(_root, "Sample.vb"));

        var options = new FormatterEngine(new OptionOverrides()).OptionsFor(file);

        Assert.Equal(new FormatterOptions(), options);
    }

    [Fact]
    public void AnExplicitOverrideBeatsEveryConfigFileAtEveryDepth()
    {
        WriteConfig(Path.Combine(_root, ".vbfmtrc"), """{ "printWidth": 100 }""");
        WriteConfig(Path.Combine(_root, "domain", ".vbfmtrc"), """{ "printWidth": 90 }""");
        var mainForm = WriteVb(Path.Combine(_root, "MainForm.vb"));
        var calcMgmt = WriteVb(Path.Combine(_root, "domain", "calc", "CalcMgmt.vb"));

        var engine = new FormatterEngine(new OptionOverrides { PrintWidth = 60 });

        Assert.Equal(60, engine.OptionsFor(mainForm).PrintWidth);
        Assert.Equal(60, engine.OptionsFor(calcMgmt).PrintWidth);
    }

    [Fact]
    public void APinnedConfigPathIsUsedAtEveryDepthInsteadOfDiscovery()
    {
        WriteConfig(Path.Combine(_root, ".vbfmtrc"), """{ "printWidth": 100 }""");
        WriteConfig(Path.Combine(_root, "domain", ".vbfmtrc"), """{ "printWidth": 90 }""");
        var pinned = Path.Combine(_root, "shared.json");
        WriteConfig(pinned, """{ "printWidth": 77 }""");
        var mainForm = WriteVb(Path.Combine(_root, "MainForm.vb"));
        var calcMgmt = WriteVb(Path.Combine(_root, "domain", "calc", "CalcMgmt.vb"));

        var engine = new FormatterEngine(new OptionOverrides(), pinned);

        Assert.Equal(77, engine.OptionsFor(mainForm).PrintWidth);
        Assert.Equal(77, engine.OptionsFor(calcMgmt).PrintWidth);
    }

    [Fact]
    public void TheWalkStopsAtARepositoryRootMarkedByAGitDirectory()
    {
        WriteConfig(Path.Combine(_root, ".vbfmtrc"), """{ "printWidth": 100 }""");
        Directory.CreateDirectory(Path.Combine(_root, "repo", ".git"));
        var file = WriteVb(Path.Combine(_root, "repo", "MainForm.vb"));

        var options = new FormatterEngine(new OptionOverrides()).OptionsFor(file);

        Assert.Equal(new FormatterOptions().PrintWidth, options.PrintWidth);
    }

    [Fact]
    public void TheWalkStopsAtARepositoryRootMarkedByASolutionFile()
    {
        WriteConfig(Path.Combine(_root, ".vbfmtrc"), """{ "printWidth": 100 }""");
        Directory.CreateDirectory(Path.Combine(_root, "repo"));
        File.WriteAllText(Path.Combine(_root, "repo", "Solution.sln"), "");
        var file = WriteVb(Path.Combine(_root, "repo", "MainForm.vb"));

        var options = new FormatterEngine(new OptionOverrides()).OptionsFor(file);

        Assert.Equal(new FormatterOptions().PrintWidth, options.PrintWidth);
    }

    [Fact]
    public void ResolvesTheSameConfigConcurrentlyFromManyDirectories()
    {
        WriteConfig(Path.Combine(_root, ".vbfmtrc"), """{ "printWidth": 97 }""");
        var files = Enumerable
            .Range(0, 64)
            .Select(i => WriteVb(Path.Combine(_root, $"dir{i}", "Sample.vb")))
            .ToList();

        var engine = new FormatterEngine(new OptionOverrides());

        var options = files.AsParallel().Select(engine.OptionsFor).ToList();

        Assert.All(options, o => Assert.Equal(97, o.PrintWidth));

        var sameDirectoryOptions = files.AsParallel().Select(engine.OptionsFor).ToList();
        for (var i = 0; i < files.Count; i++)
        {
            Assert.Same(options[i], sameDirectoryOptions[i]);
        }
    }

    [Fact]
    public void PrefersVbfmtrcOverItsJsonNamedSibling()
    {
        WriteConfig(Path.Combine(_root, ".vbfmtrc"), """{ "printWidth": 11 }""");
        WriteConfig(Path.Combine(_root, ".vbfmtrc.json"), """{ "printWidth": 22 }""");

        var found = ConfigLocator.Find(_root);

        Assert.Equal(Path.Combine(_root, ".vbfmtrc"), found);
    }

    private static void WriteConfig(string path, string json)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, json);
    }

    private static string WriteVb(string path)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, "Module M\r\nEnd Module\r\n");
        return path;
    }
}
