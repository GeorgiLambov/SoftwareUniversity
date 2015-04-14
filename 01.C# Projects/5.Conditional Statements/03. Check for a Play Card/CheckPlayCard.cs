using System;
//Classical play cards use the following signs to designate the card face: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise.
class CheckPlayCard
{
    static void Main()
    {
        Console.Write("Please enter a card --> ");
        string isValidCard = Console.ReadLine();
        switch (isValidCard)
        {
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "J":
            case "Q":
            case "K":
            case "A":
                Console.WriteLine("Yes!");
                break;

            default: Console.WriteLine("No!");
                break;
        }
    }
}

