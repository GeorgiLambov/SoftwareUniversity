import java.util.Scanner;

public class InsideTheBuilding {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);

		int h = input.nextInt();

		double startTime = System.currentTimeMillis();

		for (int i = 1; i <= 5; i++) {
			int x = input.nextInt();
			int y = input.nextInt();
			boolean isInBilding = isInBuilding(x, y, h);
			if (isInBilding) {
				System.out.println("inside");
			} else {
				System.out.println("outside");
			}
		}

		double stopTime = System.currentTimeMillis();
		double elapsedTime = stopTime - startTime;
		// System.out.println(elapsedTime/1000);
	}

	private static boolean isInBuilding(int x, int y, int h) {

		if ((x >= 0 && x <= 3 * h && y <= h && y >= 0)
				|| (x >= h && x <= 2 * h && y >= 0 && y <= 4 * h)) {
			return true;
		}

		return false;
	}

}
