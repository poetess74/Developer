
public class Point {
	private int x;
	private int y;
	
	public Point (int x, int y) {
		this.x=x;
		this.y=y;
	}

	public void print() {
		System.out.printf("(%d,%d)\n", x, y);
	}
	
	public double distance(Point p) {
		int dx = p.x - x;
		int dy = p.y - y;
		return Math.sqrt(dx * dx + dy * dy);
	}
	
	public int getX() {
		return x;
		
	}
	
	public int getY() {
		return y;
	}
	
}

