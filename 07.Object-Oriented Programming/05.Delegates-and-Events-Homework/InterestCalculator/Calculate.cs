namespace InterestCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Calculate
    {
        public static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            decimal result = sum * (1 + (interest * years));
            return result;
        }

        public static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
        {
            int period = 12;
            decimal result = (decimal)Math.Pow((double)(sum * (1 + (interest / period))), years * period);
            return result;
        }

        public static void Main(string[] args)
        {
            InterestCalculator interest = new InterestCalculator(500m, 5.6m, 10, GetSimpleInterest);
            Console.WriteLine(interest);
        }
    }
}
