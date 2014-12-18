namespace _02.FractionCalculator
{
    using System;

    public struct Fraction
    {
        private long numerator;

        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
            this.Gcd();
        }

        public long Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public long Denominator
        {
            get { return this.denominator; }
            private set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("The denominator must not to be zero!");
                }
                if (value < 0)
                {
                    value *= -1;
                    this.Numerator *= -1;
                }
                this.denominator = value;
            }

        }

        public void Gcd()
        {
            long a = this.Numerator;
            long b = this.Denominator;
            while (b != 0)
            {
                long t = b;
                b = a % b;
                a = t;
            }

            this.Numerator = this.Numerator / a;
            this.Denominator = this.Denominator / a;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            checked
            {
                long newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
                long newDenominator = a.Denominator * b.Denominator;
                return new Fraction(newNumerator, newDenominator);
            }
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            checked
            {
                long newNumerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
                long newDenominator = a.Denominator * b.Denominator;
                return new Fraction(newNumerator, newDenominator);
            }
        }
        public override string ToString()
        {
            return ((decimal)this.Numerator / this.Denominator).ToString();
        }
    }
}
