using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLearningSystem.Data
{
    public abstract class Student : Person
    {
        private int stdNumber;
        private double averageGrade;
        public Student(string fName, string lName, string id, int stdNumber, double averageGrade) :
            base(fName, lName, id)
        {
            this.StdNumber = stdNumber;
            this.AverageGrade = averageGrade;
        }

        public int StdNumber
        {
            get { return this.stdNumber; }
            set
            {
                if (value <= 0) throw new ArgumentNullException("Student number can not be null or negative!");
                this.stdNumber = value;
            }
        }

        public double AverageGrade
        {
            get { return this.averageGrade; }
            set { this.averageGrade = value; }
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Student number: {0}, Average grade: {1}", this.stdNumber, this.AverageGrade);
        }
    }
}
