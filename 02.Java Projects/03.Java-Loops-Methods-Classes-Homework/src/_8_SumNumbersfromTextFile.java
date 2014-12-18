import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

/*
 * Write a program to read a text file "Input.txt" holding a sequence of integer numbers, each at a separate line. 
 * Print the sum of the numbers at the console. Ensure you close correctly the file in case of exception or in case of normal execution.
 *  In case of exception (e.g. the file is missing), print "Error" as a result. 
 */
public class _8_SumNumbersfromTextFile {

	public static void main(String[] args) {

		BufferedReader reader = null;
		int result = 0;
		String fileName = "SumofNumbers.txt";
		try {

			String currentLine;

			reader = new BufferedReader(new FileReader(fileName));

			while ((currentLine = reader.readLine()) != null) {
				result += Integer.parseInt(currentLine);
			}
			System.out.println("Result = " + result);

		} catch (IOException e) {
			System.out.println("Error!");
		} finally {
			try {
				if (reader != null) {
					reader.close();
				}
			} catch (IOException ex) {
				ex.printStackTrace();
			}
		}

	}

}