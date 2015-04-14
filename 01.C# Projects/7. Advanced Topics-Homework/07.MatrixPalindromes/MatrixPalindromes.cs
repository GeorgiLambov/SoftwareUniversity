using System;
//Write a program to generate the following matrix of palindromes of 3 letters with r rows and c columns:
class MatrixPalindromes
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());

        string[,] matrix = new string[height, width];

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                matrix[row, col] = "" + (char)('a' + row) + (char)('a' + col + row) + (char)('a' + row);
            }
        }

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}
