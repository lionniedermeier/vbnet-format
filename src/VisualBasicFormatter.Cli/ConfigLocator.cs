namespace VisualBasicFormatter.Cli;

internal static class ConfigLocator
{
    public static readonly string[] FileNames =
    [
        ".vbfmtrc",
        ".vbfmtrc.json",
        "vbnet-format.json",
        "vbnetformatrc",
        "vbnetformatrc.json",
    ];

    public static string? Find(string startDirectory)
    {
        for (var dir = new DirectoryInfo(startDirectory); dir is not null; dir = dir.Parent)
        {
            foreach (var name in FileNames)
            {
                var candidate = Path.Combine(dir.FullName, name);
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }

            if (IsRepositoryRoot(dir))
            {
                return null;
            }
        }

        return null;
    }

    public static bool IsRepositoryRoot(DirectoryInfo directory) =>
        Directory.Exists(Path.Combine(directory.FullName, ".git"))
        || File.Exists(Path.Combine(directory.FullName, ".git"))
        || directory.EnumerateFiles("*.sln").Any()
        || directory.EnumerateFiles("*.slnx").Any();
}
