package Homework.Mid_Test;

import java.util.Scanner;

public class Rabbit extends GameObject {
    public Rabbit(int startX, int startY, int distance) {
        super(startX, startY, distance);
    }

    @Override
    public char getShape() { return 'R'; }
    public void move() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("위(w), 아래(s), 왼쪽(a), 오른쪽(d) >> ");
        String input = scanner.next();
        switch (input.toLowerCase().charAt(0)) {
            case 'w': y = Math.max(y - distance, 0); break;
            case 's': y = Math.min(y + distance, RaCaGame.MAX_Y - 1); break;
            case 'a': x = Math.max(x - distance, 0); break;
            case 'd': x = Math.min(x + distance, RaCaGame.MAX_X - 1); break;
        }
        scanner.close();
    }
}
