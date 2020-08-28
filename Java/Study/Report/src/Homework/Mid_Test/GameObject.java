package Homework.Mid_Test;

public abstract class GameObject {
    protected int distance;
    protected int x, y;
    public GameObject(int startX, int startY, int distance) {
        this.x = startX;
        this.y = startY;
        this.distance = distance;
    }
    public int getX() { return x; }
    public int getY() { return y; }
    public boolean collide(GameObject p) {
        return this.x == p.getX() && this.y == p.getY();
    }
    protected abstract void move();
    protected abstract char getShape();
}
