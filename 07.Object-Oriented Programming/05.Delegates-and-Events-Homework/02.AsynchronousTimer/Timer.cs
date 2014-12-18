namespace AsynchronousTimer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Timer
    {
        public static void Main(string[] args)
        {
            AsyncTimer first = new AsyncTimer(SaySomething, 10, 1000);
            first.StartTimer();

            AsyncTimer second = new AsyncTimer(SaySomethingAgain, 10, 1000);
            second.StartTimer();

            Console.WriteLine("work");
        }

        private static void SaySomethingAgain()
        {
            Console.WriteLine("Works fine for me!");
        }

        private static void SaySomething()
        {
            Console.WriteLine("Work!");
        }
    }
}
