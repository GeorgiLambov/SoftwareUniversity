using System;
//Write a program that finds the biggest of five numbers by using only five if statements. 
class TheBiggestFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter five numbers");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());
        Console.Write("d = ");
        double d = double.Parse(Console.ReadLine());
        Console.Write("e = ");
        double e = double.Parse(Console.ReadLine());
        double bigestNumber = a;
        if ((b > a) && (b > c) && (b > d) && (b > e))
        {
            bigestNumber = b;
        }
        else if ((c > b) && (c > a) && (c > d) && (c > e))
        {
            bigestNumber = c;
        }
        else if ((d > a) && (d > b) && (d > c) && (d > e))
        {
            bigestNumber = d;
        }
        else if ((e > a) && (e > b) && (e > c) && (e > d))
        {
            bigestNumber = e;
        }

        Console.WriteLine("The biggest number is {0} !!!", bigestNumber);
    }
}

