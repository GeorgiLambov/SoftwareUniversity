using System;
//Write an expression that checks for given integer if its third digit from right-to-left is 7. 
    class ThirdDigitIs7
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer:");
            int num = int.Parse(Console.ReadLine());
            int numTwoPosishon = num / 100;
            int numThirdPosishon = numTwoPosishon % 10;
            Console.WriteLine((numThirdPosishon ==7)? true:false);
        }
    }

