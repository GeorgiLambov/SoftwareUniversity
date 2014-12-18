namespace ShapeSurfaseCalculator.UI
{
    using System;
    using ShapeSurfaseCalculator.Common;
    class ShapeSurfaseCalculatorDemo
    {
        static void Main()
        {
            Triangle triangle = new Triangle();
            triangle.Side = 5;
            triangle.Heigth = 12.5;
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 4.1;
            rectangle.Heigth = 2;
            Circle circle = new Circle();
            circle.Radius = 6.3;

            BasicShape[] shapes = new BasicShape[] 
            {
                triangle,
                rectangle,
                circle,
                new Rectangle (2, 9),
                new Circle(7.8),
                new Triangle(5.3, 4)
            };

            // Printing the surfaces of the figures
            foreach (BasicShape shape in shapes)
            {
                Console.WriteLine("{0,-15}: Area:{1:F4}  Perimeter:{2:F4}", shape.GetType().Name, shape.CalculateArea(), shape.CalculatePerimeter());
            }
        }
    }
}
