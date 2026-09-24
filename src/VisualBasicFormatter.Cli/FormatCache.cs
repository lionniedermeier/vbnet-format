using System.IO.Hashing;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using VisualBasicFormatter;

namespace VisualBasicFormatter.Cli;

internal sealed class FormatCache
{
    private static readonly string ToolVersion =
        typeof(VbFormatter)
            .Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion
        ?? string.Empty;

    private readonly Dictionary<string, string> _entries;
    private readonly string _path;
    private bool _dirty;

    private FormatCache(string path, Dictionary<string, string> entries)
    {
        _path = path;
        _entries = entries;
    }

    public static string DefaultPath =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "vbfmt",
            "cache.json"
        );

    public static FormatCache Load(string path)
    {
        try
        {
            var entries = File.Exists(path)
                ? JsonSerializer.Deserialize(
                    File.ReadAllText(path),
                    FormatCacheJsonContext.Default.DictionaryStringString
                )
                : null;

            return new FormatCache(
                path,
                new Dictionary<string, string>(entries ?? [], StringComparer.OrdinalIgnoreCase)
            );
        }
        catch (Exception ex)
            when (ex is JsonException or IOException or UnauthorizedAccessException)
        {
            return new FormatCache(
                path,
                new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            );
        }
    }

    public bool IsUpToDate(string file, string checksum) =>
        _entries.TryGetValue(Path.GetFullPath(file), out var existing) && existing == checksum;

    public void Record(string file, string checksum)
    {
        _entries[Path.GetFullPath(file)] = checksum;
        _dirty = true;
    }

    public void Forget(string file)
    {
        if (_entries.Remove(Path.GetFullPath(file)))
        {
            _dirty = true;
        }
    }

    public void Save()
    {
        if (!_dirty)
        {
            return;
        }

        var directory = Path.GetDirectoryName(_path);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var tempPath = _path + ".tmp";
        File.WriteAllText(
            tempPath,
            JsonSerializer.Serialize(
                _entries,
                FormatCacheJsonContext.Default.DictionaryStringString
            )
        );
        File.Move(tempPath, _path, overwrite: true);
    }

    public static string Checksum(string source, FormatterOptions options)
    {
        var bytes = Encoding.UTF8.GetBytes(ToolVersion + "\0" + options + "\0" + source);
        return XxHash3.HashToUInt64(bytes).ToString("X16");
    }
}

[JsonSourceGenerationOptions]
[JsonSerializable(typeof(Dictionary<string, string>))]
internal sealed partial class FormatCacheJsonContext : JsonSerializerContext;
