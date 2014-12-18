using System;
class Program
{
    static void Main()
    {
        string whitQuoted = @"The ""use"" of quotations causes difficulties.";
        string whithoutQuated = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine(whitQuoted);
        Console.WriteLine(whithoutQuated);
    }
}

