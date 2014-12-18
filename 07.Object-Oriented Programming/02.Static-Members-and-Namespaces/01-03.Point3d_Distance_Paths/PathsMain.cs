using System;
class PathsMain
{
    static void Main()
    {
        Console.WriteLine("StartingPoint : " + Point3D.StartingPoint);
        Point3D a = new Point3D(3, 4, 5);
        Point3D b = new Point3D(-1.3, 2, 5.8);
        Point3D c = new Point3D(0, -4.4, 7);
        Console.WriteLine(a);
        Console.WriteLine(c);

        double distance = DistanceCalculator.CalculateDistanse3D(a, c);
        Console.WriteLine("Distance: " + distance);

        Path3D path = new Path3D(a, c, Point3D.StartingPoint);
        Console.WriteLine("Path: " + path);

        Storage.SavePath("path.txt", path);

        Path3D loadPath = Storage.LoadPaths("path.txt");
        Console.WriteLine("Load path from file: " + loadPath);

    }
}
