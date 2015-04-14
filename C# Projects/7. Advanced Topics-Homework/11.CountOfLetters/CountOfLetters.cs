using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program that reads a list of letters and prints for each letter how many times it appears in the list. The letters should be listed in alphabetical order. Use the input and output format from the examples below. 
class CountofLetters
{
    static void Main()
    {
        Console.WriteLine("Please enter letters, separeted by space");
        string input = Console.ReadLine();
        string[] inputArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<char> letters = new List<char>();

        for (int i = 0; i < inputArray.Length; i++)
        {
            letters.Add(Convert.ToChar(inputArray[i]));
        }
        letters.Sort();
        int count = 1;
        for (int i = 1; i < letters.Count; i++)
        {
            if (letters[i] == letters[i - 1])
            {
                count++;
            }
            else
            {
                Console.WriteLine("{0} --> {1}", letters[i - 1], count);
                count = 1;
            }

            if (i == letters.Count - 1)
            {
                Console.WriteLine("{0} --> {1}", letters[i], count);
            }

        }
    }
}
