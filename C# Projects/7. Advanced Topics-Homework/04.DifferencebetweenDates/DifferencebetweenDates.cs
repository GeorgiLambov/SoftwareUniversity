using System;
//Write a program that enters two dates in format dd.MM.yyyy and returns the number of days between them. Examples:
class DifferencebetweenDates
{
    static void Main()
    {
        Console.Write("Enter time a time in format “dd.MM.yyyy”: ");
        DateTime dateTime1 = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter time a time in format “dd.MM.yyyy”: ");
        DateTime dateTime2 = DateTime.Parse(Console.ReadLine());
        double numberOfDays = (dateTime2 - dateTime1).TotalDays;
        Console.WriteLine("The number of days between them : {0}", numberOfDays);
    }
}

