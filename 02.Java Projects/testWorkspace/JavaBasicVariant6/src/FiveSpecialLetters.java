import java.util.Scanner;

public class FiveSpecialLetters {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		int startNum = Integer.parseInt(input.nextLine());
		int endNum = Integer.parseInt(input.nextLine());

		boolean resultFound = false;

		for (char first = 'a'; first <= 'e'; first++) {
			for (char second = 'a'; second <= 'e'; second++) {
				for (char third = 'a'; third <= 'e'; third++) {
					for (char fourth = 'a'; fourth <= 'e'; fourth++) {
						for (char fifth = 'a'; fifth <= 'e'; fifth++) {
							String wholeWord = "" + first + second + third
									+ fourth + fifth;
							long weight = calcWeight(wholeWord);

							if (weight >= startNum && weight <= endNum) {
								resultFound = true;
								System.out.print(wholeWord + " ");
							}
						}
					}
				}
			}
		}

		if (!resultFound) {
			System.out.println("No");
		}
	}

	public static long calcWeight(String word) {
		long weight = 0;
		int index = 1;
		boolean[] visited = new boolean[(int) 'e' + 1];

		for (int i = 0; i < word.length(); i++) {
			char currentLetter = word.charAt(i);

			if (!visited[currentLetter]) {
				weight += index * calcWeight(currentLetter);
				visited[currentLetter] = true;
				index++;
			}
		}

		return weight;
	}

	public static int calcWeight(char letter) {

		switch (letter) {
		case 'a':
			return 5;
		case 'b':
			return -12;
		case 'c':
			return 47;
		case 'd':
			return 7;
		case 'e':
			return -32;
		}

		return 0;
	}

}
