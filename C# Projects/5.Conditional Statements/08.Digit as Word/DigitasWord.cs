using System;
//Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English). Print “not a digit” in case of invalid inut. Use a switch statement.
class DigitAsWord
{
    static void Main()
    {
        Console.Write("Enter a number from 0 to 9: ");
        int number = int.Parse(Console.ReadLine());
        switch (number)
        {
            case 0: Console.WriteLine("The digit as a word is => Zero"); break;
            case 1: Console.WriteLine("The digit as a word is => One"); break;
            case 2: Console.WriteLine("The digit as a word is => Two"); break;
            case 3: Console.WriteLine("The digit as a word is => Three"); break;
            case 4: Console.WriteLine("The digit as a word is => Four"); break;
            case 5: Console.WriteLine("The digit as a word is => Five"); break;
            case 6: Console.WriteLine("The digit as a word is => Six"); break;
            case 7: Console.WriteLine("The digit as a word is => Seven"); break;
            case 8: Console.WriteLine("The digit as a word is => Eight"); break;
            case 9: Console.WriteLine("The digit as a word is => Nine"); break;
            default: Console.WriteLine("Not a digit!!"); break;
        }
    }
}

