package Homework.Mid_Test;

public class Carrot extends GameObject {
    public Carrot(int startX, int startY, int distance) {
        super(startX, startY, distance);
    }

    @Override
    public char getShape() { return '@'; }
    public void move() {
        int rnd = (int)(Math.random() * 5);
        if (rnd == 0 || rnd == 1) {
            int dir = (int)(Math.random() * 4); // 움직일 방향 결정 (0: 위, 1: 아래, 2: 왼쪽, 3: 오른쪽)
            switch (dir) {
                case 0: y = Math.max(y - distance, 0); break;
                case 1: y = Math.min(y + distance, RaCaGame.MAX_Y - 1); break;
                case 2: x = Math.max(x - distance, 0); break;
                case 3: x = Math.min(x + distance, RaCaGame.MAX_X - 1); break;
            }
        }
    }
}
