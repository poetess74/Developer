package Part02.Round10;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round10_Ex10 {
    private int x;
    private int y;
    private BufferedReader in;
    protected Round10_Ex10() {
        this.in = new BufferedReader(new InputStreamReader(System.in));
        this.x = 0;
        this.y = 0;
    }
    protected void setX() throws IOException {
        System.out.print("x = ");
        this.x = Integer.parseInt(in.readLine());
    }
    protected void setY() throws IOException {
        System.out.print("y = ");
        this.y = Integer.parseInt(in.readLine());
    }
    protected void setX(int x) {
        this.x = x;
    }
    protected void setY(int y) {
        this.y = y;
    }
    protected int getX() {
        return x;
    }
    protected int getY() {
        return y;
    }
    protected void display() {
        System.out.println();
        System.out.println("점의 좌표 = " + x + ", " + y);
        System.out.println();
    }
}
