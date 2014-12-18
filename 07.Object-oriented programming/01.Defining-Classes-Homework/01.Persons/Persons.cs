using System;
using System.Collections.Generic;
class Persons
{
    static void Main()
    {
        List<Person> persons = new List<Person>() { };
        persons.Add(new Person("Gosho", 34));
        persons.Add(new Person("Pesho", 44, "pesho@pesho.bg"));
        persons.Add(new Person("Maria", 4, "mari@mari.bg"));
        persons.ForEach(param => Console.WriteLine(param));
    }
}
