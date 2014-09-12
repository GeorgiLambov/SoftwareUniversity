import java.util.Scanner;

/*
 * Write a program that enters an array of strings and finds in it all sequences of equal elements. 
 * The input strings are given as a single line, separated by a space. 
 */
public class _2_SequencesofEqualStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String inputLine = input.nextLine();
		String[] arrayWords = inputLine.split(" ");

		System.out.print(arrayWords[0]);
		for (int i = 1; i < arrayWords.length; i++) {
			if (arrayWords[i].equals(arrayWords[i - 1])) {
				System.out.print(" " + arrayWords[i]);
			} else {
				System.out.println();
				System.out.print(arrayWords[i]);
			}
		}
	}
}