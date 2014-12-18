using System;
public class InterestCalculatorTest
{
    static void Main()
    {
        Func<decimal, double, int, decimal> simpleInterest = (sum, interest, years) =>
        {
            decimal result = sum * (decimal)(1 + (interest / 100) * years);
            return result;
        };

        Func<decimal, double, int, decimal> compoundInterest = (sum, interest, years) =>
        {
            decimal result = sum * (decimal)((1 + (interest / 12 / 100)) * (years * 12));
            return result;
        };

        InterestCalculator calc = new InterestCalculator(500m, 5.6, 10, compoundInterest);
        Console.WriteLine(calc);

        InterestCalculator claclSimpleInterest = new InterestCalculator(2500m, 7.2, 15, simpleInterest);
        Console.WriteLine(claclSimpleInterest);

    }
}


