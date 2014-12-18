import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;

public class OddEvenElements {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		String[] numbers = new Scanner(System.in).nextLine().split(" ");
		if (numbers[0].equals("")) {
			System.out
					.println("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
		} else if (numbers.length == 1) {
			DecimalFormat dFormat = new DecimalFormat("#.##############");
			System.out
					.printf("OddSum=%s, OddMin=%s, OddMax=&s, EvenSum=No, EvenMin=No, EvenMax=No",
							dFormat.format(Double.parseDouble(numbers[0])),
							dFormat.format(Double.parseDouble(numbers[0])),
							dFormat.format(Double.parseDouble(numbers[0])));
		} else {
			BigDecimal oddSum = new BigDecimal("0"), evenSum = new BigDecimal(
					"0");
			double oddMin = Integer.MAX_VALUE, oddMax = Integer.MIN_VALUE;
			double evenMin = Integer.MAX_VALUE, evenMax = Integer.MIN_VALUE;

			for (int i = 0; i < numbers.length; i++) {
				double num = Double.parseDouble(numbers[i]);
				if (i % 2 == 0) {
					oddSum = oddSum.add(BigDecimal.valueOf(num));
					oddMax = Math.max(num, oddMax);
					oddMin = Math.min(num, oddMin);
				} else {
					evenSum = evenSum.add(BigDecimal.valueOf(num));
					evenMax = Math.max(num, evenMax);
					evenMin = Math.min(num, evenMin);
				}
			}
			DecimalFormat df = new DecimalFormat("#.##############");
			System.out
					.printf("OddSum=%s, OddMin=%s, OddMax=%s, EvenSum=%s, EvenMin=%s EvenMax=%s",
							df.format(oddSum), df.format(oddMin),
							df.format(oddMax), df.format(evenSum),
							df.format(evenMin), df.format(evenMax));
		}
	}
}
