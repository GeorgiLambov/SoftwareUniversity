namespace BankSystem.Common
{
    using System;
    public class CompanyCustomer : Customer
    {
        public CompanyCustomer(string name, uint id)
            : base(id)
        {
            this.Name = name;
        }

        public string Name
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return string.Format("Company name: {0}\nID: {1}", this.Name, this.ID);
        }
    }
}
