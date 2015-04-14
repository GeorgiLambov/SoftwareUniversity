using System;
//Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
//•	Calculates the sum of the digits (in our example 2+0+1+1 = 4).
//•	Prints on the console the number in reversed order: dcba (in our example 1102).
//•	Puts the last digit in the first position: dabc (in our example 1201).
//•	Exchanges the second and the third digits: acbd (in our example 2101).
//The number has always exactly 4 digits and cannot start with 0

class FourDigitNumber
{
    static void Main(string[] args)
    {
        Console.Write("Enter a four digit number: ");
        int number = int.Parse(Console.ReadLine());
        int numD = number % 10;
        int numC = (number / 10) % 10;
        int numB = (number / 100) % 10;
        int numA = number / 1000;
        Console.WriteLine("Sum of the digits is: {0}", (numA+numB+numC+numD));
        Console.WriteLine("{0}, {1}, {2}, {3}", numD, numC, numB, numA);
        Console.WriteLine("{0}, {1}, {2}, {3}", numD, numA, numB, numC);
        Console.WriteLine("{0}, {1}, {2}, {3}", numA, numC, numB, numD);

    }
}

