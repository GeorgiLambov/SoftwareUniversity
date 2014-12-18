import java.util.Scanner;

public class WorkHours {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		double projecthours = in.nextDouble();
		double days = in.nextDouble();
		double productivity = in.nextDouble();

		days = days - days / 10;
		double workHours = (int) ((days * 12) * productivity / 100);

		if (workHours >= projecthours) {
			System.out.println("Yes");
			System.out.println((int) (workHours - projecthours));
		} else {
			System.out.println("No");
			System.out.println((int) (workHours - projecthours));
		}
	}

}
