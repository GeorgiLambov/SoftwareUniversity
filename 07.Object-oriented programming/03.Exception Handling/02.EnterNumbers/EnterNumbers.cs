using System;
class EnterNumbers
{
    static void Main()
    {
        int start = 1;
        int counter = 0;
        while (counter < 10)
        {
            {
                try
                {
                    int num = ReadNumber(start, 100);
                    if (num > start)
                    {
                        start = num;
                    }
                    counter++;
                }
                catch (FormatException fe)
                {
                    Console.Error.WriteLine("{0} Enter again!!!", fe.Message);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("{0} Enter again!!!", ex.Message);
                }
            }
        }
    }
    static int ReadNumber(int start, int end)
    {
        Console.WriteLine("Enter an integer number in given range [{0}.....{1}]!", start, end);
        int num = Int32.Parse(Console.ReadLine());
        if (num <= start || num > end)
        {
            throw new ArgumentOutOfRangeException("The number is not in the range" + "[" + start + "..." + end + "]!!!");
        }
        return num;
    }
}

