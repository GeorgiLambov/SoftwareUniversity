using System;
//The gravitational field of the Moon is approximately 17% of that on the Earth. Write a program that calculates the weight of a man on the moon by a given weight on the Earth
class GravitationOnTheMoon
{
    static void Main(string[] args)
    {
        Console.WriteLine("This program calculates the weight of the man on the Moon.");
        Console.WriteLine(new string('=', 57));
        Console.Write("Enter your weight:");
        double weight = double.Parse(Console.ReadLine());
        Console.WriteLine("Weight on the Moon is {0}.",(weight*0.17));
        Console.WriteLine(new string('=', 57));
    }
}

