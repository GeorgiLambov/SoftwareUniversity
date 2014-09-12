using System;
//Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/xn. Use only one loop. Print the result with 5 digits after the decimal point.
class CalculateNumbersNandX
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("x = ");
        int x = int.Parse(Console.ReadLine());
        double factoriel = 1;
        double sum = 1;
        double powX = 1;
        for (int i = 1; i <= n; i++)
        {
            factoriel *= i;
            powX *= x ;
            sum += (factoriel / powX);
        }
        Console.WriteLine("{0:f5}", sum);
    }
}
