using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLearningSystem.Data
{
    class GradulateStudent : Student
    {
        public GradulateStudent(string fName, string lName, string id, int stdNumber, double averageGrade)
            : base(fName, lName, id, stdNumber, averageGrade)
        {
        }

        public override string ToString()
        {
            return base.ToString() + " This is Gradulate Student!";
        }
    }
}
