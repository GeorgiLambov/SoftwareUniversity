using System;
//A beer time is after 1:00 PM and before 3:00 AM. Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator) and prints “beer time” or “non-beer time” according to the definition above or “invalid time” if the time cannot be parsed. Note that you may need to learn how to parse dates and times. 
class BeerTime
{
    static void Main()
    {
        Console.Write("Enter time a time in format “hh:mm” an hour in range [01...12]: ");

        DateTime myDateTime = DateTime.Parse(Console.ReadLine());

        DateTime startDate = DateTime.Parse("1:00 pm");
        DateTime finishDate = DateTime.Parse("3:00 am");

        int result1 = DateTime.Compare(myDateTime, finishDate);
        int result2 = DateTime.Compare(myDateTime, startDate);



        if (result1 * result2 > 0 || result2 == 0)
        {
            Console.WriteLine("Beer time!");
        }
        else
        {
            Console.WriteLine("Non-beer time!");
        }
    }

}


