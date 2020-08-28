package Homework.No_12;

import java.util.Vector;

class Point {
    private int x, y;
    protected Point(int x, int y) {
        this.x = x; this.y = y;
    }
    public String toString() {
        return "(" + x + ", " + y + ")";
    }
}

public class PointVectorEx {
    public static void main(String[] args) {
        Vector<Point> vector = new Vector<Point>();
        vector.add(new Point(2, 3));
//        Point point = new Point(2, 3);
        vector.add(new Point(-5, 20));
        vector.add(new Point(30, -8));
        vector.remove(1);
        for (Point point : vector) {
            System.out.println(point);
        }
    }
}
