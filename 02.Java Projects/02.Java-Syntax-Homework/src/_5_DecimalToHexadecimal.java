import java.util.Scanner;

//Write a program that enters a positive integer number num and converts and prints it in hexadecimal form. 
//You may use some built-in method from the standard Java libraries. 
public class _5_DecimalToHexadecimal {
	public static void main(String[] args) {

		Scanner input = new Scanner(System.in);

		int num = input.nextInt();

		String hex = Integer.toHexString(num).toUpperCase();

		System.out.println(hex);

	}
}
