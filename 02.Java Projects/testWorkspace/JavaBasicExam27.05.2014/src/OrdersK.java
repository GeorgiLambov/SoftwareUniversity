import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;

public class OrdersK {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        LinkedHashMap<String, TreeMap<String, Integer>> productsAndCustomers = new LinkedHashMap<>();
        input.nextLine();
        for (int i = 0; i < n; i++) {
            String inputLine = input.nextLine();
            String[] inputData = inputLine.split(" ");
            
            String nameCustumer = inputData[0];
            String countProduct = inputData[1];
            String product = inputData[2];
            
            TreeMap<String, Integer> Customer = new TreeMap<>();
            
            if (productsAndCustomers.containsKey(product)) { // Проверяваме дали вече имаме такъв продукт и ако имаме:
                Customer = productsAndCustomers.get(product); // ... взимаме всички записи на клиентите
  
                if (Customer.containsKey(nameCustumer)) { // ... проверяваме дали клиента е стар
                    Customer.put(nameCustumer, Customer.get(nameCustumer) + Integer.parseInt(countProduct)); // ... ... ако съществува такъв клиент, добавяме новата стойност
                } else {
                    Customer.put(nameCustumer, Integer.parseInt(countProduct)); // ... ... ако не съществува, го записваме в речника
                }
            } else {
                Customer.put(nameCustumer, Integer.parseInt(countProduct)); // ... нямаме такъв продукт, значи добавяме въведената стойност
            }
           productsAndCustomers.put(product, Customer); // ... записваме данните в речника за продукти и клиенти
        }

        for (String product : productsAndCustomers.keySet()) {
            System.out.printf("%s: ", product);
            TreeMap<String, Integer> Customer = new TreeMap<>();
            Customer = productsAndCustomers.get(product);
            for (String str : Customer.keySet()) {
                if (str != Customer.lastKey()) {
                    System.out.printf("%s %d, ", str, Customer.get(str));
                } else {
                    System.out.printf("%s %d", str, Customer.get(str));
                }
            }
            System.out.println();
        }
    }
}
