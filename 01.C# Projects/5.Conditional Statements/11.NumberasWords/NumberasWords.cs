using System;
//Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation
class NumberasWords
{
    static void Main()
    {
        Console.Write("Enter a number from 0 to 999: ");
        int parametar = int.Parse(Console.ReadLine());
        if (parametar < 999 && parametar >= 0)
        {
            int temp = parametar;
            switch (temp / 100)
            {
                case 0:
                    break;
                case 1: Console.Write("Hundred");
                    break;
                case 2: Console.Write("Two hundred");
                    break;
                case 3: Console.Write("Three hundred");
                    break;
                case 4: Console.Write("Four hundred");
                    break;
                case 5: Console.Write("Five hundred");
                    break;
                case 6: Console.Write("Six hundred");
                    break;
                case 7: Console.Write("Seven hundred");
                    break;
                case 8: Console.Write("Eight hundred");
                    break;
                case 9: Console.Write("Nine hundred");
                    break;
                default: Console.WriteLine("Erorr");
                    break;
            }
            if (temp / 100 != 0 && temp % 100 != 0)
            {
                Console.Write(" and ");
            }
            switch (temp / 10 % 10)
            {
                case 0:
                    break;
                case 1:
                    {
                        switch (temp % 10)
                        {
                            case 0: Console.WriteLine("ten");
                                break;
                            case 1: Console.WriteLine("eleven");
                                break;
                            case 2: Console.WriteLine("twelve");
                                break;
                            case 3: Console.WriteLine("thirteen");
                                break;
                            case 4: Console.WriteLine("fourteen");
                                break;
                            case 5: Console.WriteLine("fiveteen");
                                break;
                            case 6: Console.WriteLine("sixteen");
                                break;
                            case 7: Console.WriteLine("seventeen");
                                break;
                            case 8: Console.WriteLine("eighteen");
                                break;
                            case 9: Console.WriteLine("nineteen");
                                break;

                            default: Console.Write("Erorr!!!");
                                break;
                        }
                    }
                    break;
                case 2: Console.Write("twenty and ");
                    break;
                case 3:
                    Console.Write("thirty and ");
                    break;
                case 4:
                    Console.Write("fory and  ");
                    break;
                case 5:
                    Console.Write("fifty and ");
                    break;
                case 6:
                    Console.Write("sixty and ");
                    break;
                case 7:
                    Console.Write("seventy and ");
                    break;
                case 8:
                    Console.Write("eighty and ");
                    break;
                case 9:
                    Console.Write("ninety and ");
                    break;

                default: Console.Write("Error");
                    break;
            }
            switch (temp % 10)
            {
                case 0:
                    if (temp == 0)
                    {
                        Console.Write("zero");
                    }
                    Console.Write("\n ");
                    break;
                case 1:
                    if (temp / 10 % 10 == 1) break;
                    Console.WriteLine("one");
                    break;
                case 2:
                    if (temp / 10 % 10 == 1) break;
                    Console.WriteLine("two");
                    break;
                case 3:
                    if (temp / 10 % 10 == 1) break;
                    Console.WriteLine("three ");
                    break;
                case 4:
                    if (temp / 10 % 10 == 1) break;
                    Console.WriteLine("four");
                    break;
                case 5:
                    if (temp / 10 % 10 == 1) break;
                    Console.WriteLine("five");
                    break;
                case 6:
                    if (temp / 10 % 10 == 1) break;
                    Console.WriteLine("six");
                    break;
                case 7:
                    if (temp / 10 % 10 == 1) break;
                    Console.WriteLine("seven ");
                    break;
                case 8:
                    if (temp / 10 % 10 == 1) break;
                    Console.WriteLine("eight ");
                    break;
                case 9:
                    if (temp / 10 % 10 == 1) break;
                    Console.WriteLine("nine ");
                    break;

                default: Console.WriteLine("Error report!"); break;
            }
        }

        else
        {
            Console.WriteLine(" Out of range! ");

        }
    }
}


