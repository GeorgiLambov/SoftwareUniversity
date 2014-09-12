import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

/* * We are given a sequence of N playing cards from a standard deck. The input consists of several cards (face + suit), separated by 
 * a space. Write a program to calculate and print at the console the frequency of each card face in format "card_face -> frequency". 
 * The frequency is calculated by the formula appearances / N and is expressed in percentages with exactly 2 digits after the decimal
 *  point. The card faces with their frequency should be printed in the order of the card face's first appearance in the input. The 
 *  same card can appear multiple times in the input, but it's face should be listed only once in the output.  */
public class _12_CardsFrequencies {

	public static void main(String[] args) {
		try (Scanner scanner = new Scanner(System.in)) {
			String[] cards = scanner.nextLine().split("[♥♣♦♠ ]+");
			int N = cards.length;
			// use linked hash map to preserve initial order of elements
			Map<String, Integer> cardOccurrences = new LinkedHashMap<String, Integer>();

			for (String card : cards) {
				Integer count = cardOccurrences.get(card);
				if (count == null)
					count = 0;
				cardOccurrences.put(card, count + 1);
			}

			// print
			for (Map.Entry<String, Integer> entry : cardOccurrences.entrySet()) {
				System.out.printf("%s -> %.2f%%\n", entry.getKey(),
						(double) entry.getValue() * 100 / N);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
