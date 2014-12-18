using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLearningSystem.Data
{
    public class DropoutStudent : Student
    {
        private string dropoutReason;
        public DropoutStudent(string fName, string lName, string id, int stdNumber, double averageGrade, string dropoutReason)
            : base(fName, lName, id, stdNumber, averageGrade)
        {
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get { return this.dropoutReason; }
            set
            {
                if (null == value) throw new ArgumentNullException("DropOut reason can not be null!");
                this.dropoutReason = value;
            }
        }
        public void Reapply()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
