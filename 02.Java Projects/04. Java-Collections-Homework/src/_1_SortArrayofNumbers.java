import java.util.Arrays;
import java.util.Scanner;

/*
 * Write a program to enter a number n and n integer numbers and sort and print them. Keep the numbers in array of integers: int[].
 */
public class _1_SortArrayofNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int num = input.nextInt();
		int[] numbers = new int[num];
		for (int i = 0; i < num; i++) {
			numbers[i] = input.nextInt();
		}
		Arrays.sort(numbers);
		for (int i = 0; i < numbers.length; i++) {
			System.out.print(numbers[i] + " ");
		}
	}
}
