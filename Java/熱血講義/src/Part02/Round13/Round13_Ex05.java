package Part02.Round13;

class A1 {
    protected int x = 100;
}

class B1 extends A1 {
    private int x = 200;
    protected void disp() {
        System.out.println("A1 클래스의 x = " + super.x);
        System.out.println("B1 클래스의 x = " + this.x);
    }
}

public class Round13_Ex05 {
    public static void main(String[] args) {
        B1 bp = new B1();
        bp.disp();
    }
}
