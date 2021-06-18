package Second_Semester.No_5;

class Point {
	int x, y;
	public Point(int x, int y) { this.x = x; this.y = y; }
	public String toString() {
		return "Point(" + x + ", " + y + ")";
	}
	public boolean equals(Object object) {
		Point point = (Point)object;
		return (x == point.x && y == point.y);
	}
}

public class EqualsEx {
	public static void main(String[] args) {
		Point point1 = new Point(2, 3);
		Point point2 = new Point(2, 3);
		Point point3 = new Point(3, 4);
		System.out.println("객체 A : " + point1);
		System.out.println("객체 B : " + point2);
		System.out.println("객체 C : " + point3);
		if (point1 == point2) { System.out.println("a == b"); }
		if (point1.equals(point2)) { System.out.println("a is equal to b"); }
		if (point1.equals(point3)) { System.out.println("a is equal to c"); }
	}
}
