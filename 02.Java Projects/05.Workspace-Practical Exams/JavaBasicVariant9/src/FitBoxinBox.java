import java.util.Scanner;

public class FitBoxinBox {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int w1 = input.nextInt();
		int h1 = input.nextInt();
		int d1 = input.nextInt();
		int w2 = input.nextInt();
		int h2 = input.nextInt();
		int d2 = input.nextInt();

		if (w1 < w2 && h1 < h2 && d1 < d2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w1, h1, d1, w2,
					h2, d2);
		}
		if (w1 < w2 && h1 < d2 && d1 < h2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w1, h1, d1, w2,
					d2, h2);
		}
		if (w1 < h2 && h1 < w2 && d1 < d2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w1, h1, d1, h2,
					w2, d2);
		}
		if (w1 < h2 && h1 < d2 && d1 < w2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w1, h1, d1, h2,
					d2, w2);
		}
		if (w1 < d2 && h1 < w2 && d1 < h2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w1, h1, d1, d2,
					w2, h2);
		}
		if (w1 < d2 && h1 < h2 && d1 < w2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w1, h1, d1, d2,
					h2, w2);
		}

		if (w1 > w2 && h1 > h2 && d1 > d2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w2, h2, d2, w1,
					h1, d1);
		}
		if (w1 > w2 && h1 > d2 && d1 > h2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w2, h2, d2, w1,
					d1, h1);
		}
		if (w1 > h2 && h1 > w2 && d1 > d2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w2, h2, d2, h1,
					w1, d1);
		}
		if (w1 > h2 && h1 > d2 && d1 > w2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w2, h2, d2, h1,
					d1, w1);
		}
		if (w1 > d2 && h1 > w2 && d1 > h2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w2, h2, d2, h1,
					d1, w1);
		}
		if (w1 > d2 && h1 > h2 && d1 > w2) {
			System.out.printf("(%d, %d, %d) < (%d, %d, %d)\n", w2, h2, d2, d1,
					h1, w1);
		}

	}

}
