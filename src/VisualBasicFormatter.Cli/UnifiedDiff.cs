using System.Text;

namespace VisualBasicFormatter.Cli;

/// <summary>Erzeugt ein Unified-Diff zweier Textfassungen.</summary>
internal static class UnifiedDiff
{
    private const int Context = 3;

    public static string Create(string path, string before, string after)
    {
        var a = before.ReplaceLineEndings("\n").Split('\n');
        var b = after.ReplaceLineEndings("\n").Split('\n');
        var lcs = LongestCommonSubsequence(a, b);

        var builder = new StringBuilder();
        builder.Append("--- ").Append(path).AppendLine();
        builder.Append("+++ ").Append(path).AppendLine();

        foreach (var hunk in Hunks(lcs))
        {
            builder
                .Append("@@ -").Append(hunk.StartA + 1).Append(',').Append(hunk.CountA)
                .Append(" +").Append(hunk.StartB + 1).Append(',').Append(hunk.CountB)
                .AppendLine(" @@");

            foreach (var (marker, line) in lcs.GetRange(hunk.From, hunk.To - hunk.From))
            {
                builder.Append(marker).AppendLine(line);
            }
        }

        return builder.ToString();
    }

    /// <summary>A line-by-line match as a sequence of markers: space, <c>-</c> or <c>+</c>.</summary>
    private static List<(char Marker, string Line)> LongestCommonSubsequence(string[] a, string[] b)
    {
        var lengths = new int[a.Length + 1, b.Length + 1];
        for (var i = a.Length - 1; i >= 0; i--)
        {
            for (var j = b.Length - 1; j >= 0; j--)
            {
                lengths[i, j] = a[i] == b[j]
                    ? lengths[i + 1, j + 1] + 1
                    : Math.Max(lengths[i + 1, j], lengths[i, j + 1]);
            }
        }

        var result = new List<(char, string)>();
        int x = 0, y = 0;
        while (x < a.Length && y < b.Length)
        {
            if (a[x] == b[y])
            {
                result.Add((' ', a[x++]));
                y++;
            }
            else if (lengths[x + 1, y] >= lengths[x, y + 1])
            {
                result.Add(('-', a[x++]));
            }
            else
            {
                result.Add(('+', b[y++]));
            }
        }

        while (x < a.Length)
        {
            result.Add(('-', a[x++]));
        }

        while (y < b.Length)
        {
            result.Add(('+', b[y++]));
        }

        return result;
    }

    /// <summary>Groups changes into hunks, each with <see cref="Context"/> lines of context.</summary>
    private static IEnumerable<Hunk> Hunks(List<(char Marker, string Line)> diff)
    {
        var changed = new bool[diff.Count];
        for (var i = 0; i < diff.Count; i++)
        {
            changed[i] = diff[i].Marker != ' ';
        }

        var index = 0;
        var lineA = 0;
        var lineB = 0;

        while (index < diff.Count)
        {
            if (!changed[index])
            {
                if (diff[index].Marker != '+')
                {
                    lineA++;
                }

                if (diff[index].Marker != '-')
                {
                    lineB++;
                }

                index++;
                continue;
            }

            var from = Math.Max(0, index - Context);
            var to = index;
            while (to < diff.Count)
            {
                var nextChange = FindNextChange(changed, to);

                // Liegen zwei Aenderungen dicht beieinander, gehoeren sie in denselben Block.
                if (nextChange >= 0 && nextChange - to <= Context * 2)
                {
                    to = nextChange + 1;
                    continue;
                }

                break;
            }

            to = Math.Min(diff.Count, to + Context);

            var (startA, startB) = Rewind(diff, from, lineA, lineB, index);
            var countA = diff.GetRange(from, to - from).Count(d => d.Marker != '+');
            var countB = diff.GetRange(from, to - from).Count(d => d.Marker != '-');

            yield return new Hunk(from, to, startA, startB, countA, countB);

            for (; index < to; index++)
            {
                if (diff[index].Marker != '+')
                {
                    lineA++;
                }

                if (diff[index].Marker != '-')
                {
                    lineB++;
                }
            }
        }
    }

    private static int FindNextChange(bool[] changed, int start)
    {
        for (var i = start; i < changed.Length; i++)
        {
            if (changed[i])
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>Counts back from the current position to the start of the hunk.</summary>
    private static (int A, int B) Rewind(
        List<(char Marker, string Line)> diff,
        int from,
        int lineA,
        int lineB,
        int index)
    {
        for (var i = index - 1; i >= from; i--)
        {
            if (diff[i].Marker != '+')
            {
                lineA--;
            }

            if (diff[i].Marker != '-')
            {
                lineB--;
            }
        }

        return (lineA, lineB);
    }

    private readonly record struct Hunk(int From, int To, int StartA, int StartB, int CountA, int CountB);
}
