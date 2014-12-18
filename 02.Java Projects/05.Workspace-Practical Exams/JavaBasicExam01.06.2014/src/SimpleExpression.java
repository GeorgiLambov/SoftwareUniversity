import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;

public class SimpleExpression {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		Scanner input = new Scanner(System.in);
		String inLine = input.nextLine();
		String[] digis = inLine.trim().split("[ +-]+");
		String[] plusMinus = inLine.trim().split("[ .0-9]+");
		BigDecimal result = new BigDecimal("0");
		boolean isMinus = false;
		for (int i = 0; i < digis.length; i++) {
			BigDecimal num = new BigDecimal(digis[i]);
			String arithmethicExpression = plusMinus[i];
			if (arithmethicExpression.equals("-")) {
				isMinus = true;
			}
			if (isMinus) {
				result = result.subtract(num);
				isMinus = false;
			} else {
				result = result.add(num);
			}

		}

		System.out.printf("%.7f%n", result);
	}

}
