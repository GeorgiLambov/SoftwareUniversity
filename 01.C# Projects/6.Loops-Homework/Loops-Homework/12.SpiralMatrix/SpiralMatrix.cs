using System;
//Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below. 
class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter a number:");
        int num = int.Parse(Console.ReadLine());
        int[,] matrix = new int[num, num];
        int counter = 1;
        int rowIndex = 0;
        int collIndex = 0;
        int maxRowIndex = num - 1;
        int maxCollIndex = num - 1;

        do
        {
            for (int i = collIndex; i <= maxCollIndex; i++)
            {
                matrix[rowIndex, i] = counter;
                counter++;
            }
            rowIndex++;
            for (int i = rowIndex; i <= maxRowIndex; i++)
            {
                matrix[i, maxCollIndex] = counter;
                counter++;
            }
            maxCollIndex--;
            for (int i = maxCollIndex; i >= collIndex; i--)
            {
                matrix[maxRowIndex, i] = counter;
                counter++;
            }
            maxRowIndex--;
            
            for (int i = maxRowIndex; i >= rowIndex; i--)
            {
                matrix[i, collIndex] = counter;
                counter++;
            }
            collIndex++;
        }
        while (counter <= num * num);

        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                Console.Write(matrix[rows, cols].ToString().PadRight(+3, ' '));
            }
            Console.WriteLine();

        }
    }
}