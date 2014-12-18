using System;

class MainInterestCalculator
{
    static void Main()
    {

        InterestCalculator calc = new InterestCalculator(500m, 5.6, 10, InterestCalculator.GetCompoundInterest);
        Console.WriteLine("{0:0.0000}", calc.ResultValue);

        calc = new InterestCalculator(2500m, 7.2, 15, InterestCalculator.GetSimpleInterest);
        Console.WriteLine("{0:0.0000}", calc.ResultValue);
    }

}

