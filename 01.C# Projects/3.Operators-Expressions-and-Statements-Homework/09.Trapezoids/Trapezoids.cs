using System;
//Write an expression that calculates trapezoid's area by given sides a and b and height h. 
class Trapezoids
{
    static void Main(string[] args)
    {
        Console.Write("Enter integer for side a: ");
        double sideA = double.Parse(Console.ReadLine());
        Console.Write("Enter integer for side b: ");
        double sideB = double.Parse(Console.ReadLine());
        Console.Write("Enter integer for hight h: ");
        double hightH = double.Parse(Console.ReadLine());
        double trapezoidArea = (sideA + sideB) / 2 * hightH;
        Console.WriteLine("Trapezoid's area = {0} ", trapezoidArea);
    }
}

