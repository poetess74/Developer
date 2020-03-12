package Part02.Round13;

class A {
    protected int x = 100;
    protected int y = 200;
}

class B extends A {
    private int r = 300;
    protected void disp() {
        System.out.println("x = " + super.x);
        System.out.println("x = " + super.y);
        System.out.println("x = " + this.r);
    }
}

public class Round13_Ex04 {
    public static void main(String[] args) {
        B bp = new B();
        bp.disp();
    }
}
