using System;
//Write an expression that checks if given point (x,  y) is inside a circle K({0, 0}, 2). 
class PointInCircle
{
    static void Main(string[] args)
    {
        Console.Write("Enter integer for X coordinat: ");
        double cordinatX = double.Parse(Console.ReadLine());
        Console.Write("Enter integer for Y cordinat: ");
        double cordinatY = double.Parse(Console.ReadLine());
        if (Math.Pow(cordinatX, 2)+ Math.Pow(cordinatY, 2) <= 4)
        {
            Console.Write("The point ({0},  {1}) is inside a circle.", cordinatX, cordinatY);
        }
        else
        {
            Console.Write("The point ({0},  {1}) is not inside a circle.", cordinatX, cordinatY);
        }

        Console.WriteLine();
    }
}
