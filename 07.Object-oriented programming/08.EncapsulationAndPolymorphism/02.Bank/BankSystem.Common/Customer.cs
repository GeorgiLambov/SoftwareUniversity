namespace BankSystem.Common
{
    using System;
    public abstract class Customer
    {
        protected Customer(uint id)
        {
            this.ID = id;
        }

        public uint ID
        {
            get;
            protected set;
        }
    }
}
