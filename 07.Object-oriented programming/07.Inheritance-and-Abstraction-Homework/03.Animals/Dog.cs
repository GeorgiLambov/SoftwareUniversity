namespace Animals
{
    using System;

    // define a class Dog which derive from Animal and implements ISound
    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        // implemetn the Isound interface 
        public override string ProduceSound()
        {
            return "bark";
        }

        // define a method for fetching a stick
        public void FetchStick()
        {
            Console.WriteLine("Throw me a stick and I'll fetch it for you.");
        }

        // override the ToString() method
        public override string ToString()
        {
            return String.Format("I'm a dog ") + base.ToString();
        }
    }
}