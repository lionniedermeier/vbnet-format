using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language.Declarations;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language.Module;

/// <summary>The file itself: options, imports, assembly attributes, then the type declarations.</summary>
internal static class CompilationUnitRule
{
    /// <summary>Prints <paramref name="node"/>.</summary>
    public static Doc Format(
        CompilationUnitSyntax node,
        VbDocVisitor visitor,
        FormatContext context
    )
    {
        var members = node
            .Options.Cast<SyntaxNode>()
            .Concat(node.Imports)
            .Concat(node.Attributes)
            .Concat(node.Members)
            .ToList();

        var optionsEnd = node.Options.Count;
        var importsEnd = optionsEnd + node.Imports.Count;
        var attributesEnd = importsEnd + node.Attributes.Count;
        var firstDeclaration = attributesEnd;
        var parts = ImmutableArray.CreateBuilder<Doc>();

        for (var index = 0; index < members.Count; index++)
        {
            // Nothing precedes the first one, but its own leading comments -- the file header --
            // are printed by the member itself.
            if (index == 0)
            {
                parts.Add(visitor.Format(members[index]));
                continue;
            }

            if (index > firstDeclaration)
            {
                parts.Add(MemberSpacingRule.Between(members[index - 1], members[index], context));
                parts.Add(visitor.Format(members[index]));
                continue;
            }

            var previousSection = SectionOf(index - 1, optionsEnd, importsEnd, attributesEnd);
            var currentSection = SectionOf(index, optionsEnd, importsEnd, attributesEnd);

            if (previousSection == currentSection)
            {
                parts.Add(context.Separator(members[index]));
                parts.Add(visitor.Format(members[index]));
                continue;
            }

            parts.Add(SectionBreak(previousSection, members[index], visitor, context));
        }

        // Comments after the last declaration hang on the end-of-file token and are lost easily.
        var epilogue = TriviaPrinter.Leading(node.EndOfFileToken, context);

        parts.Add(
            Doc.IsNothing(epilogue)
                ? Doc.HardLine
                : Doc.Concat(context.Separator(node.EndOfFileToken), epilogue)
        );

        return Doc.Concat(parts.DrainToImmutable());
    }

    private static FileSection SectionOf(
        int index,
        int optionsEnd,
        int importsEnd,
        int attributesEnd
    ) =>
        index < optionsEnd ? FileSection.Options
        : index < importsEnd ? FileSection.Imports
        : index < attributesEnd ? FileSection.Attributes
        : FileSection.Declarations;

    private static Doc SectionBreak(
        FileSection previous,
        SyntaxNode node,
        VbDocVisitor visitor,
        FormatContext context
    )
    {
        var first = node.GetFirstToken();
        var tail = SectionTail.Length(first.LeadingTrivia, previous);

        if (tail == 0 || context.IsIgnored(node))
        {
            return Doc.Concat(Doc.EmptyLine, visitor.Format(node));
        }

        var separator = context.Separator(first);
        var leading = TriviaPrinter.Leading(
            first.LeadingTrivia,
            first.LeadingTrivia.Count,
            context,
            tail
        );

        var restore = context.Hoist(first);
        var body = visitor.Format(node);
        context.Restore(restore);

        return Doc.Concat(separator, leading, body);
    }
}
