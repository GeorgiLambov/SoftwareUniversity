using System;
//Write a program that reads 3 integer numbers from the console and prints their sum.
class SumOfthreeNuburs
{
    static void Main(string[] args)
    {
        Console.Write("Enter integer number: ");
        double numA = double.Parse(Console.ReadLine());
        Console.Write("Enter integer number: ");
        double numB = double.Parse(Console.ReadLine());
        Console.Write("Enter integer number: ");
        double numC = double.Parse(Console.ReadLine());
        double sum = numA + numB + numC;
        Console.WriteLine("The sum is {0}.", sum);
    }
}

