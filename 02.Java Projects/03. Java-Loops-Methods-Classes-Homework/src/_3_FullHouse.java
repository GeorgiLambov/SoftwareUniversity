/*
 * In most Poker games, the "full house" hand is defined as three cards of the same face + two cards of the same face, other than the first,
 *  regardless of the card's suits. The cards faces are "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" and "A". The card suits
 *   are "♣", "♦", "♥" and "♠". Write a program to generate and print all full houses and print their number.
 */
public class _3_FullHouse {

	public static void main(String[] args) {

		String[] allCards = { "2", "3", "4", "5", "6", "7", "8", "9", "10",
				"J", "Q", "K", "A" };
		String[] cardsuits = { "♠", "♥", "♣", "♦" };
		int counterFullHouse = 0;

		for (int leftTreeCards = 0; leftTreeCards < allCards.length; leftTreeCards++) {
			for (int righteTwoCards = 0; righteTwoCards < allCards.length; righteTwoCards++) {
				for (int s1 = 0; s1 < cardsuits.length; s1++) {
					for (int s2 = s1 + 1; s2 < cardsuits.length; s2++) {
						for (int s3 = s2 + 1; s3 < cardsuits.length; s3++) {
							for (int s4 = 0; s4 < cardsuits.length; s4++) {
								for (int s5 = s4 + 1; s5 < cardsuits.length; s5++) {
									if (leftTreeCards != righteTwoCards) {
										System.out.printf(
												"(%s%s %s%s %s%s %s%s %s%s) ",
												allCards[leftTreeCards],
												cardsuits[s1],
												allCards[leftTreeCards],
												cardsuits[s2],
												allCards[leftTreeCards],
												cardsuits[s3],
												allCards[righteTwoCards],
												cardsuits[s4],
												allCards[righteTwoCards],
												cardsuits[s5]);
										counterFullHouse++;
									}
								}
							}
						}

					}

				}

			}

		}
		System.out.println();
		System.out.printf("All full houses = %d", counterFullHouse);
	}

}
