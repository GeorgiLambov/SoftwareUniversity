using System;

namespace Company.Data
{
    public abstract class Employee : Person, IEmployee
    {
        private Department department;
        private decimal salary;

        public Employee(string fname, string lname, string id, Department department, decimal salary)
            : base(fname, lname, id)
        {
            this.Salary = salary;
            this.Department = department;
        }
        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The value of salary must be positive!");
                }

                this.salary = value;
            }
        }

        public Department Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format("\nSalary: {0:N2}\nDepartment: {1}", this.Salary, this.Department);
        }
    }
}
