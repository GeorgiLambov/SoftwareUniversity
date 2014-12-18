using System;
namespace _01.SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            Console.Write("Enter a positive integer: ");
            string str = Console.ReadLine();
            try
            {
                int num = int.Parse(str);
                if (num < 0)
                {
                    throw new ArithmeticException("Invalid number! The square root is defined only for non-negative numbers!");
                }
                double squareRoot = Math.Sqrt(num);
                Console.WriteLine("The square root of {0} is {1}.", num, squareRoot);
            }
            catch (FormatException ex)
            {
                Console.Error.WriteLine("Invalid number!!!" + ex.Message);
                throw;
            }
            catch (OverflowException)
            {
                throw new OverflowException("The input number is too big or too small!");
            }
            finally
            {
                Console.WriteLine("Good Bye!");
            }
        }
    }
}
