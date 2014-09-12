using System;

//Write a program that calculates with how many zeroes the factorial of a given number n has at its end. Your program should work well for very big numbers, e.g. n=100000. 
class TrailingZeroesinN
{
    static void Main()
    {
        Console.Write("Enter number n = ");
        int n = int.Parse(Console.ReadLine());
        int divider = 5;
        int result = 0;
        while (n / divider >= 1)
        {
            result = result + (n / divider);
            divider *= 5;
        }
        Console.WriteLine("The factorial of a given number n={0} has at {1} zeros of its end.", n, result);
    }
}

