using System;
//Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n has value of 1.
class CheckBitGivenPosition
{
    static void Main(string[] args)
    {
        Console.Write("Enter integer number: ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Enter a bit position: ");
        int bitPosition = int.Parse(Console.ReadLine());
        int numRightP = num >> bitPosition;
        int bit = numRightP & 1;
        Console.WriteLine((bit == 1)? true:false);
    }
}

