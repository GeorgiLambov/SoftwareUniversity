using System;
class ComparingFloats
{
    static void Main()
    {
        Console.WriteLine("The program is comparing floating-point numbers with precision of 0.000001.");
        Console.Write("Enter first number: ");
        decimal numberA = decimal.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        decimal numberB = decimal.Parse(Console.ReadLine());
        Console.WriteLine("The two numbers are {0} and {1}", numberA, numberB);
        bool comparing = (Math.Abs(numberA - numberB) < 0.000001m);
        if (comparing == true)
        {
            Console.WriteLine("The two number are equal.");
        }
        else
        {
            Console.WriteLine("The two number are not equal.");
        }
    }
}

