using System;
class Program
{
    static void Main()
    {
        int? i = null;
        double? d = null;
        Console.WriteLine("I = {0} \nD = {1} ", i, d);
        int? c = i + 2;
        double? s = d + 3.14D;
        Console.WriteLine("I + 2 = {0} \nD + 3.14 = {1}", c, s);
    }
}

