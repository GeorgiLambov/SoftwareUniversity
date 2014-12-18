using System;
using System.Collections.Generic;

namespace Company.Data
{
    public class Developer : RegularEmployee, IDeveloper
    {
        private IList<Projects> projects;
        public Developer(string fname, string lname, string id, Department department, decimal salary, IList<Projects> projects)
            : base(fname, lname, id, department, salary)
        {
            this.Projects = projects;
        }

        public IList<Projects> Projects
        {
            get
            {
                return this.projects;
            }

            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException("Projects", "Projects can not be null!");
                }

                this.projects = value;
            }
        }
        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format("\nProjects: \n{0}", string.Join("\n", this.Projects));
        }
    }
}
