package Part02.Round13;

class A {
    private int x;
    private int y;

    public A() {
        x = 1;
        y = 1;
    }

    public A(int x) {
        this.x = x;
    }

    public A(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public void disp() {
        System.out.printf("x=%d, y=%d", x, y);
    }
}

class B extends A {
    private int x;
    private int y;

    public B() {
        this(1, 1);
    }

    public B(int x) {
        this(x, 1);
    }

    public B(int x, int y) {
        this(x, y, 1 , 1);
    }

    public B(int x1, int y1, int x2) {
        this(x1, y1, x2, 1);
    }

    public B(int x1, int y1, int x2, int y2) {
        super(x1, y1);
        this.x = x2;
        this.y = y2;
    }

    public void disp() {
        super.disp();
        System.out.printf(", x=%d, y=%d\n", x, y);
    }
}

public class Round13_01 {
    public static void main(String[] args) {
        B bp = new B();
        B bp1 = new B(10);
        B bp2 = new B(10, 20);
        B bp3 = new B(10, 20, 30);
        B bp4 = new B(10 ,20, 30, 40);

        bp.disp();
        bp1.disp();
        bp2.disp();
        bp3.disp();
        bp4.disp();
    }
}
