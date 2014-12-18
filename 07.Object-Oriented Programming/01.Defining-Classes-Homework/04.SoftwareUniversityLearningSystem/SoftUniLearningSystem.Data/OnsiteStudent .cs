using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLearningSystem.Data
{
    public class OnsiteStudent : CurrentStudent
    {
        private int visits;
        public OnsiteStudent(string fName, string lName, string id, int stdNumber, double averageGrade)
            : base(fName, lName, id, stdNumber, averageGrade)
        {
            this.Visits = visits;
        }

        public int Visits
        {
            get { return this.visits; }
            set
            {
                if (value < 0)
                {
                    throw new ArithmeticException("Number of visits of student cannot be negative!");
                }

                this.visits = value;
            }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format("\nNumber of Visits: {0}", this.Visits);
        }
    }
}
