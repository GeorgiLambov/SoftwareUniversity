using System;
//Write an expression that extracts from given integer n the value of given bit at index p
class ExtractBitfromInteger
{
    static void Main(string[] args)
    {
        Console.Write("Enter integer number: ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Enter a bit position: ");
        int bitPosition = int.Parse(Console.ReadLine());
        int numRightP = num >> bitPosition;
        int bit = numRightP & 1;
        Console.WriteLine(bit);
    }
}

