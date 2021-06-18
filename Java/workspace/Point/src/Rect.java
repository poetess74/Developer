
public class Rect {
	private float h; 
	private float w; 
	private Point pos;
	
	public Rect (int x, int y, float w, float h) {
		this.h = h;
		this.w = w;	
		pos = new Point(x, y);
	}
	public void print() {
		
		System.out.printf("(%d,%d) - %f x %f\n", pos.getX(), pos.getY(), w, h);
	
	}
	public double area() {
		
		return h * w;
	}
	public void move(int x, int y) {
		pos = new  Point(x, y);
	}
	
}
