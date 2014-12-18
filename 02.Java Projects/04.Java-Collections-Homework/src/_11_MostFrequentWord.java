import java.util.Scanner;
import java.util.TreeMap;

/* * Write a program to find the most frequent word in a text and print it, as well as how many times it appears in format "word -> count". 
 * Consider any non-letter character as a word separator. Ignore the character casing. If several words have the same maximal frequency, print all of them in 
 * alphabetical order.  */
public class _11_MostFrequentWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String wordLine = input.nextLine().toLowerCase();
		String[] words = wordLine.split("\\W+");
		int maxCount = 0;
		TreeMap<String, Integer> wordsMap = new TreeMap<>();

		for (int i = 0; i < words.length; i++) {

			if (!wordsMap.containsKey(words[i])) {
				wordsMap.put(words[i], 1);
			} else {

				wordsMap.put(words[i], wordsMap.get(words[i]) + 1);
				if (wordsMap.get(words[i]) > maxCount) {
					maxCount = wordsMap.get(words[i]);
				}
			}
		}

		for (String key : wordsMap.keySet()) {
			if (wordsMap.get(key) == maxCount) {
				System.out.print(key + " -> " + wordsMap.get(key) + " times");
				System.out.println();
			}
		}
	}

}
