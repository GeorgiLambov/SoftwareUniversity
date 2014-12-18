import java.util.Scanner;

/*Write a program to generate and print all 3-letter words consisting of given set of characters. For example if we have the characters 'a' and 'b', 
 *all possible words will be "aaa", "aab", "aba", "abb", "baa", "bab", "bba" and "bbb". The input characters are given as string at the first line
 *of the input. Input characters are unique (there are no repeating characters). 
 */
public class _2_Generate_3_LetterWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String inputLine = input.nextLine();
		char[] letters = inputLine.toCharArray();

		for (int i = 0; i < letters.length; i++) {
			for (int j = 0; j < letters.length; j++) {
				for (int d = 0; d < letters.length; d++) {
					String wordString = "" + letters[i] + letters[j]
							+ letters[d];
					System.out.print(wordString + " ");
				}

			}

		}
	}
}
