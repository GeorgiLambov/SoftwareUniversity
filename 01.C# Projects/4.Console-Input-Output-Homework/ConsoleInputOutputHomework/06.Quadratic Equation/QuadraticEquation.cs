using System;
//Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
class QuadraticEquation
{
    static void Main(string[] args)
    {
        Console.Write("Enter coefficient a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter coefficient b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter coefficient c = ");
        double c = double.Parse(Console.ReadLine());

        double d = ((b * b) - (4 * a * c));
        double x1 = ((-b - Math.Sqrt(d)) / (2 * a));
        double x2 = ((-b + Math.Sqrt(d)) / (2 * a));

        if (d < 0)
        {
            Console.WriteLine("no real roots");
        }
        else if (x1 == x2)
        {
            Console.WriteLine("x1 = x2 = " + x1);
        }
        else
        {
            Console.WriteLine("x1 = " + x1);
            Console.WriteLine("x2 = " + x2);
        }
    }
}

