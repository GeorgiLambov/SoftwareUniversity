import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;

public class MagicDates {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		LocalDate start = LocalDate.of(input.nextInt(), 1, 1);
		LocalDate end = LocalDate.of(input.nextInt() + 1, 1, 1);
		int target = input.nextInt();
		boolean no = true;
		for (LocalDate i = start; i.isBefore(end); i = i.plusDays(1)) {
			int i1 = i.getDayOfMonth() / 10;
			int i2 = i.getDayOfMonth() % 10;
			int i3 = i.getMonthValue() / 10;
			int i4 = i.getMonthValue() % 10;
			int i5 = i.getYear() / 1000;
			int i6 = (i.getYear() / 100) % 10;
			int i7 = (i.getYear() / 10) % 10;
			int i8 = i.getYear() % 10;
			int sum = i1 * (i2 + i3 + i4 + i5 + i6 + i7 + i8) + i2
					* (i3 + i4 + i5 + i6 + i7 + i8) + i3
					* (i4 + i5 + i6 + i7 + i8) + i4 * (i5 + i6 + i7 + i8) + i5
					* (i6 + i7 + i8) + i6 * (i7 + i8) + i7 * i8;
			if (sum == target) {
				System.out.println(i.format(DateTimeFormatter
						.ofPattern("dd-MM-yyyy")));
				no = false;
			}
		}
		if (no) {
			System.out.println("No");
		}
	}

}
