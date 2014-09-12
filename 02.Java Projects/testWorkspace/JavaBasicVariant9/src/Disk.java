import java.util.Scanner;

public class Disk {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int n = input.nextInt();
		int r = input.nextInt();

		for (int rows = 0; rows < n; rows++) {

			for (int cols = 0; cols < n; cols++) {

				if ((n / 2 - rows) * (n / 2 - rows) + (n / 2 - cols)
						* (n / 2 - cols) <= r * r) {
					System.out.print("*");
				} else {
					System.out.print(".");
				}
			}
			System.out.println();
		}
	}

}
