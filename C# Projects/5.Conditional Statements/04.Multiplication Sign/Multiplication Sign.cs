using System;
//Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it. Use a sequence of if operators.
class MultiplicationSign
{
    static void Main()
    {
        Console.WriteLine("Enter three real numbers");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("C = ");
        double c = double.Parse(Console.ReadLine());
        bool zero = (a == 0) || (b == 0) || (c == 0);
        if (zero)
        {
            Console.WriteLine("The product of three numbers is 0.");
        }
        else if ((a < 0 && b > 0 && c > 0) || (b < 0 && a > 0 && c > 0) || (c < 0 && a > 0 && b > 0) || (a < 0 && b < 0 && c < 0))
        {
            Console.WriteLine("The product of three numbers is negative.");
        }
        else
        {
            Console.WriteLine("The product of three numbers is positive.");
        }
    }
}

