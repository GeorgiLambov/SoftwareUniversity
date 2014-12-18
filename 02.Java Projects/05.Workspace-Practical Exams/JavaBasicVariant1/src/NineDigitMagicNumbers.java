import java.util.Scanner;

public class NineDigitMagicNumbers {

	public static void main(String[] args) {
		
		Scanner in = new Scanner(System.in);
		int sum = in.nextInt();
		int diff = in.nextInt();
		
		int counter = 0;
		for (int num1 = 111; num1 < 777; num1++) {
			int num2 = num1 + diff;
			int num3 = num1 + 2*diff;
			
			if (IsValidNum(num1) && IsValidNum(num2) && IsValidNum(num3) && (IsValidSum(num1) + IsValidSum(num2) + IsValidSum(num3) == sum)&& num3<=777) {
				
				System.out.printf("%d%d%d\n", num1,num2,num3);
				counter++;
			}
		}
		if (counter == 0) {
			System.out.println("No");
		}	
	}

	private static int IsValidSum(int num) {
		   int sum = 0;
	        while (num > 0)
	        {
	            sum += num % 10;
	            num = num / 10;
	        }
	        return sum;
	}
	
	private static boolean IsValidNum(int num) {
		
		while (num > 0) {
			int digit = num % 10;
			if (digit < 1|| digit > 7) {
				return false;
			}
			num = num/10;
		}
	
		return true;
	}

}
