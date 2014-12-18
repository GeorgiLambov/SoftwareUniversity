namespace Animals
{
    using System;

    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name can not be an empty string.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age", "Age can not be a negative number.");
                }

                this.age = value;
            }
        }

        public Gender Gender
        {
            get { return this.gender; }
            protected set { this.gender = value; }
        }

        // define an abstract method ProduceSound() to be implemented by the derived classes
        public abstract string ProduceSound();

        // override the ToString() method
        public override string ToString()
        {
            return String.Format("my name is {0}, I'm {1} years old, I'm {2} and I can {3}",
                 this.name, this.age, this.gender, this.ProduceSound());
        }
    }
}
