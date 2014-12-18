namespace ShapeSurfaseCalculator.Common
{
    using System;
    public abstract class BasicShape : IShape
    {
        protected double? width;
        protected double? heigth;

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();

    }
}
