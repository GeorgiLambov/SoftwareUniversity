import java.util.Scanner;

public class MagicCarNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int magicWeight = input.nextInt();
		char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };
		int resultsCount = 0;
		magicWeight = magicWeight - 40;

		for (int a = 0; a < 10; a++) {
			for (int b = 0; b < 10; b++) {
				for (int c = 0; c < 10; c++) {
					for (int d = 0; d < 10; d++) {
						if (isValidDigit(a, b, c, d)) {

							int weightdigits = a + b + c + d;

							for (int x = 0; x < letters.length; x++) {
								for (int y = 0; y < letters.length; y++) {
									String letersXYString = "" + letters[x]
											+ letters[y];
									int weightLetterX = CalcWeight(letersXYString);

									if (magicWeight == weightdigits
											+ weightLetterX) {
										resultsCount++;
									}
								}
							}
						}

					}

				}
			}
		}
		System.out.println(resultsCount);
	}

	private static int CalcWeight(String XYString) {

		int weight = 0;

		for (char ch : XYString.toCharArray()) {
			switch (ch) {
			case 'A':
				weight += 10;
				break;
			case 'B':
				weight += 20;
				break;
			case 'C':
				weight += 30;
				break;
			case 'E':
				weight += 50;
				break;
			case 'H':
				weight += 80;
				break;
			case 'K':
				weight += 110;
				break;
			case 'M':
				weight += 130;
				break;
			case 'P':
				weight += 160;
				break;
			case 'T':
				weight += 200;
				break;
			case 'X':
				weight += 240;
				break;
			}
		}

		return weight;
	}

	private static boolean isValidDigit(int a, int b, int c, int d) {
		if ((a == b && a == c && a == d) || (a != b && b == c && b == d)
				|| (a == b && a == c && a != d) || (a == b && c == d && a != c)
				|| (a == c && b == d && a != d) || (a == d && b == c && a != b)) {
			return true;
		}
		return false;
	}
}
