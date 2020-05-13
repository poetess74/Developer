package Homework.Mid_Test;

abstract class GameObject {
    protected int distance;
    protected int x, y;
    protected GameObject(int startX, int startY, int distance) {
        this.x = startX;
        this.y = startY;
        this.distance = distance;
    }
    protected int getX() { return x; }
    protected int getY() { return y; }
    protected boolean collide(GameObject p) {
        return this.x == p.getX() && this.x == p.getY();
    }
    protected abstract void move();
    protected abstract char getShape();
}
