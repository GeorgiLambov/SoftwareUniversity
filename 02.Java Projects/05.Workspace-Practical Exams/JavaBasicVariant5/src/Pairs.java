import java.util.Arrays;
import java.util.Scanner;

public class Pairs {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String[] inLine = input.nextLine().split(" ");
		int maxDiff = 0;
		int sum = Integer.parseInt(inLine[0]) + Integer.parseInt(inLine[1]);
		for (int i = 3; i < inLine.length; i += 2) {
			int value = Integer.parseInt(inLine[i])
					+ Integer.parseInt(inLine[i - 1]);
			int diff = Math.abs(sum - value);
			if (diff > maxDiff) {
				maxDiff = diff;
			}
			sum = value;
		}

		if (maxDiff == 0) {
			System.out.printf("Yes, value=%d%n", sum);
		} else {
			System.out.printf("No, maxdiff=%d%n", maxDiff);
		}

	}

}
