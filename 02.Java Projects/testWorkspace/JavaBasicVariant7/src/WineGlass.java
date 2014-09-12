import java.util.Scanner;


public class WineGlass {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		int num =input.nextInt();
		
		printTop(num);
		printSeat(num);
	}

	private static void printSeat(int num) {
		int count = num/2 -1;
		if (num < 12) {
			
		for (int i = 1; i < num/2; i++) {
			String outDots = new String(new char[count]).replace("\0", ".");
			System.out.println(outDots + "||"+ outDots);
		}
		
		}
		else {
			for (int i = 2; i < num/2; i++) {
				String outDots = new String(new char[count]).replace("\0", ".");
				System.out.println(outDots + "||"+ outDots);
			}
			String dashes  = new String(new char[num]).replace("\0", "-");
			System.out.println(dashes);
		}
		String dashes  = new String(new char[num]).replace("\0", "-");
		System.out.println(dashes);
		
	}

	private static void printTop(int num) {
		int count= num - 2;
	
		
		for (int i = 0; i < num/2; i++) {
			String asteriks = new String(new char[count]).replace("\0", "*");
			String outDots = new String(new char[i]).replace("\0", ".");
			System.out.println(outDots + "\\" + asteriks + "/" + outDots);
			count-=2;
		}
		
	}

}
