import java.util.Random;
import java.util.Scanner;

public class Guessgame {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);

		Random num = new Random();
		

		int rannum = num.nextInt(100) + 1;
		
		int input = 0;

		int number;

		int ca = 1;

		number = scan.nextInt();
		for (input = 0; input != rannum;) {

			System.out.println("Guess What?");

			input = scan.nextInt();
			
			if (rannum == input) {

				System.out.println("congratulation");
				System.out.println("T = " + ca);
			}

			else if (input < rannum) {
				System.out.println("Too Down");
			}

			else if (input > rannum) {
				System.out.println("Too High");
			}
			ca += 1;

		}

	}
}