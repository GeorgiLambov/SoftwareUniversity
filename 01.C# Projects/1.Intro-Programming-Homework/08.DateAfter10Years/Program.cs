using System;
class DateAfter10Years
{
    static void Main()
    {
        Console.Write("Please enter your age: ");
        int currentAge = int.Parse(Console.ReadLine());
        int ageAfterTenYears = currentAge + 10;
        Console.Write("Your age after 10 years will be : {0}", ageAfterTenYears);
        Console.WriteLine();

    }
}

