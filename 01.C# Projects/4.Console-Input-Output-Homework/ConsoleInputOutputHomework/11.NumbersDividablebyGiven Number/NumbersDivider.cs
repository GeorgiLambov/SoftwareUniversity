using System;
//Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0.
class NumersDivider
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter two positive integer numbers.");
        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());
        int endLeght = Math.Max(a, b);
        int startLeght = Math.Min(a, b);
        int counter = 0;
        {
            for (int i = startLeght; i <= endLeght; i++)
            {
                if (i % 5 == 0)
                {

                    counter++;
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("There is {0} numbers dividable by 5!", counter);
        }

    }
}

