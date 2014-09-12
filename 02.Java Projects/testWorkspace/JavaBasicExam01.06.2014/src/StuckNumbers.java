import java.util.Scanner;

public class StuckNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int n = input.nextInt();
		int[] digits = new int[n];
		input.nextLine();
		boolean no = true;
		for (int i = 0; i < n; i++) {
			digits[i] = input.nextInt();
		}

		for (int a = 0; a < digits.length; a++) {
			for (int b = 0; b < digits.length; b++) {
				for (int c = 0; c < digits.length; c++) {
					for (int d = 0; d < digits.length; d++) {
						int num1 = digits[a];
						int num2 = digits[b];
						int num3 = digits[c];
						int num4 = digits[d];

						if (num1 != num2 && num1 != num3 && num1 != num4
								&& num2 != num3 && num2 != num4 && num3 != num4) {
							String rightNum = "" + num1 + num2;
							String leftNum = "" + num3 + num4;
							if (rightNum.equals(leftNum)) {
								System.out.printf("%s|%s==%s|%S%n", num1, num2,
										num3, num4);
								no = false;

							}
						}

					}
				}
			}
		}
		if (no) {
			System.out.println("No");
		}
	}

}
