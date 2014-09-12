using System;
//Write a program that calculates the greatest common divisor (GCD) of given two integers a and b. Use the Euclidean algorithm
class CalculateGCD
{
    static void Main()
    {
        Console.WriteLine("Enter two integer numbers.");
        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());
        int bigestNum = Math.Max(a, b);
        int smallestNum = Math.Min(a, b);
        int gcdNum = 1;
        int remainderNum = bigestNum % smallestNum;
        if (0 == remainderNum)
        {
            gcdNum = smallestNum;
         
        }
        else
        {
            while (remainderNum != 0)
            {

                bigestNum = smallestNum;
                smallestNum = remainderNum;
                gcdNum = smallestNum;
                remainderNum = bigestNum % smallestNum;
            }      
        }
        
        Console.WriteLine("The greatest common divisor (GCD) of given two integers a={0} and b={1} is {2}.", a, b, gcdNum);
    }
}

