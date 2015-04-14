using System;
//Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500), a floating-point b and a floating-point c and prints them in 4 virtual columns on the console. Each column should have a width of 10 characters. The number a should be printed in hexadecimal, left aligned; then the number a should be printed in binary form, padded with zeroes, then the number b should be printed with 2 digits after the decimal point, right aligned; the number c should be printed with 3 digits after the decimal point, left aligned.
class FormattingNumbers
{
    static void Main(string[] args)
    {
        Console.Write("Enter an integer number /from 0 to 500 including/: ");
        int numA = int.Parse(Console.ReadLine());
        Console.Write("Enter an floating-point number: ");
        double numB = double.Parse(Console.ReadLine());
        Console.Write("Enter an floating-point number: ");
        double numC = double.Parse(Console.ReadLine());

        Console.WriteLine(new string ('=', 55));
        Console.WriteLine(" | {0, -10:X} | {1, 10} | {2, 10:F2} | {3, -10:F3} |", numA, Convert.ToString(numA, 2).PadLeft(10, '0'), numB, numC);
        Console.WriteLine(new string('=', 55));
    }
}

