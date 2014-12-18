import java.util.Scanner;

//Write a program to calculate the count of bits 1 in the binary representation of given integer number n. 

public class _7_CountOfBitsOne {

	public static void main(String[] args) {

		Scanner inputScanner = new Scanner(System.in);
		System.out.print("n = ");
		int num = inputScanner.nextInt();

		int bits = Integer.bitCount(num);
		System.out.println(bits);
	}

}
