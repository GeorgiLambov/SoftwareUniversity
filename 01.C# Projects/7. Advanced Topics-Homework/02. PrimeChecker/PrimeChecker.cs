using System;
//Write a Boolean method IsPrime(n) that check whether a given integer number n is prime. 
class PrimeChecker
{
    static void Main()
    {
        Console.Write("n = ");
        int number = int.Parse(Console.ReadLine());
        bool isPrime = IsPrime(number);
        Console.WriteLine("Number {0} is " + (isPrime ? "prime." : "not prime."), number);
    }
    static bool IsPrime(int number)
    {
        bool result = true;
        double upper = (int)Math.Sqrt(number);
        for (int i = 2; i <= upper; i++)
        {
            if ((number % i) == 0)
            {
                result = false;
                break;
            }
        }
        return result;
    }
}

