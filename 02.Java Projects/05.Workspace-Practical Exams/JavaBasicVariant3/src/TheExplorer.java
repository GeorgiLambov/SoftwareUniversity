import java.util.Scanner;


public class TheExplorer {

	public static void main(String[] args) {
		
		Scanner input = new Scanner(System.in);
		
		int num = input.nextInt();
		
		PrintTopBoton('-', '*' , num);
		
		PrintLineMidlle(num);
		
		PrintTopBoton('-', '*' , num);
		
	}

	private static void PrintTopBoton(char c, char d, int num) {
		
		for (int j = 0; j < num/2; j++) {
			System.out.print(c);
		}
		System.out.print(d);
		for (int j = 0; j < num/2; j++) {
			System.out.print(c);
		}
		System.out.println("");
		
	}

	private static void PrintLineMidlle(int num) {
		int count = num/2 -1;
		int countIn = 1;
		
		for (int j = 1; j <= num - 2; j++) {
			String dash = new String(new char[count]).replace("\0", "-");
			String dashIn = new String(new char[countIn]).replace("\0", "-");
			System.out.println(dash + "*" + dashIn + "*" + dash );
			if (j < num/2) {
				count --;
				countIn +=2;
			}
			else {
				count ++;
				countIn -=2;
			}
		
		}
	}

	
}
