using System;
//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer. 
class ExchangeBits
{
    static void Main()
    {
        //Write a program that exchanges bits 3, 4 and 5
        //with bits 24, 25 and 26 of given 32-bit unsigned integer.

        Console.Write("Enter unsigned integer: ");
        uint unInt = uint.Parse(Console.ReadLine());

        // here we get the value bit 3
        uint firstMask = 1 << 3;
        uint unIntAndFirstMask = unInt & firstMask;
        uint bitThree = unIntAndFirstMask >> 3;

        // here we get the value bit 4
        uint secondMask = 1 << 4;
        uint unIntAndSecondMask = unInt & secondMask;
        uint bitFour = unIntAndSecondMask >> 4;

        // here we get the value bit 5
        uint thirdMask = 1 << 5;
        uint unIntAndThirdMask = unInt & thirdMask;
        uint bitFive = unIntAndThirdMask >> 5;

        // here we get the value bit 24
        uint fourthMask = 1 << 24;
        uint unIntAndFourthMask = unInt & fourthMask;
        uint bitTwentyFour = unIntAndFourthMask >> 24;

        // here we get the value bit 25
        uint fifthMask = 1 << 25;
        uint unIntAndFifthNask = unInt & fifthMask;
        uint bitTwentyFive = unIntAndFifthNask >> 25;

        // here we get the value bit 26
        uint sixthMask = 1 << 26;
        uint unIntAndSixthMask = unInt & sixthMask;
        uint bitTwentySix = unIntAndSixthMask >> 26;

        uint temp;    // we will use temp for our temporary result
        uint result;  // in result we will keep our cuurent result

        // here we check bit 3 (is it 1 or 0)
        if (bitThree == 0)
        {
            uint mask = ~((uint)(1 << 24)); // if bit 3 is 0 we put 0 on position 24
            temp = unInt & mask;
        }
        else
        {
            uint mask = 1 << 24;    // if bit 3 is 1 we put 1 on position 24
            temp = unInt | mask;
        }
        result = temp;

        // here we check bit 4 (is it 1 or 0)
        if (bitFour == 0)
        {
            uint mask = ~((uint)(1 << 25));  // if bit 4 is 0 we put 0 on position 25
            temp = result & mask;
        }
        else
        {
            uint mask = 1 << 25;   // if bit 4 is 1 we put 1 on position 25
            temp = result | mask;
        }
        result = temp;

        // here we check bit 5 (is it 1 or 0)
        if (bitFive == 0)
        {
            uint mask = ~((uint)(1 << 26));  // if bit 5 is 0 we put 0 on position 26
            temp = result & mask;
        }
        else
        {
            uint mask = 1 << 26;   // if bit 5 is 1 we put 1 on position 26
            temp = result | mask;
        }
        result = temp;

        // here we check bit 24 (is it 1 or 0)
        if (bitTwentyFour == 0)
        {
            uint mask = ~((uint)(1 << 3));  // if bit 24 is 0 we put 0 on position 3
            temp = result & mask;
        }
        else
        {
            uint mask = 1 << 3;   // if bit 24 is 1 we put 1 on position 3
            temp = result | mask;
        }
        result = temp;

        // here we check bit 25 (is it 1 or 0)
        if (bitTwentyFive == 0)
        {
            uint mask = ~((uint)(1 << 4));   // if bit 25 is 0 we put 0 on position 4
            temp = result & mask;
        }
        else
        {
            uint mask = 1 << 4;    // if bit 25 is 1 we put 1 on position 4
            temp = result | mask;
        }
        result = temp;

        // here we check bit 26 (is it 1 or 0)
        if (bitTwentySix == 0)
        {
            uint mask = ~((uint)(1 << 5));  // if bit 26 is 0 we put 0 on position 5
            temp = result & mask;
        }
        else
        {
            uint mask = 1 << 5;  // if bit 26 is 1 we put 1 on position 5
            temp = result | mask;
        }
        result = temp;
        Console.WriteLine(result);
        // print our input number in its binary representation
        Console.WriteLine("The binary representation of number {0} is:  {1}", unInt, Convert.ToString(unInt, 2).PadLeft(32, '0'));
        // print our modified number in its binary representation
        Console.WriteLine("The binary representaion of modified {0} is: {1}", unInt, Convert.ToString(result, 2).PadLeft(32, '0'));
    }
}