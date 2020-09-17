package Second_Semester.No_4;

import java.util.Scanner;

class Player {
	private String name;
	public Player(String name) { this.name = name; }
	public String getName() { return name; }
}

public class GamblingGame {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		Player[] players = new Player[2];
		for(int i = 0; i < players.length; i++) {
			System.out.print("선수 이름 입력 >> ");
			players[i] = new Player(scanner.next());
		}
		int number = 0;

		while(true) {
			System.out.print(players[number].getName() + "씨, <Enter 외 아무 키나 치세요> ");
			scanner.next();
			int[] value = new int[3];
			for(int i = 0; i < value.length; i++) {
				value[i] = (int)(Math.random() * 3);
				System.out.print(value[i] + "\t");
			}
			System.out.println();
			if(value[0] == value[1] && value[1] == value[2]) {
				System.out.println(players[number].getName() + "이 승리하였습니다. ");
				break;
			}
			number++;
			number %= 2;
		}
		scanner.close();
	}
}
