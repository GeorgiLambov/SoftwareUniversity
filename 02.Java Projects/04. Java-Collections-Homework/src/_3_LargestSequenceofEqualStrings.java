import java.util.Scanner;

/*
 * Write a program that enters an array of strings and finds in it the largest sequence of equal elements. If several sequences have 
 * the same longest length, print the leftmost of them. The input strings are given as a single line, separated by a space.
 */
public class _3_LargestSequenceofEqualStrings {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String line = input.nextLine();
		String[] arrayWords = line.split(" ");
		int wordCount = 0;
		int maxSequence = 0;
		int index = 0;

		for (int i = 0; i < arrayWords.length; i++) {
			wordCount = 0;
			int j = i;
			while (arrayWords[i].equals(arrayWords[j])) {
				wordCount++;
				j++;
				if (j >= arrayWords.length) {
					break;
				}
			}
			if (wordCount > maxSequence) {
				maxSequence = wordCount;
				index = i;
			}
		}
		for (int i = index; i <= index + maxSequence - 1; i++) {
			if (i != index + maxSequence - 1) {
				System.out.print(arrayWords[i] + " ");
			} else {
				System.out.println(arrayWords[i]);
			}

		}

	}
}