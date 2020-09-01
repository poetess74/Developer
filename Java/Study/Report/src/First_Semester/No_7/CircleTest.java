package First_Semester.No_7;

class Circle {
    private int radius;
    protected Circle(int radius) { this.radius = radius; }
    protected int getRadius() { return radius; }
    protected void setRadius(int radius) { this.radius = radius; }
}
class NamedCircle extends Circle {
    private String name;
    protected NamedCircle(int radius, String name) {
        super(radius);
        this.name = name;
    }
    protected void show() {
        System.out.println(name + ", 반지름 = " + getRadius());
    }
}
public class CircleTest {
    public static void main(String[] args) {
        NamedCircle w = new NamedCircle(5, "Waffle");
        w.show();
    }
}
