using System;

namespace SoftUniLearningSystem.Data
{
    public abstract class Person
    {
        private string fName;
        private string lName;
        private string id;

        public Person(string fName, string lName, string id)
        {
            this.FName = fName;
            this.LName = lName;
            this.Id = id;
        }

        public string FName
        {
            get { return this.fName; }
            protected set
            {
                if (value.Length < 3 || null == value) throw new ArgumentException("Invalid first name");
                this.fName = value;
            }
        }
        public string LName
        {
            get { return this.lName; }
            protected set
            {
                if (value.Length < 3 || null == value) throw new ArgumentException("Invalid last name");
                this.lName = value;
            }
        }

        public string Id
        {
            get { return this.id; }
            protected set
            {
                if (value.Length < 10)
                {
                    throw new ArgumentOutOfRangeException("Person ID must be exacly 10 digits.");
                }
                this.id = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{3}: Name: {0} {1}, ID: {2}", this.FName, this.LName, this.Id, GetType().Name);
        }
    }
}
