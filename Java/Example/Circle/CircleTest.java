
public class CircleTest {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Circle c1 = new Circle (5, 5, 4);
		Circle c2 = new Circle (10, 10, 4);
		c1.print();
		c2.print();
		
		System.out.println("c1과 c2는 부딪혔을까요?" + c1.collided(c2));
		System.out.printf("%f", c1.area());
	}

}
