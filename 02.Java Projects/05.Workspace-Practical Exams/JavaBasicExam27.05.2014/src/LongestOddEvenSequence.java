import java.util.Scanner;

public class LongestOddEvenSequence {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String[] inline = input.nextLine().split("[^0-9]+");

		int[] numbers = new int[inline.length - 1];
		for (int i = 1; i < inline.length; i++) {
			numbers[i - 1] = Integer.parseInt(inline[i]);
		}
		int counter = 1;
		int maxCount = 1;
	
		for (int i = 1; i < numbers.length; i++) {
			if (numbers[i] % 2 != numbers[i - 1] % 2) {
				counter++;

				if (counter > maxCount) {
					maxCount = counter;
				}
			} else {
				counter = 1;
			}

		}
		System.out.println(maxCount);

	}
}
