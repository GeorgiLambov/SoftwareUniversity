import java.util.Scanner;

//**Write a program to check whether a point is inside or outside the house below. The point is given as a pair of floating-point numbers,
//separated by a space. Your program should print "Inside" or "Outside". 

public class _9_PointsInsideTheHouse {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);
		String[] points = input.nextLine().split(" ");

		double pointX = Double.parseDouble(points[0]);
		double pointY = Double.parseDouble(points[1]);

		if (isInTriangle(pointX, pointY) || isInRectangleMain(pointX, pointY)
				|| isInRectangleSecond(pointX, pointY)) {
			System.out.println("Inside");
		} else {
			System.out.println("Outside");
		}
	}

	private static boolean isInRectangleSecond(double x, double y) {
		if (x >= 20 && x <= 22.5 && y >= 8.5 && y <= 13.5) {
			return true;
		}
		return false;
	}

	private static boolean isInRectangleMain(double x, double y) {
		if (x >= 12.5 && x <= 17.5 && y >= 8.5 && y <= 13.5) {
			return true;
		}
		return false;
	}

	private static boolean isInTriangle(double x, double y) {
		double x1 = 12.5, y1 = 8.5;
		double x2 = 22.5, y2 = 8.5;
		double x3 = 17.5, y3 = 3.5;

		double ABC = Math.abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
		double ABP = Math.abs(x1 * (y2 - y) + x2 * (y - y1) + x * (y1 - y2));
		double APC = Math.abs(x1 * (y - y3) + x * (y3 - y1) + x3 * (y1 - y));
		double PBC = Math.abs(x * (y2 - y3) + x2 * (y3 - y) + x3 * (y - y2));

		boolean isInTriangle = ABP + APC + PBC == ABC;
		return isInTriangle;
	}

}
