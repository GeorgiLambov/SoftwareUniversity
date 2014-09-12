using System;
//Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.
class DivideBy7and5
{
    static void Main(string[] args)
    {
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        if (number != 0)
        {
            Console.WriteLine((number % 35 == 0) ? true : false);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}

