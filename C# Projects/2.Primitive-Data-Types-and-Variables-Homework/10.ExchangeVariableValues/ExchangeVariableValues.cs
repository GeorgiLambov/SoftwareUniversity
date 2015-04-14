using System;
class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine(a);
        Console.WriteLine(b);
        b = b - a;
        a = a + b;
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}

