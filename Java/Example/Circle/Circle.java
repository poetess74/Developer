
//Circle.java

public class Circle {
	private Point m;
	private float r;
	
	public Circle (int x, int y, float r) {
		m = new Point (x, y);
		this.r = r;
	}
	public void print() {
		
		System.out.printf("((%d,%d) %f)\n", m.getX(), m.getY(), r);
	
	}
	public boolean collided(Circle c) {
		return this.m.distance(c.m) <= this.r + c.r;
	}
	public double area() {
		return r*r*Math.PI;
		
	}
}