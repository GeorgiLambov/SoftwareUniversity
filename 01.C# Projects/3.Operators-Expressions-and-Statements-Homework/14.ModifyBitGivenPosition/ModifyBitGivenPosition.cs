using System;
//We are given an integer number n, a bit value v (v=0 or 1) and a position p. Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v at the position p from the binary representation of n while preserving all other bits in n. 
class ModifyBitGivenPosition
{
    static void Main(string[] args)
    {
        Console.Write("Enter integer number: ");
        int num = int.Parse(Console.ReadLine());
        Console.Write("Enter a bit position: ");
        int bitPosition = int.Parse(Console.ReadLine());
        Console.Write("Enter a value: ");       
        int value = int.Parse(Console.ReadLine());
       

        // Change the bit at the given position
        if (0 == value)
        {
            value = ~(1 << bitPosition);
            value = value & num;
        }
        else
        {
            value = 1 << bitPosition;
            value = value | num;
        }

        Console.WriteLine(value);
    }
}

