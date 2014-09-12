import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class LogsAggregator {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		input.nextLine();

		TreeMap<String, TreeMap<String, Integer>> logsByUserMap = new TreeMap<>();
		for (int i = 0; i < n; i++) {
			String line = input.nextLine();
			String[] inline = line.split(" ");

			String IP = inline[0];
			String user = inline[1];
			String duration = inline[2];

			TreeMap<String, Integer> IPDuration = new TreeMap<>();

			if (logsByUserMap.containsKey(user)) {
				IPDuration = logsByUserMap.get(user);
				if (IPDuration.containsKey(IP)) {
					IPDuration.put(IP,
							IPDuration.get(IP) + Integer.parseInt(duration));
				} else {
					IPDuration.put(IP, Integer.parseInt(duration));
				}

			} else {
				IPDuration.put(IP, Integer.parseInt(duration));
			}
			logsByUserMap.put(user, IPDuration);
		}

		for (String user : logsByUserMap.keySet()) {
			System.out.printf("%s: ", user);
			TreeMap<String, Integer> IPDuration = new TreeMap<>();
			IPDuration = logsByUserMap.get(user);
			int result = 0;
			for (Map.Entry<String, Integer> entry : IPDuration.entrySet()) {
				Integer num = entry.getValue();
				result = result + num;
			}

			System.out.print(result);
			System.out.print(" [");
			for (String str : IPDuration.keySet()) {
				if (str != IPDuration.lastKey()) {
					System.out.printf("%s, ", str);
				} else {
					System.out.printf("%s", str);
				}
			}
			System.out.println("]");
		}

	}

}
