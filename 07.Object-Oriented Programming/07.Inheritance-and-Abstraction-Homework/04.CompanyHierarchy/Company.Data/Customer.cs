using System;

namespace Company.Data
{
    public class Customer : Person, ICustomer
    {
        private decimal netPurchaseAmount;
        public Customer(string firstName, string lastName, string id, decimal netPurchaseAmount)
            : base(firstName, lastName, id)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public decimal NetPurchaseAmount
        {
            get { return this.netPurchaseAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("NetPurchaseAmount cannot be negative!");
                }

                this.netPurchaseAmount = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("{0:N2}", this.NetPurchaseAmount);
        }
    }
}
