using System;
//Write a program that gets two numbers from the console and prints the greater of them. Try to implement this without if statements.
class NumberComparer
{
    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        double firstNum = double.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        double secondNum = double.Parse(Console.ReadLine());
        Console.WriteLine("Greater: {0}", (firstNum + secondNum + Math.Abs(firstNum - secondNum)) / 2);
    }
}

