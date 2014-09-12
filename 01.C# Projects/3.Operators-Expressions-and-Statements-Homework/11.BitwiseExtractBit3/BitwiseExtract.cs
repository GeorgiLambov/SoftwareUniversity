using System;
//Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer. The bits are counted from right to left, starting from bit #0. The result of the expression should be either 1 or 0.
class BitwiseExtract
{
    static void Main(string[] args)
    {
        Console.Write("Enter integer number: ");
        int num = int.Parse(Console.ReadLine());
        int numRightP = num >> 3;
        int bit = numRightP & 1;
        Console.WriteLine(bit);

    }
}

