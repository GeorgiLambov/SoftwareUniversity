import java.util.Scanner;

import javax.security.auth.x500.X500Principal;

//Write a program to check whether a point is inside or outside of the figure below. The point is given as a pair of floating-point numbers, separated by a space. Your program should print "Inside" or "Outside". 
public class _3_PointsInsideFigure {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		String inputLine = in.nextLine();
		String[] digits = inputLine.split("[ ]");

		double aX = Double.parseDouble(digits[0]);
		double aY = Double.parseDouble(digits[1]);

		if (aX >= 12.5 && aX <= 22.5 && aY <= 13.5 && aY >= 6) {
			if (aX > 17.5 && aX < 20 && aY > 8.5) {
				System.out.println("Outside");

			} else {
				System.out.println("Inside");
			}

		} else {
			System.out.println("Outside");
		}
	}

}
