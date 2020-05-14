package Homework.Mid_Test;

import java.util.Scanner;

class Rabbit extends GameObject {
    protected Rabbit(int startX, int startY, int distance) {
        super(startX, startY, distance);
    }

    @Override
    protected char getShape() { return 'R'; }
    protected void move() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("위(w), 아래(s), 왼쪽(a), 오른쪽(d) >> ");
        String input = scanner.next();
        switch (input.toLowerCase().charAt(0)) {
            case 'w': if (y >= distance) { y -= distance; break; }
            case 's': if (y <= RaCaGame.MAX_Y - distance) { y += distance; break; }
            case 'a': if (x >= distance) { x -= distance; break; }
            case 'd': if (x <= RaCaGame.MAX_X - distance) { x += distance; break; }
        }
    }
}
