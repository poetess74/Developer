public class GuessGame {
	Player p1;
	Player p2;
	Player p3;
	
	public void startGame () {
		p1 = new Player();
		p2 = new Player();
		p3 = new Player();
		
		int guessp1 = 0;
		int guessp2 = 0;
		int guessp3 = 0;
		
		boolean p1isRight = false;
		boolean p2isRight = false;
		boolean p3isRight = false;
		
		int targetNumber = (int) (Math.random() * 10);
		System.out.println("--------------------------NEW-------------------------");
		System.out.println("Guess a number greater than zero, less than 9.");
		
		while(true) {
			System.out.println("The number you need to guess is " + targetNumber + ".");
			
			p1.guess();
			p2.guess();
			p3.guess();
			
			guessp1 = p1.number;
			System.out.println("#1 Players have taken a number: " + guessp1);
			
			guessp2 = p2.number;
			System.out.println("#2 Players have taken a number: " + guessp2);
			
			guessp3 = p3.number;
			System.out.println("#3 Players have taken a number: " + guessp3);
			
			if (guessp1 == targetNumber) {
				p1isRight = true;
			}
			if (guessp2 == targetNumber) {
				p2isRight = true;
			}
			if (guessp3 == targetNumber) {
				p3isRight = true;
			}
			
			if (p1isRight || p2isRight || p3isRight) {
				System.out.println("Guessed player.");
				System.out.println("#1 Player: " + p1isRight);
				System.out.println("#2 Player: " + p2isRight);
				System.out.println("#3 Player: " + p3isRight);
				System.out.println("Game OVER.");
				break;
			} else {
				System.out.println("Game ERROR...");
				System.out.println("ERRORcode 10285");
				System.out.println("Try again");
			}
		}
	}
}
