package Second_Semester.Practice.No_4;

interface Shape {
	final double PI = 3.14;
	void draw();
	double getArea();
	default public void reDraw() {
		System.out.println("--- 다시 그립니다. ---");
		draw();
	}
}

class Circle implements Shape {
	private int radius;

	public Circle(int radius) { this.radius = radius; }
	public void draw() { System.out.printf("반지름 %d", radius); }
	public double getArea() { return radius * radius * PI; }
}

public class ShapeApp {
	public static void main(String[] args) {
		Shape coin = new Circle(10);
		coin.reDraw();
		System.out.println(" 코인의 면적은 " + coin.getArea());
	}
}
