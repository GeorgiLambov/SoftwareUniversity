import java.util.ArrayList;
import java.util.Scanner;

/* * Write a program that reads two lists of letters l1 and l2 and combines them: appends all letters c from l2 to the end of l1, 
 * but only when c does not appear in l1. Print the obtained combined list. All lists are given as sequence of letters separated by a 
 * single space, each at a separate line. Use ArrayList<Character> of chars to keep the input and output lists.  */
public class _9_CombineListsofLetters {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		ArrayList<Character> firstLine = new ArrayList<>();
		ArrayList<Character> result = new ArrayList<>();

		for (Character ch : input.nextLine().replaceAll("\\s+", "")
				.toCharArray()) {
			firstLine.add(ch);
		}
		result.addAll(firstLine);

		for (Character ch : input.nextLine().replaceAll("\\s+", "")
				.toCharArray()) {
			if (!firstLine.contains(ch)) {
				result.add(ch);
			}
		}
		for (Character ch : result) {
			System.out.print(ch + " ");
		}

	}

}
