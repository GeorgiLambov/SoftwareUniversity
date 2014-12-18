import java.util.Scanner;

public class NewHouse {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int n = input.nextInt();
		printTop(n);
		printBottom(n);

	}

	private static void printBottom(int n) {
		String asteriks = new String(new char[n - 2]).replace("\0", "*");
		for (int i = 0; i < n; i++) {
			System.out.println("|" + asteriks + "|");
		}

	}

	private static void printTop(int n) {
		int dashCount = n / 2;
		int asteksCount = 1;

		for (int i = 0; i <= n / 2; i++) {
			String dash = new String(new char[dashCount]).replace("\0", "-");
			String asteriks = new String(new char[asteksCount]).replace("\0",
					"*");
			System.out.println(dash + asteriks + dash);
			dashCount--;
			asteksCount += 2;
		}
	}
}
