using System;
//Write an expression that checks if given positive integer number n (n ≤ 100) is prime (i.e. it is divisible without remainder only to itself and 1).
class PrimeNumberCheck
{
    static void Main(string[] args)
    {
        Console.Write("Enter positive integer number n (1 < n < 100) :");
        int number = int.Parse(Console.ReadLine());

        bool prime = true;
        int upper = (int)Math.Sqrt(number);
        for (int i = 2; i <= upper; i++)
        {
            if ((number % i) == 0)
            {
                prime = false;
                break;
            }
        }
        Console.WriteLine("Number {0} is " + (prime ? "prime." : "not prime."), number);
    }
}


