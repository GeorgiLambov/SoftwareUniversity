using System;
using System.Collections.Generic;
using System.Text;

public class StringBuilderExtensions
{
    public static void Main()
    {
        StringBuilder str = new StringBuilder();
        str.Append("Test extension methods for the class StringBuilder.");
        Console.WriteLine(str.Substring(5, 17));
        Console.WriteLine(str.RemoveText("methods"));
        IEnumerable<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
        Console.WriteLine(str.AppendAll<int>(numbers));
    }
}
