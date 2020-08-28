package Homework.No_6;

class Point {
    private int x, y;
    protected void set(int x, int y) {
        this.x = x; this.y = y;
    }
    protected void showPoint() {
        System.out.printf("(%d, %d)", x, y);
    }
}

class ColorPoint extends Point {
    private String color;
    protected void setColor(String color) {
        this.color = color;
    }
    protected void showColorPoint() {
        System.out.print(color);
        showPoint();
    }
}
public class ColorPointEx {
    public static void main(String[] args) {
        Point point = new Point();
        point.set(1, 2); point.showPoint();
        ColorPoint colorPoint = new ColorPoint();
        colorPoint.set(3, 4); colorPoint.setColor("Red"); colorPoint.showColorPoint();
    }
}
