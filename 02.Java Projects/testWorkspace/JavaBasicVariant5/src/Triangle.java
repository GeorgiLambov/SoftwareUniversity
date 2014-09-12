import java.util.Scanner;

public class Triangle {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int aX = input.nextInt();
		int aY = input.nextInt();
		int bX = input.nextInt();
		int bY = input.nextInt();
		int cX = input.nextInt();
		int cY = input.nextInt();

		double distanceAB = Math.sqrt((bX - aX) * (bX - aX) + (bY - aY)
				* (bY - aY));
		double distanceBC = Math.sqrt((cX - bX) * (cX - bX) + (cY - bY)
				* (cY - bY));
		double distanceCA = Math.sqrt((aX - cX) * (aX - cX) + (aY - cY)
				* (aY - cY));

		boolean isTriangle = distanceAB + distanceBC > distanceCA
				&& distanceBC + distanceCA > distanceAB
				&& distanceAB + distanceCA > distanceBC;
		if (isTriangle) {
			double perimeter = (distanceAB + distanceBC + distanceCA) / 2;
			double area = Math.sqrt(perimeter * (perimeter - distanceAB)
					* (perimeter - distanceBC) * (perimeter - distanceCA));
			System.out.println("Yes");
			System.out.printf("%.2f%n", area);

		} else {
			System.out.println("No");
			System.out.printf("%.2f%n", Math.abs(distanceAB));
		}
	}

}
