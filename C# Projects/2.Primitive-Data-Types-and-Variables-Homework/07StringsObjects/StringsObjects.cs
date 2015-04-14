using System;
class StringsObjects
{
    static void Main()
    {
        string firstWord = "Hello";
        string secondWord = "World";
        object sentence = firstWord + " " + secondWord;
        Console.WriteLine(sentence + "!");
        string d = (string)sentence;
        Console.WriteLine(d + "!");
    }
}

