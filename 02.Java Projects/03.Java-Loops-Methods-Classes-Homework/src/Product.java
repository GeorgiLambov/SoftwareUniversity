public class Product implements Comparable<Product> {

	private String name;
	private double price;

	public Product(String name, double price) {
		this.name = name;
		this.price = price;
	}

	public Double getPrise() {
		return price;
	}

	public String getName() {
		return name;
	}

	public int compareTo(Product product) {
		double price = product.getPrise();
		if (this.price > price) {
			return 1;
		} else if (this.price == price) {
			return 0;
		} else {
			return -1;
		}
	}

}
