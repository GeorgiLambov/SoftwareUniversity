using System;
//Write a program that reads from the console a sequence of n integer numbers and returns, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point). The input starts by the number n (alone in a line) followed by n lines, each holding an integer number. The output is like in the examples below.
class MinMaxSummandAverage
{
    static void Main()
    {
        Console.Write("Enter number of integer: ");
        double num = int.Parse(Console.ReadLine());
        int smallest = int.MaxValue;
        int biggest = int.MinValue;
        long sum = 0;
        for (int i = 0; i < num; i++)
        {
            
            int currentNumber;
            bool isInputValid = int.TryParse(Console.ReadLine(), out currentNumber);
            sum = sum + currentNumber;
            if (isInputValid == false)
            {
                Console.WriteLine("Invalid Input");
                return;
            }
            if (smallest > currentNumber)
            {
                smallest = currentNumber;
            }
            if (biggest < currentNumber)
            {
                biggest = currentNumber;
            }
        }
        double sumAver = (sum/num);
        Console.WriteLine("The minimal number of a sequence is: {0}.", smallest);
        Console.WriteLine("The maximal number of a sequence is: {0}.", biggest);
        Console.WriteLine("The sum is:{0}", sum);
        Console.WriteLine("The average of all numbers is:{0:f2}", sumAver);

    }
}
