using System;
//Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix like in the examples below. Use two nested loops. 
class MatrixOfNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter a positive integer number.");
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        if (n <= 1 || n >= 20)
        {
            Console.Write("Invalid input!!");
            return;
        }
        for (int row = 0; row < n; row++)
        {
            int counter = row + 1;
            for (int col = 0; col < n; col++)
            {
                Console.Write(counter + " ");
                counter++;
            }
            Console.WriteLine();
        }
    }
}

