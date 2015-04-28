namespace DistanceCalculatorClient
{
    using System;
    using CalcDistance;
    using ServiceReferenceCalculator;

    public class CalculatorClientUi
    {
        public static void Main()
        {
            CalculatorClient client = new CalculatorClient();

            var pointA = new Point(4, 5);
            var pointB = new Point(3, 4);
            var result = client.CalcDistance(pointA, pointB);

            Console.WriteLine("Distance: {0}", result);
        }
    }
}
