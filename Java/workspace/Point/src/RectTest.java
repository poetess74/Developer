
public class RectTest {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Rect r1 = new Rect (0, 0, 10, 5);
		r1.print();
		double a = r1.area();
		System.out.printf("%f\n", a);
		r1.move(5,5);
		r1.print();
	}
}
