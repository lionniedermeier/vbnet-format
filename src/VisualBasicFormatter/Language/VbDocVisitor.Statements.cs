using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using VisualBasicFormatter.Language.Declarations;
using VisualBasicFormatter.Language.Module;
using VisualBasicFormatter.Language.Statements;
using VisualBasicFormatter.Printing;

namespace VisualBasicFormatter.Language;

/// <summary>
/// The block skeleton: which statements exist, in what order, and how deep. Every override is a
/// reading of the node's own properties -- VB's block nodes name their three parts differently and
/// share no base that exposes them.
/// </summary>
internal sealed partial class VbDocVisitor
{
    /// <inheritdoc/>
    public override Doc VisitCompilationUnit(CompilationUnitSyntax node) =>
        CompilationUnitRule.Format(node, this, _context);

    /// <inheritdoc/>
    public override Doc VisitNamespaceBlock(NamespaceBlockSyntax node) => BlockRule.Format(
        Format(node.NamespaceStatement), node.Members, node.EndNamespaceStatement, this, _context);

    /// <inheritdoc/>
    public override Doc VisitModuleBlock(ModuleBlockSyntax node) => TypeBlockRule.Format(node, this, _context);

    /// <inheritdoc/>
    public override Doc VisitClassBlock(ClassBlockSyntax node) => TypeBlockRule.Format(node, this, _context);

    /// <inheritdoc/>
    public override Doc VisitStructureBlock(StructureBlockSyntax node) =>
        TypeBlockRule.Format(node, this, _context);

    /// <inheritdoc/>
    public override Doc VisitInterfaceBlock(InterfaceBlockSyntax node) =>
        TypeBlockRule.Format(node, this, _context);

    /// <inheritdoc/>
    public override Doc VisitEnumBlock(EnumBlockSyntax node) => BlockRule.Format(
        Format(node.EnumStatement), node.Members, node.EndEnumStatement, this, _context);

    /// <inheritdoc/>
    public override Doc VisitMethodBlock(MethodBlockSyntax node) => FormatMethodBlock(node);

    /// <inheritdoc/>
    public override Doc VisitConstructorBlock(ConstructorBlockSyntax node) => FormatMethodBlock(node);

    /// <inheritdoc/>
    public override Doc VisitOperatorBlock(OperatorBlockSyntax node) => FormatMethodBlock(node);

    /// <inheritdoc/>
    public override Doc VisitAccessorBlock(AccessorBlockSyntax node) => FormatMethodBlock(node);

    /// <inheritdoc/>
    public override Doc VisitPropertyBlock(PropertyBlockSyntax node) => BlockRule.Format(
        Format(node.PropertyStatement), node.Accessors, node.EndPropertyStatement, this, _context);

    /// <inheritdoc/>
    public override Doc VisitEventBlock(EventBlockSyntax node) => BlockRule.Format(
        Format(node.EventStatement), node.Accessors, node.EndEventStatement, this, _context);

    /// <inheritdoc/>
    public override Doc VisitMultiLineIfBlock(MultiLineIfBlockSyntax node) => Doc.Concat(
        Format(node.IfStatement),
        BlockRule.Body(node.Statements, this, _context),
        StatementListRule.Format(node.ElseIfBlocks, this, _context),
        StatementListRule.Format(node.ElseBlock, this, _context),
        StatementListRule.Format(node.EndIfStatement, this, _context));

    /// <inheritdoc/>
    public override Doc VisitElseIfBlock(ElseIfBlockSyntax node) => Doc.Concat(
        Format(node.ElseIfStatement), BlockRule.Body(node.Statements, this, _context));

    /// <inheritdoc/>
    public override Doc VisitElseBlock(ElseBlockSyntax node) => Doc.Concat(
        Format(node.ElseStatement), BlockRule.Body(node.Statements, this, _context));

    /// <inheritdoc/>
    public override Doc VisitForBlock(ForBlockSyntax node) => FormatForBlock(node);

    /// <inheritdoc/>
    public override Doc VisitForEachBlock(ForEachBlockSyntax node) => FormatForBlock(node);

    /// <inheritdoc/>
    public override Doc VisitWhileBlock(WhileBlockSyntax node) => BlockRule.Format(
        Format(node.WhileStatement), node.Statements, node.EndWhileStatement, this, _context);

    /// <inheritdoc/>
    public override Doc VisitDoLoopBlock(DoLoopBlockSyntax node) => BlockRule.Format(
        Format(node.DoStatement), node.Statements, node.LoopStatement, this, _context);

    /// <inheritdoc/>
    public override Doc VisitTryBlock(TryBlockSyntax node) => Doc.Concat(
        Format(node.TryStatement),
        BlockRule.Body(node.Statements, this, _context),
        StatementListRule.Format(node.CatchBlocks, this, _context),
        StatementListRule.Format(node.FinallyBlock, this, _context),
        StatementListRule.Format(node.EndTryStatement, this, _context));

    /// <inheritdoc/>
    public override Doc VisitCatchBlock(CatchBlockSyntax node) => Doc.Concat(
        Format(node.CatchStatement), BlockRule.Body(node.Statements, this, _context));

    /// <inheritdoc/>
    public override Doc VisitFinallyBlock(FinallyBlockSyntax node) => Doc.Concat(
        Format(node.FinallyStatement), BlockRule.Body(node.Statements, this, _context));

    /// <inheritdoc/>
    public override Doc VisitUsingBlock(UsingBlockSyntax node) => BlockRule.Format(
        Format(node.UsingStatement), node.Statements, node.EndUsingStatement, this, _context);

    /// <inheritdoc/>
    public override Doc VisitWithBlock(WithBlockSyntax node) => BlockRule.Format(
        Format(node.WithStatement), node.Statements, node.EndWithStatement, this, _context);

    /// <inheritdoc/>
    public override Doc VisitSyncLockBlock(SyncLockBlockSyntax node) => BlockRule.Format(
        Format(node.SyncLockStatement), node.Statements, node.EndSyncLockStatement, this, _context);

    /// <summary>A <c>Select</c> has no statements of its own; its case blocks are the body.</summary>
    public override Doc VisitSelectBlock(SelectBlockSyntax node) => BlockRule.Format(
        Format(node.SelectStatement), node.CaseBlocks, node.EndSelectStatement, this, _context);

    /// <inheritdoc/>
    public override Doc VisitCaseBlock(CaseBlockSyntax node) => Doc.Concat(
        Format(node.CaseStatement), BlockRule.Body(node.Statements, this, _context));

    /// <summary>
    /// A lambda starts wherever the expression around it happens to end, so its body and its
    /// <c>End Function</c> hang off that column rather than off the enclosing statement's indent.
    /// </summary>
    public override Doc VisitMultiLineLambdaExpression(MultiLineLambdaExpressionSyntax node) => Doc.Align(
        BlockRule.Format(
            Format(node.SubOrFunctionHeader), node.Statements, node.EndSubOrFunctionStatement, this, _context));

    /// <summary><c>Sub</c>, <c>Function</c>, <c>New</c>, <c>Operator</c> and property accessors.</summary>
    private Doc FormatMethodBlock(MethodBlockBaseSyntax node) => BlockRule.Format(
        Format(node.BlockStatement), node.Statements, node.EndBlockStatement, this, _context);

    private Doc FormatForBlock(ForOrForEachBlockSyntax node) => BlockRule.Format(
        Format(node.ForOrForEachStatement), node.Statements, node.NextStatement, this, _context);
}
