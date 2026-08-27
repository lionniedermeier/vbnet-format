using VisualBasicFormatter.Cli;

namespace VisualBasicFormatter.Tests;

public sealed class FileDiscoveryTests : IDisposable
{
    private readonly string _root = Path.Combine(
        Path.GetTempPath(), "vbnet-format-tests", Guid.NewGuid().ToString("n"));

    public FileDiscoveryTests() => Directory.CreateDirectory(_root);

    public void Dispose() => Directory.Delete(_root, recursive: true);

    [Theory]
    [InlineData("bin")]
    [InlineData("obj")]
    [InlineData("node_modules")]
    [InlineData(".git")]
    [InlineData(".svn")]
    [InlineData(".hg")]
    public void SkipsAnAlwaysExcludedDirectory(string directory)
    {
        Write("kept.vb");
        Write(Path.Combine(directory, "skipped.vb"));

        Assert.Equal([Path.Combine(_root, "kept.vb")], Resolve());
    }

    [Theory]
    [InlineData("bin")]
    [InlineData("obj")]
    [InlineData("node_modules")]
    [InlineData(".git")]
    [InlineData(".svn")]
    [InlineData(".hg")]
    public void SkipsAnAlwaysExcludedDirectoryAtAnyDepth(string directory)
    {
        Write("kept.vb");
        Write(Path.Combine("src", "deep", directory, "nested", "skipped.vb"));

        Assert.Equal([Path.Combine(_root, "kept.vb")], Resolve());
    }

    [Fact]
    public void FindsSourceFilesAtEveryDepth()
    {
        Write("a.vb");
        Write(Path.Combine("src", "b.vb"));
        Write(Path.Combine("src", "deep", "c.vb"));
        Write("notes.txt");

        Assert.Equal(
            [
                Path.Combine(_root, "a.vb"),
                Path.Combine(_root, "src", "b.vb"),
                Path.Combine(_root, "src", "deep", "c.vb"),
            ],
            Resolve());
    }

    private string[] Resolve() =>
        [.. Program.Resolve([_root]).Order(StringComparer.OrdinalIgnoreCase)];

    private void Write(string relativePath)
    {
        var path = Path.Combine(_root, relativePath);
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, "Module M\r\nEnd Module\r\n");
    }
}
