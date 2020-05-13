package Homework.Mid_Test;

class Carrot extends GameObject {
    protected Carrot(int startX, int startY, int distance) {
        super(startX, startY, distance);
    }

    @Override
    protected void move() {
        int setX = (int)(Math.random()*5);
        if (setX == 0) {
            if (x < RaCaGame.MAX_X - distance) { x += distance; }
        } else if (setX == 1) {
            if (x > distance) { x -= distance; }
        }
        int setY = (int)(Math.random()*5);
        if (setY == 0) {
            if (y < RaCaGame.MAX_Y - distance) { y += distance; }
        } else if (setY == 1) {
            if (y > distance) { y -= distance; }
        }
    }

    @Override
    protected char getShape() {
        return '@';
    }
}
