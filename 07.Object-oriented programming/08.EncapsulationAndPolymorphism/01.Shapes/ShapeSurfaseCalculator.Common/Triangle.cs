namespace ShapeSurfaseCalculator.Common
{
    using System;

    public class Triangle : BasicShape
    {
        public Triangle(double? side, double? heigth)
        {
            this.Side = side;
            this.Heigth = heigth;
        }
        public Triangle()
            : this(null, null)
        {
        }
        public double? Side
        {
            get { return this.width; }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Triangle's Side cannot be negative or zero!");
                }
                this.width = value;
            }
        }
        public double? Heigth
        {
            get { return this.heigth; }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Triangle's Heigth cannot be negative or zero!");
                }
                this.heigth = value;
            }
        }

        public override double CalculateArea()
        {
            if (this.Heigth == null)
            {
                throw new InvalidOperationException("Triangle's height is not provided!");
            }
            if (this.Side == null)
            {
                throw new InvalidOperationException("Triangle's width is not provided!");
            }
            return (this.Side.Value * this.Heigth.Value) / 2;
        }

        public override double CalculatePerimeter()
        {
            if (this.Heigth == null)
            {
                throw new InvalidOperationException("Triangle's height is not provided!");
            }
            if (this.Side == null)
            {
                throw new InvalidOperationException("Triangles's width is not provided!");
            }
            //  If that both angles at the base are acute!!! 
            return this.Side.Value + this.Heigth.Value + Math.Sqrt((this.Side.Value * this.Side.Value) + (this.Heigth.Value * this.Heigth.Value));
        }
    }
}
