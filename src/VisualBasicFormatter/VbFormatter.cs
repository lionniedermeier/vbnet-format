using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Imports;
using VisualBasicFormatter.Language;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter;

/// <summary>Formats VB.NET source: orders imports, normalizes whitespace, wraps long lines.</summary>
public static class VbFormatter
{
    // Roslyn only applies an .editorconfig when the project and the document carry paths under the
    // same directory. These files exist in memory only.
    private static readonly string VirtualDirectory =
        Path.Combine(Path.GetTempPath(), "vbnet-format-inmemory");

    /// <summary>Formats <paramref name="source"/>.</summary>
    /// <param name="source">VB.NET source text.</param>
    /// <param name="options">Configuration; <c>null</c> uses the defaults.</param>
    public static FormatResult Format(string source, FormatterOptions? options = null)
    {
        options ??= new FormatterOptions();
        var newLine = NewLineFor(options.EndOfLine, source);
        var parseOptions = new VisualBasicParseOptions(options.LanguageVersion);

        var tree = VisualBasicSyntaxTree.ParseText(source, parseOptions);
        var errors = tree.GetDiagnostics()
            .Where(d => d.Severity == DiagnosticSeverity.Error)
            .ToImmutableArray();

        // Never rewrite source that does not parse.
        if (errors.Length > 0)
        {
            return new FormatResult(source, Changed: false, errors);
        }

        var original = (CompilationUnitSyntax)tree.GetRoot();
        var root = original;

        if (options.OrganizeImports)
        {
            root = ImportsOrganizer.Organize(root, newLine);
        }

        root = NormalizeWhitespace(root, options, newLine);

        var printed = DocEngine.Format(root, options, newLine);

        if (VerifyEquivalence(original, printed, parseOptions) is { } failure)
        {
            return new FormatResult(source, Changed: false, [failure]);
        }

        return new FormatResult(printed, printed != source, []);
    }

    /// <summary>Normalizes indentation and spacing. Inserts no line breaks of its own.</summary>
    internal static CompilationUnitSyntax NormalizeWhitespace(
        CompilationUnitSyntax root,
        FormatterOptions options,
        string newLine)
    {
        var editorConfig = string.Join(
            newLine,
            "root = true",
            string.Empty,
            "[*.vb]",
            $"indent_style = {(options.UseTabs ? "tab" : "space")}",
            $"indent_size = {options.IndentSize}",
            $"tab_width = {options.IndentSize}",
            $"end_of_line = {(newLine == "\r\n" ? "crlf" : "lf")}");

        using var workspace = new AdhocWorkspace();

        var project = workspace
            .AddProject(ProjectInfo.Create(
                ProjectId.CreateNewId(),
                VersionStamp.Default,
                name: "VbNetFormat",
                assemblyName: "VbNetFormat",
                language: LanguageNames.VisualBasic,
                filePath: Path.Combine(VirtualDirectory, "VbNetFormat.vbproj")))
            .AddAnalyzerConfigDocument(
                ".editorconfig",
                SourceText.From(editorConfig),
                filePath: Path.Combine(VirtualDirectory, ".editorconfig"))
            .Project;

        var document = project.AddDocument(
            "Source.vb",
            SourceText.From(root.ToFullString()),
            filePath: Path.Combine(VirtualDirectory, "Source.vb"));

        var formatted = Formatter.FormatAsync(document, options: null, CancellationToken.None)
            .GetAwaiter().GetResult();

        return (CompilationUnitSyntax)formatted.GetSyntaxRootAsync().GetAwaiter().GetResult()!;
    }

    /// <summary>
    /// Checks that the output describes the same code as the input. A plain
    /// <see cref="SyntaxNode.IsEquivalentTo(SyntaxNode, bool)"/> over the whole tree fails as soon as
    /// imports have been reordered, because that changes the tree structure. The imports are
    /// therefore compared as a set and the rest structurally.
    /// </summary>
    private static Diagnostic? VerifyEquivalence(
        CompilationUnitSyntax original,
        string formatted,
        VisualBasicParseOptions parseOptions)
    {
        var tree = VisualBasicSyntaxTree.ParseText(formatted, parseOptions);

        if (tree.GetDiagnostics().Any(d => d.Severity == DiagnosticSeverity.Error))
        {
            return Failure("Formatting produced source that fails to parse.");
        }

        var result = (CompilationUnitSyntax)tree.GetRoot();

        var before = ImportClauses(original);
        var after = ImportClauses(result);

        // Removing duplicates is intended; losing an import is not.
        if (!before.SetEquals(after))
        {
            return Failure("Formatting changed or lost imports.");
        }

        if (!Body(original).IsEquivalentTo(Body(result), topLevel: false)
            && !StructurallyIdentical(Body(original), Body(result)))
        {
            return Failure("Formatting changed the code.");
        }

        return null;
    }

    internal static bool StructurallyIdentical(SyntaxNode before, SyntaxNode after) =>
        before.DescendantNodes().Select(n => n.RawKind)
            .SequenceEqual(after.DescendantNodes().Select(n => n.RawKind))
        && before.DescendantTokens().Select(t => (t.RawKind, t.Text))
            .SequenceEqual(after.DescendantTokens().Select(t => (t.RawKind, t.Text)));

    private static HashSet<string> ImportClauses(CompilationUnitSyntax root) =>
        new(root.Imports.SelectMany(i => i.ImportsClauses).Select(c => c.ToString().Trim()),
            StringComparer.OrdinalIgnoreCase);

    /// <summary>The file without its imports, so that their order does not disturb the comparison.</summary>
    private static CompilationUnitSyntax Body(CompilationUnitSyntax root) =>
        root.WithImports(default);

    private static Diagnostic Failure(string message) => Diagnostic.Create(
        new DiagnosticDescriptor(
            "VBNETFORMAT001",
            "Formatting aborted",
            "{0}",
            "VisualBasicFormatter",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true),
        Location.None,
        message);

    /// <summary>The line ending <paramref name="endOfLine"/> asks for, resolving <c>Auto</c>.</summary>
    private static string NewLineFor(EndOfLine endOfLine, string source) => endOfLine switch
    {
        EndOfLine.Lf => "\n",
        EndOfLine.CrLf => "\r\n",
        _ => DetectNewLine(source),
    };

    internal static string DetectNewLine(string source)
    {
        var lf = source.IndexOf('\n');
        if (lf < 0)
        {
            return Environment.NewLine;
        }

        return lf > 0 && source[lf - 1] == '\r' ? "\r\n" : "\n";
    }
}
