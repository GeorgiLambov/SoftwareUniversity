import java.util.Scanner;

import javax.swing.text.StyleContext.SmallAttributeSet;

//Write a program that finds the smallest of three numbers
public class _4_TheSmallestOf3Numbers {

	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);

		double a = input.nextDouble();
		double b = input.nextDouble();
		double c = input.nextDouble();

		double smallest = findSmallesNumber(a, b, c);

		System.out.printf("The smallest of three numbers is %.2f%n", smallest);
	}

	private static double findSmallesNumber(double a, double b, double c) {

		double smallesNum = a;
		if (b <= smallesNum) {
			smallesNum = b;
		}
		if (smallesNum >= c) {
			smallesNum = c;
		}

		return smallesNum;
	}

}
