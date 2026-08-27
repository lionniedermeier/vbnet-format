using VisualBasicFormatter.Cli;

namespace VisualBasicFormatter.Tests;

public sealed class IgnoreFileTests : IDisposable
{
    private readonly string _root = Path.Combine(
        Path.GetTempPath(), "vbnet-format-tests", Guid.NewGuid().ToString("n"));

    public IgnoreFileTests() => Directory.CreateDirectory(_root);

    public void Dispose() => Directory.Delete(_root, recursive: true);

    [Fact]
    public void IgnoresABasenameAtAnyDepth()
    {
        Assert.True(IsIgnored("build.vb", "build.vb"));
        Assert.True(IsIgnored("src/deep/build.vb", "build.vb"));
        Assert.False(IsIgnored("src/other.vb", "build.vb"));
    }

    [Fact]
    public void AnchorsAPatternThatContainsASlash()
    {
        Assert.True(IsIgnored("src/build.vb", "src/build.vb"));
        Assert.False(IsIgnored("lib/src/build.vb", "src/build.vb"));
    }

    [Fact]
    public void AnchorsALeadingSlash()
    {
        Assert.True(IsIgnored("build.vb", "/build.vb"));
        Assert.False(IsIgnored("src/build.vb", "/build.vb"));
    }

    [Fact]
    public void MatchesADirectoryAndEverythingUnderIt()
    {
        Assert.True(IsIgnored("generated/a.vb", "generated/"));
        Assert.True(IsIgnored("src/generated/deep/a.vb", "generated/"));
        Assert.True(IsIgnoredDirectory("generated", "generated/"));
        Assert.False(IsIgnored("generated", "generated/"));
    }

    [Fact]
    public void MatchesAPlainNameAsBothFileAndDirectory()
    {
        Assert.True(IsIgnored("generated", "generated"));
        Assert.True(IsIgnored("generated/a.vb", "generated"));
    }

    [Fact]
    public void StarDoesNotCrossADirectorySeparator()
    {
        Assert.True(IsIgnored("a.vb", "/*.vb"));
        Assert.False(IsIgnored("sub/a.vb", "/*.vb"));
    }

    [Fact]
    public void DoubleStarCrossesDirectories()
    {
        Assert.True(IsIgnored("docs/deep/a.vb", "docs/**"));
        Assert.False(IsIgnored("docs", "docs/**"));

        Assert.True(IsIgnored("x/y/gen/a.vb", "**/gen/*.vb"));
        Assert.False(IsIgnored("x/gen/deep/a.vb", "**/gen/*.vb"));

        Assert.True(IsIgnored("a/b", "/a/**/b"));
        Assert.True(IsIgnored("a/x/y/b", "/a/**/b"));
    }

    [Fact]
    public void QuestionMarkMatchesOneCharacter()
    {
        Assert.True(IsIgnored("ab.vb", "a?.vb"));
        Assert.False(IsIgnored("abc.vb", "a?.vb"));
        Assert.False(IsIgnored("a/.vb", "a?.vb"));
    }

    [Fact]
    public void MatchesACharacterClass()
    {
        Assert.True(IsIgnored("b.vb", "[abc].vb"));
        Assert.False(IsIgnored("d.vb", "[abc].vb"));

        Assert.True(IsIgnored("b1.vb", "[!a]*.vb"));
        Assert.False(IsIgnored("a1.vb", "[!a]*.vb"));
    }

    [Fact]
    public void NegationReIncludesALaterMatch()
    {
        Assert.False(IsIgnored("keep.vb", "*.vb", "!keep.vb"));
        Assert.True(IsIgnored("other.vb", "*.vb", "!keep.vb"));
    }

    [Fact]
    public void LastMatchingRuleWins()
    {
        Assert.False(IsIgnored("keep.vb", "*.vb", "!keep.vb"));
        Assert.True(IsIgnored("keep.vb", "!keep.vb", "*.vb"));
    }

    [Fact]
    public void SkipsBlankLinesAndComments()
    {
        Assert.False(IsIgnored("a.vb", string.Empty, "   ", "# a.vb", "#a.vb"));
        Assert.True(IsIgnored("#literal.vb", "\\#literal.vb"));
    }

    [Fact]
    public void TrimsTrailingWhitespace()
    {
        Assert.True(IsIgnored("a.vb", "a.vb   "));
    }

    [Fact]
    public void EscapesASpaceWithABackslash()
    {
        Assert.True(IsIgnored("a b.vb", "a\\ b.vb"));
    }

    [Fact]
    public void HandlesCrLfLineEndings()
    {
        Assert.False(IsIgnored("keep.vb", "*.vb\r", "!keep.vb\r"));
        Assert.True(IsIgnored("other.vb", "*.vb\r", "!keep.vb\r"));
    }

    [Fact]
    public void ResolvesPatternsRelativeToTheIgnoreFile()
    {
        var nested = Path.Combine(_root, "nested");
        var file = IgnoreFile.Parse(nested, ["/a.vb"]);

        Assert.True(file.Match(Path.Combine(nested, "a.vb"), false));
        Assert.Null(file.Match(Path.Combine(_root, "a.vb"), false));
    }

    [Fact]
    public void LeavesPathsOutsideTheBaseDirectoryAlone()
    {
        var file = IgnoreFile.Parse(Path.Combine(_root, "nested"), ["*.vb"]);

        Assert.Null(file.Match(Path.Combine(_root, "a.vb"), false));
    }

    [Fact]
    public void ReportsNoVerdictWhenNothingMatches()
    {
        Assert.Null(IgnoreFile.Parse(_root, ["*.txt"]).Match(Path.Combine(_root, "a.vb"), false));
    }

    [Fact]
    public void ReadsBothDefaultIgnoreFiles()
    {
        Write(".gitignore", "gen/");
        Write(".vbnet-formatignore", "*.bak.vb");

        var ignores = Program.DiscoverIgnores(_root, [], respectGitignore: true, noIgnore: false);

        Assert.True(ignores.IsIgnored(Path.Combine(_root, "gen", "a.vb")));
        Assert.True(ignores.IsIgnored(Path.Combine(_root, "x.bak.vb")));
        Assert.False(ignores.IsIgnored(Path.Combine(_root, "a.vb")));
    }

    [Fact]
    public void LetsTheIgnoreFileOverrideTheGitignore()
    {
        Write(".gitignore", "gen/");
        Write(".vbnet-formatignore", "!gen/keep.vb");

        var ignores = Program.DiscoverIgnores(_root, [], respectGitignore: true, noIgnore: false);

        Assert.False(ignores.IsIgnored(Path.Combine(_root, "gen", "keep.vb")));
        Assert.True(ignores.IsIgnored(Path.Combine(_root, "gen", "other.vb")));
    }

    [Fact]
    public void SkipsTheGitignoreWhenAsked()
    {
        Write(".gitignore", "gen/");

        var ignores = Program.DiscoverIgnores(_root, [], respectGitignore: false, noIgnore: false);

        Assert.False(ignores.IsIgnored(Path.Combine(_root, "gen", "a.vb")));
    }

    [Fact]
    public void ReadsNoIgnoreFileWhenDisabled()
    {
        Write(".gitignore", "gen/");
        Write(".vbnet-formatignore", "*.vb");

        var ignores = Program.DiscoverIgnores(_root, [], respectGitignore: true, noIgnore: true);

        Assert.False(ignores.IsIgnored(Path.Combine(_root, "gen", "a.vb")));
    }

    [Fact]
    public void UsesTheGivenIgnorePathsInsteadOfTheDefaults()
    {
        Write(".gitignore", "keep.vb");
        Write(".vbnet-formatignore", "also-keep.vb");
        Write("custom.txt", "*.bak.vb");

        var ignores = Program.DiscoverIgnores(
            _root, [Path.Combine(_root, "custom.txt")], respectGitignore: true, noIgnore: false);

        Assert.True(ignores.IsIgnored(Path.Combine(_root, "x.bak.vb")));
        Assert.False(ignores.IsIgnored(Path.Combine(_root, "keep.vb")));
        Assert.False(ignores.IsIgnored(Path.Combine(_root, "also-keep.vb")));
    }

    [Fact]
    public void AppliesEveryGivenIgnorePathInOrder()
    {
        Write("first.txt", "*.vb");
        Write("second.txt", "!keep.vb");

        var ignores = Program.DiscoverIgnores(
            _root,
            [Path.Combine(_root, "first.txt"), Path.Combine(_root, "second.txt")],
            respectGitignore: true,
            noIgnore: false);

        Assert.False(ignores.IsIgnored(Path.Combine(_root, "keep.vb")));
        Assert.True(ignores.IsIgnored(Path.Combine(_root, "other.vb")));
    }

    [Fact]
    public void ReadsNothingWhenNoDefaultIgnoreFileExists()
    {
        var ignores = Program.DiscoverIgnores(_root, [], respectGitignore: true, noIgnore: false);

        Assert.False(ignores.IsIgnored(Path.Combine(_root, "a.vb")));
    }

    [Fact]
    public void FailsOnAMissingIgnorePath()
    {
        Assert.Throws<InvalidDataException>(() => Program.DiscoverIgnores(
            _root, [Path.Combine(_root, "absent.txt")], respectGitignore: true, noIgnore: false));
    }

    private void Write(string name, string contents) =>
        File.WriteAllText(Path.Combine(_root, name), contents);

    private bool IsIgnored(string relativePath, params string[] lines) =>
        Match(relativePath, false, lines) is true;

    private bool IsIgnoredDirectory(string relativePath, params string[] lines) =>
        Match(relativePath, true, lines) is true;

    private bool? Match(string relativePath, bool isDirectory, string[] lines) =>
        IgnoreFile.Parse(_root, lines).Match(
            Path.Combine(_root, relativePath.Replace('/', Path.DirectorySeparatorChar)), isDirectory);
}
