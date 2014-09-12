import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;
import java.text.DecimalFormat;

public class ThreeLargestNumbers {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		BigDecimal[] arr = new BigDecimal[n];
		
		// input.nextLine();
		for (int i = 0; i < n; i++) {

			arr[i] = input.nextBigDecimal();
		}
		Arrays.sort(arr);
		if (arr.length < 3) {
			for (int i = 0; i < arr.length; i++) {
				System.out.println(arr[arr.length - 1 - i]);
			}
		} else {
			DecimalFormat df = new DecimalFormat();
			df.setMaximumFractionDigits(100);
			//df.setMinimumFractionDigits(0);
			for (int i = 0; i < 3; i++) {
				String numString = df.format(arr[arr.length - 1 - i]);
				System.out.println(numString);
			}
		}
	}

}
