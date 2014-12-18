import java.util.Scanner;

/*
 * Write a method to convert from degrees to radians. Write a method to convert from radians to degrees. You are given a number n and n queries for conversion. 
 * Each conversion query will consist of a number + space + measure. Measures are "deg" and "rad". Convert all radians to degrees and all degrees to radians.
 *  Print the results as n lines, each holding a number + space + measure. Format all numbers with 6 digit after the decimal point
 */
public class _5_AngleUnitConverter_Degrees_Radians {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();

		for (int i = 0; i < n; i++) {
			double queries = input.nextDouble();
			String measure = input.nextLine();

			if (measure.equals(" deg")) {
				convertFromDegreestoRadians(queries);
			} else {
				convertFromRadiansToDegrees(queries);
			}

		}
	}

	private static void convertFromRadiansToDegrees(double queries) {
		// double degrees = queries * (180.0d / (double) Math.PI);
		double degrees = Math.toDegrees(queries);
		System.out.printf("%.6f deg\n", degrees);

	}

	private static void convertFromDegreestoRadians(Double queries) {
		// double radians = (queries * (double) Math.PI) / 180.0d;
		double radians = Math.toRadians(queries);
		System.out.printf("%.6f rad\n", radians);

	}

}
