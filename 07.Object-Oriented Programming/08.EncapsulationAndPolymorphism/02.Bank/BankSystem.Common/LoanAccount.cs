namespace BankSystem.Common
{
    using System;
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }
        public override decimal CalculateInterestAmount(int periodInMonths)
        {
            decimal interestAmount = 0.0m;
            if (periodInMonths < 0)
            {
                throw new ArgumentOutOfRangeException("Interest period cannot be negative!");
            }

            if (this.Customer is IndividualCustomer)
            {
                if (periodInMonths > 3)
                {
                    interestAmount = this.Balance * (1 + this.InterestRate * periodInMonths);
                }
            }
            else if (this.Customer is CompanyCustomer)
            {
                if (periodInMonths > 2)
                {
                    interestAmount = this.Balance * (1 + this.InterestRate * periodInMonths);
                }
            }
            return interestAmount;
        }

        public void DepositMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot deposit negative amount of money!");
            }
            this.Balance += amount;
        }
    }
}
