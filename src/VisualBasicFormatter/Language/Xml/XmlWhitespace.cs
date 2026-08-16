using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace VisualBasicFormatter.Language.Xml;

/// <summary>
/// Which XML literals may have their line breaks re-decided, and why that is allowed at all.
/// </summary>
/// <remarks>
/// VB is unusually accommodating here. The compiler copies only <em>significant</em> whitespace into
/// the LINQ-to-XML object a literal builds, and whitespace is significant in exactly three places:
/// inside an attribute value, inside element text that also carries other characters, and inside an
/// embedded expression. Everywhere else -- between children, inside a tag, around <c>&lt;%= %&gt;</c>
/// -- it is discarded, so indenting structural XML cannot change the <c>XElement</c> that comes out.
/// <para>
/// Roslyn draws the same line, which is what makes the test below a one-liner: whitespace between
/// markup is parsed as ordinary trivia, and an <see cref="XmlTextSyntax"/> appears only once the
/// content carries something other than whitespace -- at which point the whitespace around it is
/// folded into the text token. "Has no text child" is therefore exactly "has no significant
/// whitespace of its own".
/// </para>
/// <para>
/// The consequence worth keeping: the XML rules re-decide trivia and nothing else. They never add or
/// drop a token, so <c>VbFormatter.VerifyEquivalence</c> and the token multiset tests hold over them
/// unchanged, exactly as they do over every other rule.
/// </para>
/// </remarks>
internal static class XmlWhitespace
{
    /// <summary>
    /// Whether <paramref name="element"/>'s content may be laid out afresh. Text content -- prose, an
    /// entity, anything that is not markup -- makes the whitespace around it the author's, so an
    /// element carrying any is reproduced as it stands.
    /// </summary>
    public static bool IsFormattable(XmlElementSyntax element) =>
        !element.Content.Any(node => node is XmlTextSyntax);
}
