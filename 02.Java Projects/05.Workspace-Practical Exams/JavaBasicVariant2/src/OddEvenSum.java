import java.util.Scanner;


public class OddEvenSum {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		int n = in.nextInt();
		int sumOdd = 0;
		int sumEven = 0;
		for (int i = 1; i <= 2*n; i++) {
			int element = in.nextInt();
			
			if (i % 2 == 1) {
				sumOdd += element;
			}
			else {
				sumEven += element;
			}
		}
		if (sumEven == sumOdd) {
			System.out.printf("Yes, sum=%d", sumEven);
		}
		else {
			System.out.printf("No, diff=%d", Math.abs(sumEven - sumOdd));
		}

	}

}
