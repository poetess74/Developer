package Homework.Mid_Test;

import java.util.Scanner;

class Rabbit extends GameObject {
    protected Rabbit(int startX, int startY, int distance) {
        super(startX, startY, distance);
    }

    @Override
    protected void move() {
        Scanner scanner = new Scanner(System.in);
        System.out.print("왼쪽(a), 아래(s), 위(d), 오른쪽(f) >> ");
        String input = scanner.next();
        switch (input.toLowerCase().charAt(0)) {
            case 'a': if (x > distance) { x -= distance; }
            case 's': if (y < RaCaGame.MAX_Y - distance) { y += distance; }
            case 'd': if (y < distance) { y -= distance; }
            case 'f': if (x < RaCaGame.MAX_X - distance) { x += distance; }
        }
    }

    @Override
    protected char getShape() {
        return 'R';
    }
}
