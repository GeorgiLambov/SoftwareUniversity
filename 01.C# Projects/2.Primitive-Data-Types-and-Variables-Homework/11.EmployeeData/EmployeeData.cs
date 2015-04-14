using System;
class EmployeeData
{
    static void Main()
    {
        Console.Write("Please enter your first name: ");
        string firstName = (Console.ReadLine());
        Console.Write("Please enter your last name: ");
        string lastName = (Console.ReadLine());
        Console.Write("Please enter your Age: ");
        byte employAge = byte.Parse(Console.ReadLine());
        Console.Write("Please enter your gender M or F: ");
        char employGender = char.Parse(Console.ReadLine());
        Console.Write("Please enter your personal ID number: ");
        long employId = long.Parse(Console.ReadLine());
        Console.Write("Please enter your unique employee number: ");
        long employNum = long.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("Employee full name: {0} {1}", firstName, lastName);
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("Age: {0} Gender: {1}.", employAge, employGender);
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("Employee ID:{0}", employId);
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("Unique employee number:{0} ",employId);
        Console.WriteLine(new string('=', 50));
    }
}

