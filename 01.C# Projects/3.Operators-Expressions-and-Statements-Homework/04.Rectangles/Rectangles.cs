using System;
//Write an expression that calculates rectangle’s perimeter and area by given width and height
class Rectangles
{
    static void Main(string[] args)
    {
        Console.Write("Enter a width of rectangle: ");
        double widthA = double.Parse(Console.ReadLine());
        Console.Write("Enter a height of rectangle: ");
        double heightH = double.Parse(Console.ReadLine());
        Console.WriteLine("The perimeter of rectangle is: {0}", (2*widthA +2*heightH));
        Console.WriteLine("The area of rectange is: {0}", (widthA*heightH));
    }
}

