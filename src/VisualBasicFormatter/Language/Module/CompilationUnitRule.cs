using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language.Statements;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Module;

/// <summary>The file itself: options, imports, assembly attributes, then the type declarations.</summary>
internal static class CompilationUnitRule
{
    /// <summary>Prints <paramref name="node"/>.</summary>
    public static Doc Format(CompilationUnitSyntax node, VbDocVisitor visitor, FormatContext context)
    {
        var members = node.Options.Cast<SyntaxNode>()
            .Concat(node.Imports)
            .Concat(node.Attributes)
            .Concat(node.Members)
            .ToList();

        var parts = ImmutableArray.CreateBuilder<Doc>();

        for (var index = 0; index < members.Count; index++)
        {
            // Nothing precedes the first one, but its own leading comments -- the file header --
            // are printed by the member itself.
            if (index > 0)
            {
                parts.Add(context.Separator(members[index]));
            }

            parts.Add(visitor.Format(members[index]));
        }

        // Comments after the last declaration hang on the end-of-file token and are lost easily.
        var epilogue = TriviaPrinter.Leading(node.EndOfFileToken, context);

        parts.Add(Doc.IsNothing(epilogue)
            ? Doc.HardLine
            : Doc.Concat(context.Separator(node.EndOfFileToken), epilogue));

        return Doc.Concat(parts.DrainToImmutable());
    }
}
