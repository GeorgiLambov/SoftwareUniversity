using System;
using System.Numerics;
//Write a program that calculates n! / k! for given n and k (1 < k < n < 100). Use only one loop. 
class CalculateNK
{
    static void Main()
    {
        Console.WriteLine("Enter two digits k < n.");
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        BigInteger result = 1;
        if (k >= n || n <= 1 || k <= 1 || n > 100)
        {
            Console.WriteLine("Invalid input");
            return;
        }
        for (int i = k + 1 ; i <= n; i++)
        {
            result *= i;
        }
        Console.WriteLine("Calculate result n! / k! ={0}", result);
    }
}
