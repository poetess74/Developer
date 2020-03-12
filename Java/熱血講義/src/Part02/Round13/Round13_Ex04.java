package Part02.Round13;

class A_Ex04 {
    protected int x = 100;
    protected int y = 200;
}

class B_Ex04 extends A_Ex04 {
    private int r = 300;
    protected void disp() {
        System.out.println("x = " + super.x);
        System.out.println("x = " + super.y);
        System.out.println("x = " + this.r);
    }
}

public class Round13_Ex04 {
    public static void main(String[] args) {
        B_Ex04 bp = new B_Ex04();
        bp.disp();
    }
}
