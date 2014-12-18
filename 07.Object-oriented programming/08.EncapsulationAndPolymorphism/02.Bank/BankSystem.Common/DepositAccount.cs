namespace BankSystem.Common
{
    using System;
    public class DepositAccount : Account, IWithdrawble, IDepositable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }
        public override decimal CalculateInterestAmount(int periodInMonths)
        {
            if (periodInMonths < 0)
            {
                throw new ArgumentOutOfRangeException("Interest period cannot be negative!");
            }
            if (this.Balance < 1000)
            {
                return 0.0m;
            }
            else
            {
                return this.Balance * (1 + this.InterestRate * periodInMonths);
            }
        }

        public void DepositMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot deposit negative amount of money!");
            }
            this.Balance += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot withdraw negative amount of money!");
            }
            if (this.Balance < amount)
            {
                throw new ArgumentOutOfRangeException("Cannot withdraw more money than the balanceof the amount!");
            }
            this.Balance -= amount;
        }
    }
}
