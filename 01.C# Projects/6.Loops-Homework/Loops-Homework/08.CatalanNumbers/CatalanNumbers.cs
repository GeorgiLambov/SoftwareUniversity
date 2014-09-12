using System;
using System.Numerics;
//In combinatorics, the Catalan numbers are calculated by the following formula: write a program to calculate the nth Catalan number by given n (1 < n < 100). 

class CatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter a number(1 < n < 100).");
        Console.Write( "n = ");
        int n = int.Parse(Console.ReadLine());
        if (n < 0 || n > 100)
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        BigInteger num = 1;
        for (int i = 2 * n; i > n + 1; i--)
        {
            num *= i;
        }

        BigInteger denominator = 1;
        for (int k = n; k > 1; k--)
        {
            denominator *= k;
        }
        BigInteger catalanNumber = num / denominator;
        Console.WriteLine("The Catalan number by {0} is {1}.", n, catalanNumber);

    }
}

