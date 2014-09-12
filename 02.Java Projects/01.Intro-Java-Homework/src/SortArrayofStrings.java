import java.util.Arrays;
import java.util.Scanner;

public class SortArrayofStrings {

	public static void main(String[] args) {
		
		Scanner scan = new Scanner(System.in);
		System.out.print("n = ");
		int n = scan.nextInt();
		
		scan.nextLine();
		String[] words = new String[n];
		for (int i = 0; i < n; i++) {
			words[i] = scan.nextLine();
		}
		scan.close();
		Arrays.sort(words);
		for (int i = 0; i < words.length; i++) {
			System.out.println(words[i]);
		}
		
	}

}
