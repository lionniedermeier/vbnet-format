using System.Text;
using System.Text.RegularExpressions;

namespace VisualBasicFormatter.Cli;

internal sealed class IgnoreRule
{
    private const RegexOptions Options =
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;

    private readonly Regex _file;
    private readonly Regex _directory;

    private IgnoreRule(Regex file, Regex directory, bool negated)
    {
        _file = file;
        _directory = directory;
        Negated = negated;
    }

    public bool Negated { get; }

    public bool Matches(string relativePath, bool isDirectory) =>
        (isDirectory ? _directory : _file).IsMatch(relativePath);

    public static IgnoreRule? Parse(string line)
    {
        var text = TrimTrailing(line.TrimEnd('\r'));
        if (text.Length == 0 || text[0] == '#')
        {
            return null;
        }

        var negated = text[0] == '!';
        if (negated)
        {
            text = text[1..];
        }

        var directoryOnly = text.Length > 1 && text[^1] == '/';
        if (directoryOnly)
        {
            text = text[..^1];
        }

        var anchored = text.Contains('/');
        if (text.StartsWith('/'))
        {
            text = text[1..];
        }

        if (text.Length == 0)
        {
            return null;
        }

        var core = (anchored ? "^" : "^(?:.*/)?") + Translate(text);
        var directory = new Regex(core + "(?:/.*)?$", Options);

        return new IgnoreRule(directoryOnly ? new Regex(core + "/.*$", Options) : directory, directory, negated);
    }

    private static string TrimTrailing(string text)
    {
        var end = text.Length;

        while (end > 0 && (text[end - 1] == ' ' || text[end - 1] == '\t'))
        {
            var backslashes = 0;
            for (var i = end - 2; i >= 0 && text[i] == '\\'; i--)
            {
                backslashes++;
            }

            if (backslashes % 2 == 1)
            {
                break;
            }

            end--;
        }

        return text[..end];
    }

    private static string Translate(string pattern)
    {
        var builder = new StringBuilder();

        for (var i = 0; i < pattern.Length; i++)
        {
            switch (pattern[i])
            {
                case '\\' when i + 1 < pattern.Length:
                    builder.Append(Regex.Escape(pattern[++i].ToString()));
                    break;

                case '*' when i + 1 < pattern.Length && pattern[i + 1] == '*':
                    i++;
                    if (i + 1 < pattern.Length && pattern[i + 1] == '/')
                    {
                        i++;
                        builder.Append("(?:.*/)?");
                    }
                    else
                    {
                        builder.Append(".*");
                    }

                    break;

                case '*':
                    builder.Append("[^/]*");
                    break;

                case '?':
                    builder.Append("[^/]");
                    break;

                case '[':
                    i = AppendClass(builder, pattern, i);
                    break;

                default:
                    builder.Append(Regex.Escape(pattern[i].ToString()));
                    break;
            }
        }

        return builder.ToString();
    }

    private static int AppendClass(StringBuilder builder, string pattern, int start)
    {
        var end = start + 1;
        if (end < pattern.Length && (pattern[end] == '!' || pattern[end] == '^'))
        {
            end++;
        }

        if (end < pattern.Length && pattern[end] == ']')
        {
            end++;
        }

        while (end < pattern.Length && pattern[end] != ']')
        {
            end++;
        }

        if (end >= pattern.Length)
        {
            builder.Append("\\[");
            return start;
        }

        var body = pattern[(start + 1)..end];
        builder.Append('[').Append(body[0] == '!' ? "^" + body[1..] : body).Append(']');

        return end;
    }
}

internal sealed class IgnoreFile
{
    private readonly string _baseDirectory;
    private readonly List<IgnoreRule> _rules;

    private IgnoreFile(string baseDirectory, List<IgnoreRule> rules)
    {
        _baseDirectory = baseDirectory;
        _rules = rules;
    }

    public static IgnoreFile Load(string path)
    {
        var full = Path.GetFullPath(path);

        return File.Exists(full)
            ? Parse(Path.GetDirectoryName(full)!, File.ReadLines(full))
            : throw new InvalidDataException($"'{path}' is not an ignore file.");
    }

    public static IgnoreFile Parse(string baseDirectory, IEnumerable<string> lines)
    {
        var rules = new List<IgnoreRule>();

        foreach (var line in lines)
        {
            if (IgnoreRule.Parse(line) is { } rule)
            {
                rules.Add(rule);
            }
        }

        return new IgnoreFile(Path.GetFullPath(baseDirectory), rules);
    }

    public bool? Match(string fullPath, bool isDirectory)
    {
        var relative = Path.GetRelativePath(_baseDirectory, Path.GetFullPath(fullPath)).Replace('\\', '/');
        if (relative == ".." || relative.StartsWith("../", StringComparison.Ordinal) || Path.IsPathRooted(relative))
        {
            return null;
        }

        bool? verdict = null;

        foreach (var rule in _rules)
        {
            if (rule.Matches(relative, isDirectory))
            {
                verdict = !rule.Negated;
            }
        }

        return verdict;
    }
}

internal sealed class IgnoreSet(IReadOnlyList<IgnoreFile> files)
{
    public static IgnoreSet Empty { get; } = new([]);

    public bool IsIgnored(string fullPath, bool isDirectory = false)
    {
        var verdict = false;

        foreach (var file in files)
        {
            if (file.Match(fullPath, isDirectory) is { } answer)
            {
                verdict = answer;
            }
        }

        return verdict;
    }
}
