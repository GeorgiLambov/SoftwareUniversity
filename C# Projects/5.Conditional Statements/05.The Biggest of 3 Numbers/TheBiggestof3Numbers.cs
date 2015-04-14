using System;
// Write a program that finds the biggest of three numbers.
class TheBiggestof3Numbers
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());
        double bigestNumber = a;
        if ((b > a) && (b > c))
        {
            bigestNumber = b;
        }
        else if ((c > b) && (c > a))
        {
            bigestNumber = c;
        }

        Console.WriteLine("The biggest number is {0}", bigestNumber);
    }
}

