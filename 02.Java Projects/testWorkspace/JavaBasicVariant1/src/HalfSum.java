import java.util.Scanner;

public class HalfSum {

	public static void main(String[] args) {
		
		Scanner in = new Scanner(System.in);
		
		int n = in.nextInt();
		int firstSum = 0;
		int secSum = 0;
		
		for (int i = 0; i < n; i++) {
			firstSum += in.nextInt();
		}
		for (int i = 0; i < n; i++) {
			secSum += in.nextInt();
		}
		in.close();
		if (firstSum == secSum) {
			System.out.println("Yes, sum=" + firstSum);
		}
		else {
			System.out.println("No, diff=" + Math.abs(firstSum - secSum));
		}
	}
}
