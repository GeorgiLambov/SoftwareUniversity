namespace ShapeSurfaseCalculator.Common
{
    using System;
    public class Circle : BasicShape
    {
        public Circle(double? radius)
        {
            this.Radius = radius;
        }
        public Circle()
            : this(null)
        {
        }

        public double? Radius
        {
            get { return this.width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Circle's radius must be a positive number!");
                }
                this.width = value;
                this.heigth = value;
            }
        }

        public override double CalculatePerimeter()
        {
            if (this.Radius == null)
            {
                throw new InvalidOperationException("The radius of the circle is not provided!");
            }

            return this.Radius.Value * Math.PI * Math.PI;
        }

        public override double CalculateArea()
        {
            if (this.Radius == null)
            {
                throw new InvalidOperationException("The radius of the circle is not provided!");
            }

            return this.Radius.Value * this.Radius.Value * Math.PI;
        }
    }
}
