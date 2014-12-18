using System;

public class InterestCalculator
{
    private decimal money;
    private double interest;
    private int years;
    private decimal resultValue;

    public decimal Money
    {
        get { return this.money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Money can not be negative!");
            }
            this.money = value;
        }
    }
    public double Interest
    {
        get { return this.interest; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Interest can not be negative!");
            }
            this.interest = value;
        }
    }
    public int Years
    {
        get { return this.years; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Years can not be negative!");
            }
            this.years = value;
        }
    }

    public InterestCalculator(decimal money, double interest, int years, Func<decimal, double, int, decimal> CalculateInterest)
    {
        this.Money = money;
        this.Interest = interest;
        this.Years = years;
        this.resultValue = CalculateInterest(money, interest, years);
    }
    public override string ToString()
    {
        return string.Format("{0:F4}", this.resultValue);
    }
}
