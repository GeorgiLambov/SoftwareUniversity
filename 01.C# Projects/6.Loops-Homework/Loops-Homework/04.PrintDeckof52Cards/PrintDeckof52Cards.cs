using System;
//Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers). The cards should be printed using the classical notation (like 5♠, A♥, 9♣ and K♦). The card faces should start from 2 to A. Print each card face in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement.
class PrintDeckof52Cards
{
    static void Main() 
    {
        string[] allCards =
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
        };
        string[] cardsuits =
        {
            "♠", "♥", "♣", "♦"
        };
        for (int i = 0; i < allCards.Length; i++)
        {
            for (int j = 0; j < cardsuits.Length; j++)
            {
                Console.WriteLine(allCards[i] + cardsuits[j]);
            }
        }
    }
}

