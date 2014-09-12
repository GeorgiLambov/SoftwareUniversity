using System;
//In combinatorics, the number of ways to choose k different members out of a group of n different elements (also known as the number of combinations) is calculated by the following formula:Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops. 
 
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter two integer n and k (1 < k < n < 100).");
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());        
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        
        if (k >= n || n <= 1 || k <= 1 || n > 100)
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        int firstFactorial = 1;
        for (int i = n; i > (n - k); i--)
        {
            firstFactorial *= i;
        }
       int secondFactorial = 1;
        for (int m = k; m > 1; m--)
        {
            secondFactorial *= m;
        }
        int result = firstFactorial / secondFactorial;
        Console.WriteLine("The result is: {0}", result);

    }
}

