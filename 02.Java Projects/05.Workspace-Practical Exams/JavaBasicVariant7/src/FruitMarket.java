import java.math.BigDecimal;
import java.util.Scanner;

public class FruitMarket {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		BigDecimal result = BigDecimal.ZERO;

		String dayOfWeek = input.nextLine();
		BigDecimal totalSum = BigDecimal.ZERO;

		for (int i = 1; i <= 3; i++) {

			BigDecimal quantity = input.nextBigDecimal();
			input.nextLine();
			String product = input.nextLine();

			switch (product) {
			case "banana":
				result = quantity.multiply(new BigDecimal(1.80));
				break;
			case "cucumber":
				result = quantity.multiply(new BigDecimal(2.75));
				break;
			case "tomato":
				result = quantity.multiply(new BigDecimal(3.20));
				break;
			case "orange":
				result = quantity.multiply(new BigDecimal(1.60));
				break;
			case "apple":
				result = quantity.multiply(new BigDecimal(0.86));
				break;

			default:
				System.out.print("Wrong fruit");
				break;

			}
			if (dayOfWeek.equals("Friday")) {
				result = result.multiply(new BigDecimal(0.90));
			} else if (dayOfWeek.equals("Sunday")) {
				result = result.multiply(new BigDecimal(0.95));
			} else if (dayOfWeek.equals("Tuesday")
					&& ((product.equals("banana"))
							|| (product.equals("orange")) || (product
								.equals("apple")))) {
				result = result.multiply(new BigDecimal(0.80));
			} else if (dayOfWeek.equals("Wednesday")
					&& ((product.equals("tomato")) || (product
							.equals("cucumber")))) {
				result = result.multiply(new BigDecimal(0.90));
			} else if (dayOfWeek.equals("Thursday") && product.equals("banana")) {
				result = result.multiply(new BigDecimal(0.70));
			}
			totalSum = totalSum.add(result);
		}
		System.out.printf("%.2f%n", totalSum);
	}

}
