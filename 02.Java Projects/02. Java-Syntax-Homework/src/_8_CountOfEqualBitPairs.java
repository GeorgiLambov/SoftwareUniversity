import java.util.Scanner;

//*Write a program to count how many sequences of two equal bits ("00" or "11") 
//can be found in the binary representation of given integer number n (with overlapping). 

public class _8_CountOfEqualBitPairs {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.print("num = ");
		int num = input.nextInt();
		int countEqualBitPairs = 0;
		while (num > 0) {

			int bit1 = (num & 1);
			int bit2 = (num & 2) >> 1;

			if (bit1 == bit2) {
				countEqualBitPairs++;
			}
			num = num >> 1;
		}
		System.out.println(countEqualBitPairs);
	}

}
