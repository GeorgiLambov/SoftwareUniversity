import java.util.Scanner;

/*
 * Write a program to find how many times a word appears in given text. The text is given at the first input line. The target word is 
 * given at the second input line. The output is an integer number. Please ignore the character casing. Consider that any non-letter 
 * character is a word separator. */

public class _6_CountSpecifiedWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String inputline = input.nextLine().toLowerCase();
		String targetWord = input.nextLine().toLowerCase();
		String[] textWord = inputline.split("\\W+");
		int countOfWord = 0;
		for (int i = 0; i < textWord.length; i++) {
			if (textWord[i].equals(targetWord)) {
				countOfWord++;
			}
		}
		System.out.println(countOfWord);

	}

}
