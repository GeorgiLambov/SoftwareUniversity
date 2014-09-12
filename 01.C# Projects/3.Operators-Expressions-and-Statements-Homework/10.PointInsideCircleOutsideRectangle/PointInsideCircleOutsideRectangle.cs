using System;
//Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2). 
class PointInsideCircleOutsideRectangle
{
    static void Main()
    {
        Console.Write("Enter integer for X coordinat: ");
        double cordinatX = double.Parse(Console.ReadLine());
        Console.Write("Enter integer for Y cordinat: ");
        double cordinatY = double.Parse(Console.ReadLine());
        bool dotInsideCircle = (Math.Pow(cordinatX-1, 2) + Math.Pow(cordinatY-1, 2) <= Math.Pow(1.5, 2));
        bool dotOutRectangle = (cordinatY >1);
        
        if (dotInsideCircle && dotOutRectangle) 
        {
            Console.Write("The point ({0},{1}) inside K & outside of R => true", cordinatX, cordinatY);
        }
        else
        {
            Console.Write("The point ({0},{1}) inside K & outside of R => false", cordinatX, cordinatY);
        }
        Console.WriteLine();
    }
}
