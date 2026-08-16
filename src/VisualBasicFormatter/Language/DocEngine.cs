using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>Builds the document for a whole file and prints it.</summary>
internal static class DocEngine
{
    /// <summary>Formats <paramref name="root"/>.</summary>
    /// <param name="root">A tree whose intra-token spacing has already been normalized.</param>
    /// <param name="options">The user's configuration.</param>
    /// <param name="newLine">Line ending of the output.</param>
    public static string Format(
        CompilationUnitSyntax root,
        FormatterOptions options,
        string newLine)
    {
        var context = new FormatContext(options, root.SyntaxTree.GetText(), newLine);
        var visitor = new VbDocVisitor(context);

        return DocPrinter.Print(visitor.FormatRoot(root), context.PrintOptions);
    }
}
