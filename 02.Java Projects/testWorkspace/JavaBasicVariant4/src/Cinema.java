import java.util.Scanner;

public class Cinema {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String moviesProjected = input.nextLine();
		double rows = input.nextDouble();
		double columns = input.nextDouble();

		double incomes = columns * rows;
		if (moviesProjected.equals("Premiere")) {
			incomes = 12 * incomes;
		} else if (moviesProjected.equals("Normal")) {
			incomes = 7.50 * incomes;
		} else {
			incomes = incomes * 5;
		}
		System.out.printf("%.2f leva", incomes);

	}
}
