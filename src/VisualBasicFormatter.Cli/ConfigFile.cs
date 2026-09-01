using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis.VisualBasic;
using VisualBasicFormatter;

namespace VisualBasicFormatter.Cli;

/// <summary>The contents of a <c>.vbnet-format.json</c>. Unset values keep their default.</summary>
internal sealed record ConfigFile
{
    public int? MaxLineLength { get; init; }

    public int? IndentSize { get; init; }

    public bool? UseTabs { get; init; }

    public EndOfLine? EndOfLine { get; init; }

    /// <summary>
    /// A VB language version as <c>LanguageVersionFacts</c> spells it -- <c>16.9</c>, <c>latest</c>,
    /// <c>default</c>. Kept as text rather than as the enum so that an unknown value can be reported
    /// by name instead of failing as a JSON conversion.
    /// </summary>
    public string? LanguageVersion { get; init; }

    public bool? OrganizeImports { get; init; }

    /// <summary>Lays the values of this file over the default options.</summary>
    public FormatterOptions ApplyTo(FormatterOptions options) => options with
    {
        MaxLineLength = MaxLineLength ?? options.MaxLineLength,
        IndentSize = IndentSize ?? options.IndentSize,
        UseTabs = UseTabs ?? options.UseTabs,
        EndOfLine = EndOfLine ?? options.EndOfLine,
        LanguageVersion = LanguageVersion is null ? options.LanguageVersion : ParseLanguageVersion(LanguageVersion),
        OrganizeImports = OrganizeImports ?? options.OrganizeImports,
    };

    /// <summary>Parses a language version, or reports the value that was not one.</summary>
    /// <remarks>
    /// <c>LanguageVersionFacts</c> is authored in VB, so its <c>TryParse</c> takes a <c>ByRef</c>
    /// parameter that C# sees as <c>ref</c> rather than <c>out</c> -- hence the local.
    /// </remarks>
    public static LanguageVersion ParseLanguageVersion(string value)
    {
        var version = Microsoft.CodeAnalysis.VisualBasic.LanguageVersion.Default;

        return LanguageVersionFacts.TryParse(value, ref version)
            ? version
            : throw new InvalidDataException($"'{value}' is not a known VB language version.");
    }

    public static ConfigFile From(FormatterOptions options) => new()
    {
        MaxLineLength = options.MaxLineLength,
        IndentSize = options.IndentSize,
        UseTabs = options.UseTabs,
        EndOfLine = options.EndOfLine,
        LanguageVersion = LanguageVersionFacts.ToDisplayString(options.LanguageVersion),
        OrganizeImports = options.OrganizeImports,
    };

    public void Save(string path) =>
        File.WriteAllText(
            path,
            JsonSerializer.Serialize(this, ConfigJsonContext.Default.ConfigFile) + Environment.NewLine);

    public static ConfigFile Load(string path)
    {
        try
        {
            return JsonSerializer.Deserialize(File.ReadAllText(path), ConfigJsonContext.Default.ConfigFile)
                ?? throw new InvalidDataException($"'{path}' contains no configuration.");
        }
        catch (JsonException ex)
        {
            throw new InvalidDataException($"'{path}' is not valid JSON: {ex.Message}", ex);
        }
    }
}

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    ReadCommentHandling = JsonCommentHandling.Skip,
    AllowTrailingCommas = true,
    WriteIndented = true,
    Converters = [typeof(JsonStringEnumConverter<EndOfLine>)])]
[JsonSerializable(typeof(ConfigFile))]
internal sealed partial class ConfigJsonContext : JsonSerializerContext;
