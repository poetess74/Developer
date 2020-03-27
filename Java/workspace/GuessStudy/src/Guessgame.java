import java.util.InputMismatchException;
import java.util.Scanner;

public class Guessgame {
	public static void main (String[] args) {
		int check = 0;
		int c = 0;
		
		
		
		int randomNum = (int) (Math.random()*101);
		System.out.println("49" + randomNum+ " 50 ");
//		Scanner b = ; 
		
	    while (check == 0) {
	    	System.out.println("Guess?");
	    	
		    int a = 0;
		    
		    try {
		    	a = new Scanner(System.in).nextInt();
		    } catch (InputMismatchException e) {
		    	System.out.println("숫자만 입력하세요!");
		    	continue;
		    }
		    
		    c = c + 1;
		    
		    if (randomNum == a) {
		    	System.out.println("Congratulations!	" + randomNum		+"몇번	: " + c);
		    	check = 1;
		    } else if (randomNum > a) {
		    	System.out.println("Too Low");
		    } else {
		    	System.out.println("Too High");
		    }
		    
	    	if (check == 1) {
	    		break;
	    	}
	    }
	}
}


