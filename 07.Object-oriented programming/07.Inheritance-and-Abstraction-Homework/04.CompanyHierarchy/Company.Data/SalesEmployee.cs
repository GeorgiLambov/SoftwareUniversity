namespace Company.Data
{
    using System;
    using System.Collections.Generic;

    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private IList<ISale> sales;
        public SalesEmployee(string fname, string lname, string id, Department department, decimal salary, IList<ISale> sales)
            : base(fname, lname, id, department, salary)
        {
            this.Sales = sales;
        }



        public IList<ISale> Sales
        {
            get { return this.sales; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Sales", "Sales can not be null!");
                }

                this.sales = value;
            }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format("\nSales: \n{0}", string.Join("\n", this.Sales));
        }
    }
}
