using System;
//Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum. Note that you may need to use a for-loop
class Sum_Of_N_Numbers
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number of addend: ");
        int counter = int.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 1; i <= counter; i++)
        {
            Console.Write("Enter a number: ");
            double number = double.Parse(Console.ReadLine());
            sum = sum + number;
        }
        Console.WriteLine("The sum is: {0}.", sum);
    }
}
