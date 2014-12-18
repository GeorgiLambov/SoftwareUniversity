using System;
using System.Collections.Generic;

namespace Company.Data
{
    using System.Collections;

    public class Manager : Employee, IManager
    {
        private IList<Employee> employres;

        public Manager(string fname, string lname, string id, Department department, decimal salary, IList<Employee> employres)
            : base(fname, lname, id, department, salary)
        {
            this.Employees = employres;
        }

        public IList<Employee> Employees
        {
            get { return this.employres; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Emplouees cannot be null.");
                }

                this.employres = value;
            }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            string employeesStr = string.Empty;

            foreach (var employer in this.Employees)
            {
                employeesStr += employer.FirstName + " " + employer.LastName + " ID:" + employer.Id + "\n";
            }

            return baseStr + string.Format("\nManaged employees: {0}", employeesStr);
        }
    }
}
