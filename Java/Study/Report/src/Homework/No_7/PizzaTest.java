package Homework.No_7;

class Circle2 {
    private int radius;

    protected void setRadius(int radius) { this.radius = radius; }
    protected int getRadius() { return radius; }

    protected static final double PI = 3.14;
    protected Circle2(int radius) { this.radius = radius; }
    protected Circle2() { radius = 1; }
    protected double area() { return radius * radius * PI; }
}

class Pizza extends Circle2 {
    private String topping;

    protected void setTopping(String topping) { this.topping = topping; }
    protected String getTopping() { return topping; }
    protected Pizza(String topping, int radius) {
        super(radius);
        this.topping = topping;
    }
    protected Pizza() { topping = "치즈"; }
    protected void print() {
        System.out.println("토핑 : " + topping);
        System.out.println("반지름 : " + getRadius());
        System.out.println("면적 : " + area());
    }
}

public class PizzaTest {
    public static void main(String[] args) {
        Pizza pizza = new Pizza();
        Pizza pizza1 = new Pizza("베이컨", 10);
        pizza.print(); pizza1.print();
    }
}
