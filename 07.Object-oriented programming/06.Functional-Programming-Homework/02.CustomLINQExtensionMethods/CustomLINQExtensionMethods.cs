using System;
using System.Collections.Generic;
class CustomLINQExtensionMethods
{
    static void Main()
    {
        IEnumerable<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
        Console.WriteLine(string.Join(", ", numbers.WhereNot<int>(a => a == 3)));

        Console.WriteLine(string.Join(", ", numbers.Repeat<int>(2)));

        IEnumerable<string> str = new List<string>() { "FirstName", "LastName", "Age", "FacultyNumber", "Phone", "Email", "GroupNumber" };
        IEnumerable<string> suffixes = new List<string>() { "Name", "Number" };
        Console.WriteLine(string.Join(", ", str.WhereEndsWith(suffixes)));
    }
}

