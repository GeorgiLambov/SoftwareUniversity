import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.Scanner;

/*
 * Write a program to calculate the difference between two dates in number of days. The dates are entered
 *  at two consecutive lines in format day-month-year. Days are in range [1…31]. 
 *  Months are in range [1…12]. Years are in range [1900…2100]. 
 */
public class _7_DaysbetweenTwoDates {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String beginDate = input.nextLine();
		String endDate = input.nextLine();

		LocalDate start = LocalDate.parse(beginDate,
				DateTimeFormatter.ofPattern("d-MM-uuuu"));
		LocalDate end = LocalDate.parse(endDate,
				DateTimeFormatter.ofPattern("d-MM-uuuu"));
		long result = ChronoUnit.DAYS.between(start, end);
		System.out.println(result);

	}

}
