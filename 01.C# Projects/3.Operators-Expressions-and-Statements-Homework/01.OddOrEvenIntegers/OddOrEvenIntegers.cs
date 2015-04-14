using System;
//Write an expression that checks if given integer is odd or even. 
class OddOrEvenIntegers
{
    static void Main()
    {
        Console.Write("Please enter a integer number: ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Odd? :");
        Console.WriteLine((num % 2 == 0) ? false : true);
    }
}

