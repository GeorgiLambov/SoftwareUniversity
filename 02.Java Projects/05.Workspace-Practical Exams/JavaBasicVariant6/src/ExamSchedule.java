import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;

public class ExamSchedule {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		LocalTime time = LocalTime.of(input.nextInt(), input.nextInt());
		if (input.next().equals("PM")) {
			time = time.plusHours(12);
		}
		time = time.plusHours(input.nextInt());
		time = time.plusMinutes(input.nextInt());
		System.out.println(time.format(DateTimeFormatter.ofPattern("hh:mm:a")));
	}

}
