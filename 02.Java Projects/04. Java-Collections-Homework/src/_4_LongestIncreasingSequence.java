import java.util.Scanner;

/*Write a program to find all increasing sequences inside an array of integers. The integers are given in a single line,separated by a space
 * Print the sequences in the order of their appearance in the input array, each at a single line. Separate the sequence elements by 
 * a space. Find also the longest increasing sequence and print it at the last line. If several sequences have the same longest length,
 *  print the leftmost of them. 
 */
public class _4_LongestIncreasingSequence {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String inputLine = input.nextLine();
		String[] line = inputLine.split(" ");
		int[] numbers = new int[line.length];

		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = Integer.parseInt(line[i]);
		}
		int maxSequence = 1;
		int counter = 1;
		int index = 0;
		System.out.print(numbers[0]);
		for (int i = 1; i < numbers.length; i++) {
			if (numbers[i - 1] < numbers[i]) {
				System.out.print(" " + numbers[i]);
				counter++;
			} else {
				System.out.println();
				System.out.print(numbers[i]);
				counter = 1;
			}
			if (counter > maxSequence) {
				maxSequence = counter;
				index = i;
			}
		}
		System.out.println();
		System.out.print("Longest:");
		for (int i = index - maxSequence + 1; i <= index; i++) {
			System.out.print(" " + numbers[i]);
		}
	}
}
