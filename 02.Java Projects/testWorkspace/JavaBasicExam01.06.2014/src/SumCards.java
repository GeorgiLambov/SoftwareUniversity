import java.util.ArrayList;
import java.util.Scanner;

import org.omg.CosNaming._BindingIteratorImplBase;

public class SumCards {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		String[] cards = scanner.nextLine().split("[SHDC ]+");

		int N = cards.length;
		int sum = 0;
		ArrayList<Integer> resultList = new ArrayList<>();
		for (int i = 0; i < cards.length; i++) {

			String card = cards[i];
			sum = 0;
			switch (card) {
			case "2":
				sum += 2;
				break;
			case "3":
				sum += 3;
				break;
			case "4":
				sum += 4;
				break;
			case "5":
				sum += 5;
				break;
			case "6":
				sum += 6;
				break;
			case "7":
				sum += 7;
				break;
			case "8":
				sum += 8;
				break;
			case "9":
				sum += 9;
				break;
			case "10":
				sum += 10;
				break;
			case "J":
				sum += 12;
				break;
			case "Q":
				sum += 13;
				break;
			case "K":
				sum += 14;
				break;
			case "A":
				sum += 15;
				break;
			default:
				break;
			}
			String prevcard;

			if (i > 0) {
				prevcard = cards[i - 1];
				String sledCardString = null;
				if (i < cards.length - 1) {
					sledCardString = cards[i + 1];
					if (sledCardString.equals(card) || prevcard.equals(card)) {
						sum = sum * 2;
					}
				}
				if (i == cards.length - 1) {
					if (prevcard.endsWith(card)) {
						sum = sum * 2;
					}
				}

			} else if (i == 0 && cards.length > 1) {
				prevcard = cards[i + 1];
				if (prevcard.equals(card)) {
					sum = sum * 2;
				}
			}

			resultList.add(sum);
		}

		int resultSum = 0;

		for (int j = 0; j < resultList.size(); j++) {
			resultSum += resultList.get(j);
		}

		System.out.println(resultSum);
	}
}
