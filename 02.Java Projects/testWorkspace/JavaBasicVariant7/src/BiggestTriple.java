import java.util.Scanner;

public class BiggestTriple {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String inputLine = input.nextLine();
		String[] numbers = inputLine.split("[ ,.]+");
		int[] digits = new int[numbers.length];

		for (int i = 0; i < numbers.length; i++) {
			digits[i] = Integer.parseInt(numbers[i]);
		}
		int maxSum = Integer.MIN_VALUE;
		int startIndex = 0;
		int index = 0;
		int bestLen = 0;

		while (index < digits.length) {
			int num1 = digits[index];
			int len = 1;
			int num2 = 0;
			if (index + 1 < digits.length) {
				num2 = digits[index + 1];
				len = 2;
			}
			int num3 = 0;
			if (index + 2 < digits.length) {
				num3 = digits[index + 2];
				len = 3;
			}
			int sum = num1 + num2 + num3;
			if (sum > maxSum) {
				maxSum = sum;
				startIndex = index;
				bestLen = len;
			}
			index += 3;
		}
		for (int i = 0; i < bestLen; i++) {
			System.out.print(digits[startIndex]);
			startIndex++;
			if (i < bestLen - 1) {
				System.out.print(' ');
			}
		}
	}
}
