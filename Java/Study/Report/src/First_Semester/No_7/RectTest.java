package First_Semester.No_7;

import java.util.Scanner;

class Rect {
    private int width, height;

    protected Rect() { width = 10; height = 10; }
    protected Rect(int width, int height) {
        this.width = width; this.height = height;
    }
    protected int area() { return width * height; }
    protected int around() { return (width + height) * 2; }

    protected int getHeight() { return height; }
    protected int getWidth() { return width; }
    protected void setHeight(int height) { this.height = height; }
    protected void setWidth(int width) { this.width = width; }
}
class Vol extends Rect {
    private int dept;
    protected Vol() { dept = 1; }
    protected Vol(int dept) { this.dept = dept; }
    protected int volume() { return area() * dept; }
    protected int around() { return 4 * (getHeight() + getWidth() + dept); }

    protected int getDept() { return dept; }
    protected void setDept(int dept) { this.dept = dept; }
}
public class RectTest {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Rect[] rect = new Rect[4];
        Vol[] vol = new Vol[4];
        for(int i = 0; i < rect.length; i++) {
            System.out.print("width, height, vol : ");
            rect[i] = new Rect(scanner.nextInt(), scanner.nextInt());
            vol[i] = new Vol(scanner.nextInt());
        }
        for (int i = 0; i < rect.length; i++) {
            System.out.println("area : " + rect[i].area());
            System.out.println("around : " + rect[i].around());
            System.out.println("vol : " + vol[i].getDept());
        }
    }
}
