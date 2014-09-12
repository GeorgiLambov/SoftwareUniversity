import java.util.Scanner;

public class Largest3RectanglesEasy {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String rectangles = input.nextLine();
		String[] rects = rectangles.split("\\D+");

		int max = Integer.MIN_VALUE;
		for (int i = 6; i < rects.length; i+=2) {
			int rect1width = Integer.parseInt(rects[i-5]);
			int rect1height = Integer.parseInt(rects[i-4]);
			int rect2width = Integer.parseInt(rects[i-3]);
			int rect2height = Integer.parseInt(rects[i-2]);
			int rect3width = Integer.parseInt(rects[i-1]);
			int rect3height = Integer.parseInt(rects[i]);
			int sum = rect1width * rect1height + 
				rect2width * rect2height + rect3width * rect3height;
			if (sum > max) {
				max = sum;
			}
		}
		
		System.out.println(max);		
	}

}
