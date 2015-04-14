using System;
//Write a program that enters 3 real numbers and prints them sorted in descending order. Use nested if statements. Don’t use arrays and the built-in sorting functionality.
class Sort3NumberswithNestedIfs
{
    static void Main()
    {
        Console.WriteLine("Enter three real numbers");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());
        double min = a;
        double temp = 0;
        if (b > a)
        {
            temp = a;
            a = b;
            b = temp;
        }
        if (c > a)
        {
            temp = a;
            a = c;
            c = temp;
        }
       if (c > b)
        {
            temp = c;
            c = b;
            b = temp;
        }
        Console.WriteLine("The sorted numbers: {0}, {1}, {2}", a, b, c);
    }
}

