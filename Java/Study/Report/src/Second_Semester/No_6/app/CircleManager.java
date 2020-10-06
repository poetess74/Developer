package Second_Semester.No_6.app;

import Second_Semester.No_6.lib.Circle;

public class CircleManager {
	public static void main(String[] args) {
		Circle a = new Circle(1, 2, 10);
		Circle b = new Circle(5, 6, 10);
		System.out.println("원 1: " + a);
		System.out.println("원 2: " + b);
		System.out.println(a.equals(b) ? "넓이가 같음" : "넓이가 다름");
	}
}
