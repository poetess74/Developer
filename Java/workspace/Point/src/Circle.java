
public class Circle {
	private Point m; //원의 중점  
	private float r; //원의 반지름 
	
	public Circle (int x, int y, float r) {
		m = new Point(x, y);
		this.r = r;
	}
	
	public void print() {
		System.out.printf("((%d,%d) %f)\n", m.getX(), m.getY(), r);
	}
	
	public boolean collided(Circle c) {
		double d;//두 원의 중점 사이의 거리를 담을 변수 
		d = this.m.distance(c.m);
		return d <= this.r + c.r;
	}
	public double area() {
		
		return Math.PI * r * r;
	}
	public void move(int x, int y) {
		m = new  Point(x, y);
	}
}

