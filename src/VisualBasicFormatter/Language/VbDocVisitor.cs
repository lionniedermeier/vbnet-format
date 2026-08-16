using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language.Xml;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>
/// One formatting rule per syntax node. Roslyn's own visitor is the dispatcher: an
/// <c>override</c> is checked against the real node types at compile time, and
/// <see cref="DefaultVisit"/> is the fallback for every kind that has no rule yet.
/// </summary>
/// <remarks>
/// The parts of this class stay flat in <c>Language/</c> because <c>dotnet_style_namespace_match_folder</c>
/// forbids a partial type spanning folders. A rule that outgrows a few lines moves into a
/// <c>…Rule</c> class in the matching sub-folder, and the override here delegates to it.
/// </remarks>
internal sealed partial class VbDocVisitor : VisualBasicSyntaxVisitor<Doc>
{
    private readonly FormatContext _context;

    public VbDocVisitor(FormatContext context) => _context = context;

    /// <summary>Every node kind without a rule of its own prints its children, and offers no break.</summary>
    public override Doc DefaultVisit(SyntaxNode node) => StructuralFallback.Format(node, this, _context);

    /// <summary>Formats <paramref name="node"/>, treating an absent child as nothing.</summary>
    public Doc Format(SyntaxNode? node)
    {
        if (node is null)
        {
            return Doc.Nothing;
        }

        // A comment inside an expression has nowhere else to go, so that expression is reproduced
        // rather than rebuilt. Statements are exempt: their comments sit above whole lines, which
        // the block rules place correctly.
        if (node is ExpressionSyntax && StructuralFallback.MustPrintVerbatim(node))
        {
            return VerbatimFormatter.Format(node, _context);
        }

        return Visit(node) ?? Doc.Nothing;
    }

    /// <summary>Formats a whole file.</summary>
    public Doc FormatRoot(CompilationUnitSyntax root) => Format(root);

    // Constructs whose line breaks carry meaning are routed to the verbatim printer deliberately,
    // so that a future rule author cannot introduce a break into them by accident. The XML literals
    // that are laid out rather than copied live in VbDocVisitor.Xml.cs.

    /// <summary>
    /// A document has a prologue and may carry its own trailing markup, neither of which the element
    /// rules know about. Rare enough that copying it is the better trade.
    /// </summary>
    public override Doc VisitXmlDocument(XmlDocumentSyntax node) => Verbatim(node);

    /// <inheritdoc/>
    public override Doc VisitXmlCDataSection(XmlCDataSectionSyntax node) => Verbatim(node);

    /// <inheritdoc/>
    public override Doc VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node) =>
        Verbatim(node);

    /// <summary>
    /// A break anywhere inside re-parses as a multi-line <c>If</c> block, which is a different tree.
    /// </summary>
    public override Doc VisitSingleLineIfStatement(SingleLineIfStatementSyntax node) => Verbatim(node);

    private Doc Verbatim(SyntaxNode node) => VerbatimFormatter.Format(node, _context);
}
