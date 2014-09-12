import java.util.Scanner;

/*
 * Write a program to count the number of words in given sentence. Use any non-letter character as word separator.
 */
public class _5_CountAllWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String inputLine = input.nextLine();
		String[] inputText = inputLine.split("\\W+");
		int numberOfWords = 0;
		numberOfWords = inputText.length;
		System.out.println(numberOfWords);
	}

}
