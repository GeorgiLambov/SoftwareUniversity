import java.util.Scanner;

/* * Write a program to find how many times given string appears in given text as substring.The text is given at the first input line.
 *  The search string is given at the second input line. The output is an integer number. Please ignore the character casing. */
public class _7_CountSubstringOccurrences {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String inputLine = input.nextLine().toLowerCase();
		String target = input.nextLine().toLowerCase();
		int index = inputLine.indexOf(target);
		int count = 0;
		while (index != -1) {
			index = inputLine.indexOf(target, index + 1);
			count++;
		}
		System.out.println(count);
	}

}
