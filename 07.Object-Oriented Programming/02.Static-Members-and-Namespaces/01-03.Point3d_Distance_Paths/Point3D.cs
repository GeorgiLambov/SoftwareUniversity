using System;
using System.Threading;
using System.Globalization;
public class Point3D
{
    private static readonly Point3D startingPoint = new Point3D(0, 0, 0);
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public Point3D(double x, double y, double z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public static Point3D StartingPoint
    {
        get { return Point3D.startingPoint; }
    }

    public override string ToString()
    {
        return string.Format("Point3D(X={0}, Y={1}, Z={2})", this.X, this.Y, this.Z);
    }
}
