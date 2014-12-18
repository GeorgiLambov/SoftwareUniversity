using System;


namespace SoftUniLearningSystem.Data
{
    public class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string fName, string lName, string id)
            : base(fName, lName, id)
        {
        }
        public void DeleteCourse(string courseName)
        {
            Console.WriteLine("{3}: {0} {1} - DELETE course: {2}.", this.FName, this.LName, courseName, GetType().Name);
        }
    }
}
