using System.Reflection;

namespace VisualBasicFormatter.Bench;

internal static class Samples
{
    public static string Load(string name)
    {
        var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        return File.ReadAllText(Path.Combine(dir, "Samples", name + ".vb"));
    }
}
