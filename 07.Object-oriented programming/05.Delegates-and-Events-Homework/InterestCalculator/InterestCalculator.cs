namespace InterestCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public delegate decimal CalculateInterest(decimal sum, decimal interest, int years);

    public class InterestCalculator
    {
        private decimal money;
        private decimal interest;
        private CalculateInterest calcInterest;
        private int years;

        public InterestCalculator(decimal money, decimal interest, int years, CalculateInterest calcInterest)
        {
            this.money = money;
            this.interest = interest;
            this.years = years;
            this.calcInterest = calcInterest;
        }

        public override string ToString()
        {
            return string.Format("{0} {1:p} {2} {3:F4}",  this.money, this.interest / 100, this.years, this.calcInterest(this.money, this.interest, this.years));
        }
    }
}
