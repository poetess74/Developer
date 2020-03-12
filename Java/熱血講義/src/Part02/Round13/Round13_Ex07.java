package Part02.Round13;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

class MyPoint {
    private int x, y;
    protected static BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
    protected MyPoint() throws IOException {
        System.out.print("x = ");
        this.x = Integer.parseInt(in.readLine());
        System.out.print("y = ");
        this.y = Integer.parseInt(in.readLine());
    }
    protected void disp() {
        System.out.println(this.x + ", " + this.y);
    }
}
class Circle extends MyPoint {
    private int r;
    protected Circle() throws IOException {
        super();
        System.out.print("r = ");
        this.r = Integer.parseInt(in.readLine());
    }
    protected void disp() {
        super.disp();
        System.out.println(this.r);
    }
}
class Rect extends MyPoint {
    private int w, h;
    protected Rect() throws IOException {
        super();
        System.out.print("w = ");
        this.w = Integer.parseInt(in.readLine());
        System.out.print("h = ");
        this.h = Integer.parseInt(in.readLine());
    }

    @Override
    protected void disp() {
        super.disp();
        System.out.println(this.w + ", " + this.h);
    }
}
public class Round13_Ex07 {
    public static void main(String[] args) throws IOException {
        Circle cc = new Circle();
        cc.disp();
        System.out.println();
        Rect rt = new Rect();
        rt.disp();
    }
}
