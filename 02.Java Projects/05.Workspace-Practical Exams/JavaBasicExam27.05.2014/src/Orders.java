import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Orders {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		LinkedHashMap<String, TreeMap<String, Integer>> productsAndCustomers = new LinkedHashMap<>();
		input.nextLine();
		for (int i = 0; i < n; i++) {
			String inputLine = input.nextLine();
			String[] inputData = inputLine.split(" ");
			TreeMap<String, Integer> Customer = new TreeMap<>();

			if (productsAndCustomers.containsKey(inputData[2])) {
				Customer = productsAndCustomers.get(inputData[2]);
				if (Customer.containsKey(inputData[0])) {
					Customer.put(inputData[0], Customer.get(inputData[0])
							+ Integer.parseInt(inputData[1]));
				} else {
					Customer.put(inputData[0], Integer.parseInt(inputData[1]));
				}
			} else {
				Customer.put(inputData[0], Integer.parseInt(inputData[1]));
			}
			productsAndCustomers.put(inputData[2], Customer);
		}

		for (String string : productsAndCustomers.keySet()) {
			System.out.printf("%s: ", string);
			TreeMap<String, Integer> Customer = new TreeMap<>();
			Customer = productsAndCustomers.get(string);
			for (String str : Customer.keySet()) {
				if (str != Customer.lastKey()) {
					System.out.printf("%s %d, ", str, Customer.get(str));
				} else {
					System.out.printf("%s %d", str, Customer.get(str));
				}
			}
			System.out.println();
		}

		for (String product : productsAndCustomers.keySet()) {
			System.out.print(product + ": ");

			TreeMap<String, Integer> Customer = new TreeMap<>();
			Customer = productsAndCustomers.get(product);

			for (Map.Entry<String, Integer> entry : Customer.entrySet()) {
				System.out.printf("%s %s, ", entry.getKey(), entry.getValue());
			}
			System.out.println();
		}
	}
}