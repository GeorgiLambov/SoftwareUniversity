using System;
using System.Text;
class IsoscelesTriangle
{
    static void Main()
    {
        char copyright = '\u00a9';
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("   "+copyright);
        Console.WriteLine(" " + " " + copyright+ " " + copyright);
        Console.WriteLine(" " + copyright + "   " + copyright);
        Console.WriteLine(copyright + " " + copyright + " " + copyright + " " + copyright);
    }
}

