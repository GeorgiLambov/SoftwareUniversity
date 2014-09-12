using System;
//Write a program that, depending on the user’s choice, inputs an int, double or string variable. If the variable is int or double, the program increases it by one. If the variable is a string, the program appends "*" at the end. Print the result at the console. Use switch statement. 
class PlaywithIntDoubleandString
{
    static void Main()
    {
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");
        Console.Write("Please choose a type: ");
        byte type = byte.Parse(Console.ReadLine());
        switch (type)
        {
            case 1: Console.Write("Please enter a int: ");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine("Resul = {0}", input + 1);
                break;
            case 2: Console.Write("Please enter a double: ");
                double inputD = double.Parse(Console.ReadLine());
                Console.WriteLine("Resul = {0}", inputD + 1);
                break;
            case 3: Console.Write("Please enter a string: ");
                string str = Console.ReadLine();
                Console.WriteLine(str + "*");
                break;
            default: Console.WriteLine("Not a int or double or string!!!");
                break;
        }

    }
}

