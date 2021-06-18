package First_Semester.No_10;

interface ShapeApp_Shape {
    final float PI = 3.14f;
    void draw();
    float getArea();
    default public void redraw() {
        System.out.println("--- 다시 그립니다. ---");
        draw();
    }
}

class ShapeApp_Circle implements ShapeApp_Shape {
    private int radius;
    public void draw() {
        System.out.printf("반지름 %d ", radius, getArea());
    }
    public float getArea() { return radius * radius * PI; }
    public ShapeApp_Circle(int radius) { this.radius = radius; }
}

public class ShapeApp {
    public static void main(String[] args) {
        ShapeApp_Shape coin = new ShapeApp_Circle(10);
        coin.redraw();
        System.out.printf("코인의 면적은 %.1f", coin.getArea());
    }
}
