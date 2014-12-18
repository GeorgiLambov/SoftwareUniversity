﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public struct Point
    {
        public readonly int X;

        public readonly int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(string xString, string yString)
        {
            this.X = int.Parse(xString);
            this.Y = int.Parse(yString);
        }

        public override int GetHashCode()
        {
            return this.X * 7 + this.Y;
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            try
            {
                Point other = (Point)obj;
                return this.X == other.X && this.Y == other.Y;
            }
            catch (InvalidCastException)
            {
                return false;
            }


        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", this.X, this.Y);
        }

        public static Point Parse(string pointString)
        {
            string coordinatesPairString = pointString.Substring(1, pointString.Length - 2);
            string[] coordinates = coordinatesPairString.Split(',');
            return new Point(coordinates[0], coordinates[1]);
        }

        public static int GetManhattanDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}
