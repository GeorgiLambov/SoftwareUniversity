using System;
//Write a program to find the longest area of equal elements in array of strings. You first should read an integer n and n strings (each at a separate line), then find and print the longest sequence of equal elements (first its length, then its elements). If multiple sequences have the same maximal length, print the leftmost of them. 
class LongestAreainArray
{
    static void Main()
    {
        int n =int.Parse(Console.ReadLine());
        string[] array = new string[n];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Console.ReadLine();
        }
        int maxSequence = 0;
        string value = null;

        for (int i = 0; i < array.Length; i++)
        {
            int countSequence = 0;
            for (int j = i; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    countSequence++;
                    if (maxSequence < countSequence)
                    {
                        maxSequence = countSequence;
                        value = array[i];
                    }
                }
                else
                {
                    break;
                }
            }
        }

        Console.WriteLine("{0}", maxSequence);
        for (int i = 0; i < maxSequence; i++)
        {
            Console.WriteLine("{0}", value);
        }
    }
}


