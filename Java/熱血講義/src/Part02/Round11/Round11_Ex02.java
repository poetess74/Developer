package Part02.Round11;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round11_Ex02 {
    private int x;
    private int y;
    private static int total;
    private static BufferedReader in;
    static {
        Round11_Ex02.in = new BufferedReader(new InputStreamReader(System.in));
        Round11_Ex02.total = 0;
    }
    protected Round11_Ex02() throws IOException {
        System.out.print("x = ");
        this.x = Integer.parseInt(Round11_Ex02.in.readLine());
        System.out.print("y = ");
        this.y = Integer.parseInt(Round11_Ex02.in.readLine());
        Round11_Ex02.total = this.x + this.y;
    }
    protected static int getTotal() {
        return Round11_Ex02.total;
    }
    protected static void setTotal(int total) {
        Round11_Ex02.total = total;
    }
    protected void display() {
        System.out.println(this.x + " + " + this.y + " = " + Round11_Ex02.total);
    }
}
