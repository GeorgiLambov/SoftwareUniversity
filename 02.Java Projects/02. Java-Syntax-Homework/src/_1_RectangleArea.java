import java.util.Scanner;

//Write a program that enters the sides of a rectangle (two integers a and b) and calculates and prints the rectangle's area.
public class _1_RectangleArea {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);
		System.out.print("Enter side A = ");
		int sideA = input.nextInt();
		System.out.print("Enter side B = ");
		int sideB = input.nextInt();
		int rectangleArea = sideA * sideB;
		System.out.printf("The rectangle's area = %d\n", rectangleArea);

	}

}
