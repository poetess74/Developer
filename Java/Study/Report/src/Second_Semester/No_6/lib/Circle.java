package Second_Semester.No_6.lib;

public class Circle {
	private int x, y, radius;
	public int getArea() { return radius * radius * 3; };
	public Circle(int x, int y, int radius) {
		this.x = x; this.y = y; this.radius = radius;
	}
	public String toString() {
		return "(" + x + ", " + y + ")" + "반지름" + radius;
	}

	public boolean equals(Object object) {
		Circle circle = (Circle)object;
		return getArea() == circle.getArea();
	}
}
