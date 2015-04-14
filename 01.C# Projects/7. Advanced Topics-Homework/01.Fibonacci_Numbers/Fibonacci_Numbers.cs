using System;
//Define a method Fib(n) that calculates the nth Fibonacci number.
class Fibonacci_Numbers
{
    
    static void FibonacciNumbers(int number)
    {
        int a = 0;
        int b = 1;
        int fibonacci = a + b;
        if (number > 1)
        {
            for (int i = 1; i <= number; i++)
            {
                fibonacci = a + b;
                a = b;
                b = fibonacci;
            }
            Console.WriteLine("Fibonacci number = {0}.", fibonacci);
        }
        else
        {
            Console.WriteLine("Fibonacci number = {0}.", fibonacci);
        }
        
    }
    
      static void Main()
    {
        Console.Write("n = ");
        int number = int.Parse(Console.ReadLine());
        FibonacciNumbers(number);
    }
}

