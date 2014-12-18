namespace BankSystem.Common
{
    using System;
    public abstract class Account
    {
        private decimal balance;
        private decimal interestRate;
        private Customer customer;
        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get { return this.customer; }
            protected set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            protected set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("Account's balance must be positive!!!");
                }
                this.balance = value;
            }
        }
        public decimal InterestRate
        {
            get { return this.interestRate; }
            protected set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("Account's interest rate  must be positive!!!");
                }
                this.interestRate = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Account type: {0}\n{1}\nBalance: {2:C2}\nInterest Rate: {3}%\n", this.GetType().Name, this.Customer, this.Balance, this.InterestRate);
        }

        public abstract decimal CalculateInterestAmount(int periodInMonths);
    }
}
