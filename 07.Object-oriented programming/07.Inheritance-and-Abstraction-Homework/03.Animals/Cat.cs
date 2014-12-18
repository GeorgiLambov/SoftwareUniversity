namespace Animals
{
    using System;

    // define an abstract class cat whick derives from Animal
    public abstract class Cat : Animal
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }
    }
}