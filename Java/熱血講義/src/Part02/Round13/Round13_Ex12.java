package Part02.Round13;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

class MyPoint1 {
    private int x, y;
    protected static BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
    protected MyPoint1() throws IOException {
        System.out.print("x = ");
        this.x = Integer.parseInt(in.readLine());
        System.out.print("y = ");
        this.y = Integer.parseInt(in.readLine());
    }
    protected void disp() {
        System.out.println(x + ", " + y);
    }
}
class Circle1 extends MyPoint1 {
    private int r;
    protected Circle1() throws IOException {
        super();
        System.out.print("r = ");
        this.r = Integer.parseInt(in.readLine());
    }
    protected void disp() {
        super.disp();
        System.out.println(this.r);
    }
}
class Rect1 extends MyPoint1 {
    private int w, h;
    protected Rect1() throws IOException {
        super();
        System.out.print("w = ");
        this.w = Integer.parseInt(in.readLine());
        System.out.print("h = ");
        this.h = Integer.parseInt(in.readLine());
    }
    protected void disp() {
        super.disp();
        System.out.println(this.w + ", " + this.h);
    }
}
public class Round13_Ex12 {
    protected static BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
    public static void main(String[] args) throws IOException {
        MyPoint1[] mp = new MyPoint1[10];
        for (int i = 0; i < mp.length; i++) {
            System.out.println();
            System.out.print("1. 원 2. 사각형 3. 보기 4. 종료 ==> ");
            switch (Integer.parseInt(in.readLine())) {
                case 1: mp[i] = new Circle1(); break;
                case 2: mp[i] = new Rect1(); break;
                case 3:
                    System.out.println("=== 보기 ===");
                    for (int j = 0; j < i; j++) {
                        mp[j].disp();
                    }
                    System.out.println("=== 보기 ===");
                    i--;
                    break;
                case 4: System.out.println("프로그램을 종료합니다. \n수고 하셨습니다. "); System.exit(0); break;
                default: System.out.println("잘못 입력하셨습니다. ");
            }
        }
    }
}
