using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLearningSystem.Data
{
    public abstract class Trainer : Person
    {
        public Trainer(string fName, string lName, string id)
            : base(fName, lName, id)
        {
        }
        public void CreateCourse(string courseName)
        {
            Console.WriteLine("{3}: {0} {1} - create course: {2}.", this.FName, this.LName, courseName, GetType().Name);
        }
    }
}
