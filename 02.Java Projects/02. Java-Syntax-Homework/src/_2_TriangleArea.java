import java.util.Scanner;

//Write a program that enters 3 points in the plane (as integer x and y coordinates), calculates and prints the area of the triangle
//composed by these 3 points. Round the result to a whole number. In case the three points do not form a triangle, print "0" as result. 
public class _2_TriangleArea {

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		System.out.print("Enter coordinates x and y from point A:");
		int pointAx = in.nextInt();
		int pointAy = in.nextInt();
		System.out.print("Enter coordinates x and y from point B:");
		int pointBx = in.nextInt();
		int pointBy = in.nextInt();
		System.out.print("Enter coordinates x and y from point C:");
		int pointCx = in.nextInt();
		int pointCy = in.nextInt();

		int triangleArea = (pointAx * (pointBy - pointCy) + pointBx
				* (pointCy - pointAy) + pointCx * (pointAy - pointBy)) / 2;

		System.out.printf("The area of the triangle is %d\n",
				Math.abs(triangleArea));
	}

}
