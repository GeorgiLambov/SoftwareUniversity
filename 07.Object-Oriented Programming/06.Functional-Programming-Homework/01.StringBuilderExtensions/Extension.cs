using System.Collections.Generic;
using System.Text;

public static class Extension
{
    public static string Substring(this StringBuilder str, int startIndex, int length)
    {
        return str.ToString().Substring(startIndex, length);
    }

    public static StringBuilder RemoveText(this StringBuilder str, string text)
    {
        return str.Replace(text, string.Empty);
    }

    public static StringBuilder AppendAll<T>(this StringBuilder str, IEnumerable<T> collection)
    {
        return str.Append(string.Join(" ", collection));
    }
}

