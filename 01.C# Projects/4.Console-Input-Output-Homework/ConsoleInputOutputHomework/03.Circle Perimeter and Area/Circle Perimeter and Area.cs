using System;
//Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.
class CirclePerimeterArea
{
    static void Main(string[] args)
    {
        Console.Write("Please enter the radius of a circle: ");
        double radius = double.Parse(Console.ReadLine());
        double circlePerimeter = 2 * Math.PI * radius;
        double circleArea = Math.PI * Math.Pow(radius, 2);
        Console.WriteLine("Perimeter of a circle with radius:{0} is equal: {1:F2}.", radius, circlePerimeter);
        Console.WriteLine("Area of a circle with radius:{0} is equal: {1:F2}.", radius, circleArea);
    }
}

