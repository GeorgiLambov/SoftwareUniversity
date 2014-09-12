using System;
//Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum. 
namespace sumOf5Numbers
{
    class sumOf5Numbers
    {
        static void Main()
        {
            Console.WriteLine("Please enter a five digits separated by a space:");
            string numbers = Console.ReadLine();
            string[] splitedNumbers = numbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int num1 = int.Parse(splitedNumbers[0]);
            int num2 = int.Parse(splitedNumbers[1]);
            int num3 = int.Parse(splitedNumbers[2]);
            int num4 = int.Parse(splitedNumbers[3]);
            int num5 = int.Parse(splitedNumbers[4]);
            int sum = num1 + num2 + num3 + num4 + num5;
            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = {5}",
splitedNumbers[0], splitedNumbers[1], splitedNumbers[2], splitedNumbers[3], splitedNumbers[4], sum);
        }
    }
}
