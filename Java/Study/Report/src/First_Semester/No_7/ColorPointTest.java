package First_Semester.No_7;

class Point {
    private int x, y;
    protected Point(int x, int y) { this.x = x; this.y = y; }
    protected int getX() { return x; }
    protected int getY() { return y; }
    protected void move(int x, int y) { this.x = x; this.y = y; }
}

class ColorPoint extends Point {
    private String color;
    protected ColorPoint(int x, int y, String color) {
        super(x, y);
        this.color = color;
    }

    protected void setColor(String color) { this.color = color; }
    protected void setPoint(int x, int y) { move(x, y); }
    protected void show() {
        System.out.println(color + "색으로 (" + getX() + ", " + getY() + ")");
    }
}

public class ColorPointTest {
    public static void main(String[] args) {
        ColorPoint colorPoint = new ColorPoint(5, 5, "YELLOW");
        colorPoint.setPoint(10, 20);
        colorPoint.setColor("GREEN");
        colorPoint.show();
    }
}
