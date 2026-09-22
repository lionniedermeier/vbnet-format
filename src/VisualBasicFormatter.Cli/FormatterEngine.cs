using VisualBasicFormatter;

namespace VisualBasicFormatter.Cli;

internal sealed class FormatterEngine
{
    private readonly OptionOverrides _overrides;
    private readonly string? _pinnedConfigPath;
    private readonly Dictionary<string, FormatterOptions> _optionsByDirectory = new(
        StringComparer.OrdinalIgnoreCase
    );
    private readonly Dictionary<string, ConfigFile> _configByPath = new(
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

    private FormatterOptions OptionsForDirectory(string directory)
    {
        if (_optionsByDirectory.TryGetValue(directory, out var cached))
        {
            return cached;
        }

        var configPath = _pinnedConfigPath ?? ConfigLocator.Find(directory);
        var config = configPath is null ? null : LoadConfig(configPath);

        var options = _overrides.ApplyTo(
            config?.ApplyTo(new FormatterOptions()) ?? new FormatterOptions()
        );

        _optionsByDirectory[directory] = options;
        return options;
    }

    private ConfigFile LoadConfig(string path)
    {
        if (_configByPath.TryGetValue(path, out var cached))
        {
            return cached;
        }

        var config = ConfigFile.Load(path);
        _configByPath[path] = config;
        return config;
    }
}
