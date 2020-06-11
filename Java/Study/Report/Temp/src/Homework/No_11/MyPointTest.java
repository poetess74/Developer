package Homework.No_11;

class MyPoint {
    private int x, y;
    protected MyPoint(int x, int y) { this.x = x; this.y = y; }
    public String toString() {
        return "MyPoint(" + x + ", " + y + ")";
    }
}

public class MyPointTest {
    public static void main(String[] args) {
        MyPoint a = new MyPoint(3, 20);
        System.out.println(a);
    }
}
