package First_Semester.No_10;

class CircleManager_Circle {
    private int x, y, radius;
    public CircleManager_Circle(int x, int y, int radius) {
        this.x = x; this.y = y; this.radius = radius;
    }
    public String toString() {
        return "(" + x + ", " + y + ") 반지름 " + radius;
    }
    public double area() {
        return radius * radius * 3.14;
    }
    public boolean equals(Object object) {
        CircleManager_Circle circle = (CircleManager_Circle)object;
        return area() == circle.area();
    }
}

public class CircleManager {
    public static void main(String[] args) {
        CircleManager_Circle a = new CircleManager_Circle(1, 2, 10);
        CircleManager_Circle b = new CircleManager_Circle(5, 6, 10);
        System.out.println("원 1: " + a);
        System.out.println("원 2: " + b);
        System.out.println(a.equals(b) ? "같은 원입니다. " : "다른 원입니다. ");
    }
}
