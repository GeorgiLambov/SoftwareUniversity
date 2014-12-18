using System;

public delegate decimal CalculateInterest(decimal sum, double interest, int years);
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
    public decimal ResultValue
    {
        get { return this.resultValue; }
        private set { this.resultValue = value; }
    }
    public InterestCalculator(decimal money, double interest, int years, CalculateInterest type)
    {
        this.Money = money;
        this.Interest = interest;
        this.Years = years;
        this.ResultValue = type(money, interest, years);
    }

    public static decimal GetSimpleInterest(decimal sum, double interest, int years)
    {
        decimal result = sum * (decimal)(1 + (interest / 100) * years);
        return result;
    }

    public static decimal GetCompoundInterest(decimal sum, double interest, int years)
    {
        decimal result = sum * (decimal)((1 + (interest / 12 / 100)) * (years * 12));
        return result;
    }
}

