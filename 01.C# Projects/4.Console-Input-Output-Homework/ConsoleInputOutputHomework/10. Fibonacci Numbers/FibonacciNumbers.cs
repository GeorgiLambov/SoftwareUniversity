using System;
using System.Numerics;
//Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by spaces) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, …. Note that you may need to learn how to use loops
class FibonacciNumbers
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number of members of the Fibonacci sequence: ");
        int counter = int.Parse(Console.ReadLine());
        BigInteger a = 0;
        BigInteger b = 1;
        BigInteger fibonacciNum = a + b;
        Console.Write("0, ");
        for (int i = 0; i <= counter; i++)
        {
            Console.Write("{0}" + ", ", fibonacciNum);
            fibonacciNum = a + b;
            a = b;
            b = fibonacciNum;
        }
        Console.WriteLine();
    }
}