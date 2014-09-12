import java.util.Scanner;

public class StudentCables {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int totoalCableLenght = 0;
		int counterLoose = 0;
		int numberOfCables = input.nextInt();
		for (int i = 0; i < numberOfCables; i++) {
			int cablelength = input.nextInt();
			input.nextLine();
			String cableMeasure = input.nextLine();

			if (cableMeasure.equals("meters")) {
				cablelength = cablelength * 100;
			}
			if (cablelength >= 20) {
				totoalCableLenght += cablelength;
				counterLoose++;
			}
		}
		totoalCableLenght = totoalCableLenght - 3 * (counterLoose - 1);
		int studentCables = totoalCableLenght / 504;
		int remainingCable = totoalCableLenght % 504;
		System.out.println(studentCables);
		System.out.println(remainingCable);
	}
}
