using System;
using System.Collections.Generic;
public class Path3D
{
    private List<Point3D> path = new List<Point3D>();
    public Path3D(params Point3D[] points)
    {
        if (points.Length > 0)
        {
            this.path.AddRange(points);
        }
    }
    public void AddPoint(Point3D point)
    {
        this.path.Add(point);
    }
    public override string ToString()
    {
        return string.Join(" ", this.path);
    }

}

