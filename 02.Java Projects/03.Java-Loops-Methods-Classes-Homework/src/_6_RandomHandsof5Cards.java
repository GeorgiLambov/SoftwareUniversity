import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

/*
 * Write a program to generate n random hands of 5 different cards form a standard suit of 52 cards. 
 */
public class _6_RandomHandsof5Cards {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		ArrayList<String> cardList = createDeck();

		for (int i = 0; i < n; i++) {
			String[] handStrings = randomHand(cardList);
			for (String card : handStrings) {
				System.out.print(card + " ");
			}
			System.out.println();
		}

	}

	private static String[] randomHand(ArrayList<String> cardList) {
		Random rnd = new Random();
		String[] hand = new String[5];
		for (int i = 0; i < hand.length; i++) {
			int index = rnd.nextInt(cardList.size());
			hand[i] = cardList.remove(index);
		}
		return hand;
	}

	private static ArrayList<String> createDeck() {
		String[] allCards = { "2", "3", "4", "5", "6", "7", "8", "9", "10",
				"J", "Q", "K", "A" };
		char[] cardsuits = { '♠', '♥', '♣', '♦' };

		ArrayList<String> cardslist = new ArrayList<>();
		String[] cards = new String[52];
		int x = 0;
		for (int i = 0; i < allCards.length; i++) {
			for (int j = 0; j < cardsuits.length; j++) {
				cards[x] = (allCards[i] + cardsuits[j]);
				cardslist.add(cards[x]);
				x++;
			}

		}
		return cardslist;
	}
}
