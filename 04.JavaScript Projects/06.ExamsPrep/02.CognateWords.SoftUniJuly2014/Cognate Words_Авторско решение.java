import java.util.Scanner;
import java.util.HashSet;

public class CognateWords {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String[] words = sc.nextLine().split("[^a-zA-Z]+");
		
		HashSet<String> cognateWords = new HashSet<>();
		for (int a = 0; a < words.length; a++) {
			for (int b = 0; b < words.length; b++) {
				for (int c = 0; c < words.length; c++) {
					// Check if a!=b and a|b=c 
					if (a != b) {
						boolean check = (words[a] + words[b]).equals(words[c]);
						if (check) {
							cognateWords.add(words[a] + "|" + words[b] + "=" + words[c]);
						}
					}					
				}
			}
		}
		
		if (cognateWords.isEmpty()) {
			System.out.println("No");
		} else {
			for (String cognate : cognateWords) {
				System.out.println(cognate);
			}
		}
	}

}
