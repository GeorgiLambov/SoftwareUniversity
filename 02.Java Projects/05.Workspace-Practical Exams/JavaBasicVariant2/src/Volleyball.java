import java.util.Scanner;


public class Volleyball {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		String leap = scan.next();
		int holidays = scan.nextInt();
		int weekendsHometown = scan.nextInt();
		
		double normalWeekends = (48 - weekendsHometown)*3/4d;
		double holidayPlay = holidays* 2/3d;
		double totalPlays = normalWeekends + holidayPlay + weekendsHometown;
		
		if (leap.equals("leap")) {
			totalPlays += totalPlays*15/100d;
		}
		System.out.println((int)totalPlays);
	}

}
