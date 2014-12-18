using System;
using System.Linq;


namespace Animals
{
    // test the program
    public class DemoAnimals
    {
        static void Main()
        {
            // create some animals from each class and print them
            Dog dog = new Dog("Sharo", 3, Gender.Male);
            Console.WriteLine(dog);
            dog.FetchStick();

            Console.WriteLine();

            Frog frog = new Frog("Kermit", 33, Gender.Male);
            Console.WriteLine(frog);
            frog.Jump();

            Console.WriteLine();

            Kitten kitty = new Kitten("Kitty", 1);
            Console.WriteLine(kitty);
            kitty.Cry();

            Console.WriteLine();

            Tomcat tomcat = new Tomcat("Tom", 12);
            Console.WriteLine(tomcat);
            tomcat.Piss();

            Console.WriteLine();

            // create an array of Animals
            Animal[] animals = new Animal[]
            {
                new Dog("Rex",3, Gender.Male),
                new Frog("Kekerica", 1, Gender.Female),
                new Kitten("Pisi", 1),
                new Tomcat("Tom",2),
                new Dog("Erik", 4, Gender.Male),
                new Frog("Penka", 1, Gender.Female),
                new Kitten("Jasmin", 2),
                new Tomcat("Kolio",6),
                new Dog("Bender",2, Gender.Male),
                new Frog("Ginka", 6, Gender.Female),
                new Kitten("Tedy", 1),
                new Tomcat("Muncho",4),
            };

            // calculate the aveage age of each animal and print them 
            var averageAge =
                from an in animals
                group an by new { GroupName = an.GetType().Name } into gr
                select new
                {
                    GroupName = gr.Key.GroupName,
                    AvarageAge = gr.Average(an => an.Age)
                };

            foreach (var animal in averageAge)
            {
                Console.WriteLine(String.Format("Group: {0}, AvarageAge: {1:0.00}.", animal.GroupName, animal.AvarageAge));
            }
        }
    }
}