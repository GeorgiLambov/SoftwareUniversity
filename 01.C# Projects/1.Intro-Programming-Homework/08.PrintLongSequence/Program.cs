using System;
class PrintLongSequence
{
    static void Main()
    {
        Console.Write("Enter start number: ");
        int startNumber = int.Parse(Console.ReadLine());
        int counter = 1000;
        for (int i = startNumber; i < startNumber + counter; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(i + ", ");
            }
            else
            {
                Console.Write(-i + ", ");
            }
        }
        Console.WriteLine();
    }
}
