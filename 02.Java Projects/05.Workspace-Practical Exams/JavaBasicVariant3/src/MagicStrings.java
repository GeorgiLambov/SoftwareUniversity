import java.util.Scanner;


public class MagicStrings {

	public static void main(String[] args) {
		double startTime = System.currentTimeMillis();
		
		Scanner scan = new Scanner(System.in);
		
		int diff = scan.nextInt();
		char[] letters = { 'k', 'n', 'p', 's' };
		 int resultsCount = 0;
			
		 for (int d1 = 0; d1 < letters.length; d1++) {
				for (int d2 = 0; d2 < letters.length; d2++) {
	                for (int d3 = 0; d3 < letters.length; d3++){
	                    for (int d4 = 0; d4 < letters.length; d4++){
	                    	String left = "" + letters[d1] + letters[d2] + letters[d3] + letters[d4];
	                        int weightLeft = CalcWeight(left);
	                        
	                        for (int d5 = 0; d5 < letters.length; d5++) {
	                            for (int d6 = 0; d6 < letters.length; d6++) {
	                                for (int d7 = 0; d7 < letters.length; d7++) {
	                                    for (int d8 = 0; d8 < letters.length; d8++) {
	                                    	String right = "" + letters[d5] + letters[d6] + letters[d7] + letters[d8];
	                                        int weightRight = CalcWeight(right);
	                                        if (Math.abs(weightLeft - weightRight) == diff)
	                                        {
	                                            System.out.println(left + right);
	                                            resultsCount++;
	                                        }
	                                    }
	                                }
	                            }
	                        }
	                    }
	                }
	             }
	        }

	        if (resultsCount == 0)
	        {
	            System.out.println("No");
	        }
	        double stopTime = System.currentTimeMillis();
	        double elapsedTime = stopTime - startTime;
	        System.out.println(elapsedTime/1000);
	    }
	 private static int CalcWeight(String str)
	    {
	        int weight = 0;
	        for(char ch : str.toCharArray() )
	        {
		        switch ( ch )
	            {
	                case 's': weight += 3; break;
	                case 'n': weight += 4; break;
	                case 'k': weight += 1; break;
	                case 'p': weight += 5; break;
	            }
	        }
	       
	        return weight;
	       
	}
	 
}
