using System;
using System.Collections.Generic;
using System.Linq;
//Write a method that calculates all prime numbers in given range and returns them as list of integers:
class PrimesInGivenRange
{
    static void Main()
    {
        Console.WriteLine("Enter two integer startNum < endNum.");
        Console.Write("startNum = ");
        int startNum = int.Parse(Console.ReadLine());
        Console.Write("endNum = ");
        int endNum = int.Parse(Console.ReadLine());
        List<int> primesList = GetPrimesInRange(startNum, endNum);
        foreach (int prime in primesList)
        {
            Console.Write("{0} ", prime);
        }
        Console.WriteLine();
    }
    public static List<int> GetPrimesInRange(int startNum, int endNum)
    {
        List<int> primesList = new List<int>();
        if (startNum < 2)
        {
            startNum = 2;
        }

        for (int i = startNum; i <= endNum; i++)
        {


            bool prime = true;

            for (int j = 2; (j * j) <= i; j++)
            {
                if ((i % j) == 0)
                {
                    prime = false;
                    break;
                }
            }
            if (prime)
            {
                primesList.Add(i);
            }
        }
        return primesList;
    }
}





