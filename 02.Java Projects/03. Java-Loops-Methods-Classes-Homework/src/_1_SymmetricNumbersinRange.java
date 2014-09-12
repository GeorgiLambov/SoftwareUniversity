import java.util.Scanner;

//Write a program to generate and print all symmetric numbers in given range [start�end]. A number is symmetric if its digits are symmetric toward its middle. 
//For example, the numbers 101, 33, 989 and 5 are symmetric, but 102, 34 and 997 are not symmetric.

public class _1_SymmetricNumbersinRange {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int start = input.nextInt();
		int end = input.nextInt();

		for (int num = start; num <= end; num++) {
			if (isSymetric(num)) {
				System.out.print(num + " ");
			}
		}
	}

	private static boolean isSymetric(int num) {
		boolean symetric = true;
		char[] digits = Integer.toString(num).toCharArray();

		for (int i = 0, j = 1; i < digits.length; i++, j++) {
			if (digits[i] != digits[digits.length - j]) {
				symetric = false;
			}
		}

		return symetric;
	}
}
