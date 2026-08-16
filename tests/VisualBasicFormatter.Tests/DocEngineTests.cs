using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Tests;

/// <summary>The rule-based engine, driven directly rather than through <see cref="VbFormatter"/>.</summary>
public sealed class DocEngineTests
{
    /// <summary>
    /// Printing a document the engine itself produced has to yield that same document. Idempotency
    /// is structural here -- the printer reads no layout out of the input -- and this is the check
    /// that keeps it so.
    /// </summary>
    [Theory]
    [MemberData(nameof(TestCases.Names), MemberType = typeof(TestCases))]
    public void PrintsItsOwnOutputUnchangedAgain(string name)
    {
        var (normalized, options, newLine) = Normalize(TestCases.ReadInput(name));
        var once = DocEngine.Format(normalized, options, newLine);

        var (again, _, _) = Normalize(once);

        Assert.Equal(once, DocEngine.Format(again, options, newLine));
    }

    /// <summary>Parses and runs the spacing pre-pass, i.e. everything the engine sits behind.</summary>
    private static (CompilationUnitSyntax Root, FormatterOptions Options, string NewLine) Normalize(string source)
    {
        var options = new FormatterOptions();
        var newLine = VbFormatter.DetectNewLine(source);

        var tree = VisualBasicSyntaxTree.ParseText(source, new VisualBasicParseOptions(options.LanguageVersion));
        var root = (CompilationUnitSyntax)tree.GetRoot();

        return (VbFormatter.NormalizeWhitespace(root, options, newLine), options, newLine);
    }
}
