import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;

/*
 * Create a class Product to hold products, which have name (string) and price (decimal number). Read from a text file named "Input.txt" 
 * a list of products. Each product will be in format name + space + price. You should hold the products in objects of class Product. 
 * Sort the products by price and write them in format price + space + name in a file named "Output.txt". Ensure you close correctly 
 * all used resources.
 *  */
public class _9_ListofProducts {

	public static void main(String[] args) {
		ArrayList<Product> products = new ArrayList<>();
		try {
			BufferedReader reader = new BufferedReader(new FileReader(
					"ProductInput.txt"));
			BufferedWriter writer = new BufferedWriter(new FileWriter(
					"ProductOutput.txt"));

			String inputLine;
			while ((inputLine = reader.readLine()) != null) {
				String[] splited = inputLine.split(" ");
				products.add(new Product(splited[0], Double
						.parseDouble(splited[1])));

			}
			Collections.sort(products);
			for (Product product : products) {
				writer.write(product.getPrise() + " " + product.getName()
						+ "\r\n");
			}
			reader.close();
			writer.close();
		} catch (IOException exeption) {
			System.out.print("Error");
			exeption.printStackTrace();
		}
	}

}
