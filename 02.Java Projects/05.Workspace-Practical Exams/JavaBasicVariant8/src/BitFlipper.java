import java.util.Scanner;

public class BitFlipper {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		long number = input.nextLong();

		int counterBits = 61;

		while (counterBits > 1) {

			long last3Bits = (number >> counterBits) & 7;

			if (last3Bits == 7 || last3Bits == 0) {
				number = number ^ ((long) 7 << counterBits);
				counterBits -= 2;
			}
			counterBits--;

		}
		System.out.println(number);
	}

}
