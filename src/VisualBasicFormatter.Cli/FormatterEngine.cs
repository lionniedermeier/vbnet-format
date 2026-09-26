using System.Collections.Concurrent;
using VisualBasicFormatter;

namespace VisualBasicFormatter.Cli;

internal sealed class FormatterEngine
{
    private readonly OptionOverrides _overrides;
    private readonly string? _pinnedConfigPath;
    private readonly ConcurrentDictionary<string, Lazy<FormatterOptions>> _optionsByDirectory = new(
        StringComparer.OrdinalIgnoreCase
    );
    private readonly ConcurrentDictionary<string, Lazy<ConfigFile>> _configByPath = new(
        StringComparer.OrdinalIgnoreCase
    );

    public FormatterEngine(OptionOverrides overrides, string? pinnedConfigPath = null)
    {
        _overrides = overrides;
        _pinnedConfigPath = pinnedConfigPath;

        if (pinnedConfigPath is not null && !File.Exists(pinnedConfigPath))
        {
            throw new InvalidDataException($"'{pinnedConfigPath}' is not a config file.");
        }
    }

    public FormatterOptions OptionsFor(string file)
    {
        var full = Path.GetFullPath(file);
        var directory = Path.GetDirectoryName(full) ?? full;

        return OptionsForDirectory(directory);
    }

    public FormatResult Format(string file, string source) =>
        VbFormatter.Format(source, OptionsFor(file));

    public FormatResult FormatStandardInput(string source) =>
        VbFormatter.Format(source, OptionsForDirectory(Directory.GetCurrentDirectory()));

    private FormatterOptions OptionsForDirectory(string directory) =>
        _optionsByDirectory
            .GetOrAdd(directory, d => new Lazy<FormatterOptions>(() => ResolveOptions(d)))
            .Value;

    private FormatterOptions ResolveOptions(string directory)
    {
        var configPath = _pinnedConfigPath ?? ConfigLocator.Find(directory);
        var config = configPath is null ? null : LoadConfig(configPath);

        return _overrides.ApplyTo(
            config?.ApplyTo(new FormatterOptions()) ?? new FormatterOptions()
        );
    }

    private ConfigFile LoadConfig(string path) =>
        _configByPath.GetOrAdd(path, p => new Lazy<ConfigFile>(() => ConfigFile.Load(p))).Value;
}
