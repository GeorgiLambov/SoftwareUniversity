import java.util.Scanner;

public class Largest3Rectangles {

	public static void main(String[] args) {
		
		// Parse the rectangles and collect their areas
		Scanner input = new Scanner(System.in);
		String rectangles = input.nextLine();
		rectangles = rectangles.replace("[", "");
		rectangles = rectangles.replace(" ", "");
		String[] rects = rectangles.split("]");
		
		int[] areas = new int[rects.length];
		for (int i = 0; i < rects.length; i++) {
			// Process each rectangle
			String rect = rects[i];
			rect = rect.replace("[", "");
			String[] sides = rect.split("x");
			int firstSide = Integer.parseInt(sides[0]);
			int secondSide = Integer.parseInt(sides[1]);
			areas[i] = firstSide * secondSide;
		}
		
		// Calculate the max sequence of 3 rectangle areas
		int max = Integer.MIN_VALUE;
		for (int i = 2; i < areas.length; i++) {
			int sum = areas[i-2] + areas[i-1] + areas[i];
			if (sum > max) {
				max = sum;
			}
		}
		
		System.out.println(max);		
	}

}
