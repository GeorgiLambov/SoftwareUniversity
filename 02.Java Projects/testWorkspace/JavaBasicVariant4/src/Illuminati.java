import java.util.Scanner;

public class Illuminati {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		String inputLine = input.nextLine().toUpperCase();
		String[] inputText = inputLine.split("\\W+");
		int result = 0;
		int numberofvowels = 0;
		for (String word : inputText) {
			char[] text = word.toCharArray();

			for (char ch : text) {
				switch (ch) {
				case 'A':
					result += 'A';
					numberofvowels++;
					break;
				case 'E':
					result += (int) 'E';
					numberofvowels++;
					break;
				case 'I':
					result += (int) 'I';
					numberofvowels++;
					;
					break;
				case 'O':
					result += (int) 'O';
					numberofvowels++;
					break;
				case 'U':
					result += (int) 'U';
					numberofvowels++;
					break;

				}
			}
		}
		System.out.println(numberofvowels);
		System.out.println(result);
	}

}
