import java.util.Scanner;

public class ProgrammerDNA {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int n = input.nextInt();
		input.nextLine();
		String startingLeter = input.nextLine();
		char letter = startingLeter.charAt(0);
		// {'A', 'B', 'C', 'D', 'E', 'F', 'G'};

		int count = 3;
		int countLeter = 1;
		int rowsCount = 1;

		int firstCode = (letter - 'A');
		int maxCode = 'G' - 'A';

		for (int row = 0; row < n; row++) {

			String dot = new String(new char[count]).replace("\0", ".");
			System.out.print(dot);

			for (int j = 0; j < countLeter; j++) {

				char currentLetter = (char) (firstCode + 'A');
				System.out.print(currentLetter);
				if (firstCode > maxCode - 1) {
					firstCode = firstCode - maxCode - 1;
				}
				firstCode++;
			}
			System.out.println(dot);

			if (rowsCount < 4) {
				count--;
				countLeter += 2;
			} else if (rowsCount >= 4 && rowsCount < 7) {
				count++;
				countLeter -= 2;
			}
			rowsCount++;
			if (rowsCount == 8) {
				rowsCount = 1;
			}

		}
	}

}
