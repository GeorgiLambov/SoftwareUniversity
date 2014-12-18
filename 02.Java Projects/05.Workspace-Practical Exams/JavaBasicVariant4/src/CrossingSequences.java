import java.util.ArrayList;
import java.util.Scanner;

public class CrossingSequences {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int tribOne = input.nextInt();
		int triTwo = input.nextInt();
		int tribTri = input.nextInt();

		int initialNum = input.nextInt();
		int step = input.nextInt();

		ArrayList<Integer> tribonaciNumbers = getTribonaci(tribOne, triTwo,
				tribTri);
		ArrayList<Integer> spiralNumbers = getSpiralNums(initialNum, step);

		boolean no = true;
		for (int i = 0; i <= 1000000; i++) {
			if (tribonaciNumbers.contains(i) && spiralNumbers.contains(i)) {
				no = false;
				System.out.println(i);
				break;
			}
		}

		if (no) {
			System.out.println("No");
		}

	}

	private static ArrayList<Integer> getSpiralNums(int initialNum, int step) {
		ArrayList<Integer> spiralNumbers = new ArrayList<>();

		spiralNumbers.add(initialNum);
		int num = 0;
		boolean corner = true;
		while (initialNum <= 1000000) {

			if (corner) {
				num += 1;
			}

			initialNum += num * step;
			spiralNumbers.add(initialNum);
			corner = !corner;
		}

		return spiralNumbers;
	}

	private static ArrayList<Integer> getTribonaci(int tribOne, int triTwo,
			int tribTri) {
		int tribonacci = 0;
		ArrayList<Integer> tribonaciNumbers = new ArrayList<>();
		tribonaciNumbers.add(tribOne);
		tribonaciNumbers.add(triTwo);
		tribonaciNumbers.add(tribTri);

		do {
			tribonacci = tribOne + triTwo + tribTri;
			tribonaciNumbers.add(tribonacci);
			tribOne = triTwo;
			triTwo = tribTri;
			tribTri = tribonacci;

		} while (tribonacci <= 1000000);

		return tribonaciNumbers;
	}

}
