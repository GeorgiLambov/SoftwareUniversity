import java.util.Scanner;

public class CountBeers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int stacksSum = 0;
		int beerSum = 0;

		do {
			String line = input.nextLine();
			String[] nums = line.split("[\\D]");
			String[] measure = line.split("[\\d\\s]+");
			if (measure[0].equals("End")) {
				break;
			}
			int num = Integer.parseInt(nums[0]);
			if (measure[1].equals("stacks")) {
				stacksSum += num;
			} else {
				beerSum += num;
			}

		} while (true);
		if (beerSum >= 20) {
			stacksSum += beerSum / 20;
			beerSum = beerSum % 20;
		}

		System.out.printf("%d stacks + %d beers", stacksSum, beerSum);

	}

}
