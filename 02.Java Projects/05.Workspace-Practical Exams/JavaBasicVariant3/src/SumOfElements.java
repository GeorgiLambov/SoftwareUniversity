import java.util.Scanner;

public class SumOfElements {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		String inputString = in.nextLine();
		String[] digits = inputString.split("[ ,.]");
		
		long sum = 0;
		int maxElement = Integer.MIN_VALUE;
		for (int i = 0; i < digits.length; i++) {
			int element = Integer.valueOf(digits[i]);
			
			if (element > maxElement) {
				maxElement = element;
			}
			sum += element;
		}
	if (sum == 2*maxElement) {
		System.out.printf("Yes, sum=%d", maxElement);
	}	
	else {
		sum = sum - maxElement;
		System.out.printf("No, diff=%d", Math.abs(maxElement - sum));
	}
	
	}		
}
