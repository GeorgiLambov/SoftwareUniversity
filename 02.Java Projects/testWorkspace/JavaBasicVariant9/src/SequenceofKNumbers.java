import java.util.Scanner;

public class SequenceofKNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String sequenceIntegers = input.nextLine();
		int k = input.nextInt();

		sequenceIntegers = sequenceIntegers + " " + Integer.MAX_VALUE;
		String[] inLineStrings = sequenceIntegers.split(" ");
		int[] numbers = new int[inLineStrings.length];
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = Integer.parseInt(inLineStrings[i]);
		}
		int num = numbers[0];
		int counter = 1;
		for (int i = 1; i < numbers.length; i++) {
			int secNum = numbers[i];
			if (num == secNum) {
				counter++;
			} else {
				for (int z = 0; z < counter % k; z++) {
					System.out.print(num + " ");
				}

				counter = 1;
			}
			num = secNum;
		}

	}
}
