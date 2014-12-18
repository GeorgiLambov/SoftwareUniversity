namespace ShapeSurfaseCalculator.Common
{
    using System;

    public class Rectangle : BasicShape
    {
        public Rectangle(double? width = null, double? heigth = null)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public double? Width
        {
            get { return this.width; }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rectangle's Width cannot be negative or zero!");
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
                    throw new ArgumentOutOfRangeException("Rectangle's Heigth cannot be negative or zero!");
                }
                this.heigth = value;
            }
        }

        public override double CalculateArea()
        {
            if (this.Heigth == null)
            {
                throw new InvalidOperationException("Rectangle's height is not provided!");
            }
            if (this.Width == null)
            {
                throw new InvalidOperationException("Rectangle's width is not provided!");
            }
            return this.Width.Value * this.Heigth.Value;
        }

        public override double CalculatePerimeter()
        {
            if (this.Heigth == null)
            {
                throw new InvalidOperationException("Rectangle's height is not provided!");
            }
            if (this.Width == null)
            {
                throw new InvalidOperationException("Rectangle's width is not provided!");
            }
            return (this.Width.Value + this.Heigth.Value) * 2;
        }
    }
}
