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
        var (root, options, newLine) = Parse(TestCases.ReadInput(name));
        var once = DocEngine.Format(root, options, newLine);

        var (again, _, _) = Parse(once);

        Assert.Equal(once, DocEngine.Format(again, options, newLine));
    }

    /// <summary>Parses <paramref name="source"/>, i.e. everything the engine sits behind.</summary>
    private static (CompilationUnitSyntax Root, FormatterOptions Options, string NewLine) Parse(
        string source
    )
    {
        var options = new FormatterOptions();
        var newLine = VbFormatter.DetectNewLine(source);

        var tree = VisualBasicSyntaxTree.ParseText(
            source,
            new VisualBasicParseOptions(options.LanguageVersion)
        );

        return ((CompilationUnitSyntax)tree.GetRoot(), options, newLine);
    }
}
