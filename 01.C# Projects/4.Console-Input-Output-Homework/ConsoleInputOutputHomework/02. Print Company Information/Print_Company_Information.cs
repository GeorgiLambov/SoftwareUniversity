using System;
//A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. Write a program that reads the information about a company and its manager and prints it back on the console.
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Enter company adress: ");
        string companyAdress = Console.ReadLine();
        Console.Write("Enter company phone number: ");
        string companyPhone = Console.ReadLine();
        Console.Write("Enter company fax number: ");
        string companyFax = Console.ReadLine();
        Console.Write("Enter company web site: ");
        string companyWeb = Console.ReadLine();
        Console.Write("Enter company manager first name: ");
        string companyManagerFirstName = Console.ReadLine();
        Console.Write("Enter company manager last name: ");
        string companyManagerLastName = Console.ReadLine();
        Console.Write("Enter company manager age: ");
        string companyManagerAge = Console.ReadLine();
        Console.Write("Enter company manager phone: ");
        string companyManagerPhone = Console.ReadLine();
        Console.WriteLine(new string('=', 60));
        Console.WriteLine("{0, 40}", "Company Information");
        Console.WriteLine("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}", companyName, companyAdress, companyManagerPhone, companyFax, companyWeb);
        Console.WriteLine(new string('=', 60));
        Console.WriteLine("{0, 40}", "Manager Information");
        Console.WriteLine("{0} {1}\r\n {2}\r\n {3}\r\n", companyManagerFirstName, companyManagerLastName, companyManagerAge, companyManagerPhone);
        Console.WriteLine(new string('=', 60));

    }
}

