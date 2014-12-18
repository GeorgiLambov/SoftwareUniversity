using System;
using System.Collections.Generic;


namespace SoftUniLearningSystem.Data
{
    public abstract class CurrentStudent : Student
    {
        private IList<String> currentCourses;
        public CurrentStudent(string fName, string lName, string id, int stdNumber, double averageGrade) :
            base(fName, lName, id, stdNumber, averageGrade)
        {
            this.CurrentCourses = new List<string>();
        }

        public IList<string> CurrentCourses
        {
            get { return this.currentCourses; }
            set
            {
                if (null == value) throw new ArgumentNullException();
                this.currentCourses = value;
            }
        }
        public override string ToString()
        {
            string baseStr = base.ToString();
            string courses = String.Join(", ", this.CurrentCourses);
            return baseStr + string.Format(", Courses: {0}", courses);
        }
    }
}
