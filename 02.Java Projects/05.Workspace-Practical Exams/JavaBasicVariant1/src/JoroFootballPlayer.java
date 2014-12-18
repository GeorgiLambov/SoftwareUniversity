import java.util.Scanner;

public class JoroFootballPlayer {
	public static  void main(String[] args){
		
		Scanner in = new Scanner(System.in);
		
		String leap =in.nextLine();
		
		int addPlays= 0;
		if ( leap.equals("t")) {
			addPlays += 3;
		}
		
		int holidays = in.nextInt();
		int hometowns = in.nextInt();
		
		in.close();
		
		double plays = hometowns + (double)2/3* (52 - hometowns) + (double)1/2* holidays + addPlays;
		System.out.print((int)plays);
	}
}
