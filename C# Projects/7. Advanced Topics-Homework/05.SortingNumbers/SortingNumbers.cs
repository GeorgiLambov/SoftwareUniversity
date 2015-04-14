using System;
//Write a program that reads a number n and a sequence of n integers, sorts them and prints them. 
class SortingNumbers
{
    static void Main()
    {
        Console.Write("Enter a positive integer n = ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter a value of element{0} ==> ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        
        SelectionSort(array);
        Console.WriteLine("Sortet numbers.");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Enter a value of element{0}==> {1}",i , array[i]);
        }

    }

        static void SelectionSort(int[] nubers)
    {
            int swap = 0;
 
            for (int i = 0; i < nubers.Length - 1; i++)
        {
            int index = i;
 
            for (int j = i + 1; j < nubers.Length; j++)
            if (nubers[j] < nubers[index])
                index = j;
            swap = nubers[i];
            nubers[i] = nubers[index];
            nubers[index] = swap;
        }
    }
}
