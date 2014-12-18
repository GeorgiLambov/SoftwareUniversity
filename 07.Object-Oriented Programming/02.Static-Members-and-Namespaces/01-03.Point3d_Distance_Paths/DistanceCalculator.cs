using System;
public static class DistanceCalculator
{
    public static double CalculateDistanse3D(Point3D firstPoint, Point3D secondPoint)
    {
        double distance = 0;
        distance = Math.Sqrt((firstPoint.X - secondPoint.X) * (firstPoint.X - secondPoint.X) +
            (firstPoint.Y - secondPoint.Y) * (firstPoint.Y - secondPoint.Y) +
            (firstPoint.Z - secondPoint.Z) * (firstPoint.Z - secondPoint.Z));
        return distance;
    } 
}

