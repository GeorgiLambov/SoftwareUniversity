namespace Animals
{
    using System;

    // define a class Kitten which derives from Cat
    public class Kitten : Cat, ISound
    {
        public Kitten(string name, int age)
            : base(name, age, Gender.Female)
        {
        }

        // implemetn the ISound interface
        public override string ProduceSound()
        {
            return "miaooow";
        }

        // define a cry method
        public void Cry()
        {
            Console.WriteLine("I'm so cute I'll make you cry");
        }

        // override the ToString() method
        public override string ToString()
        {
            return String.Format("I'm a kiiten ") + base.ToString();
        }
    }
}