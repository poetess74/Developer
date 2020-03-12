package Part02.Round13;

class A2 {
    protected void disp() {
        System.out.println("A2 클래스");
    }
}

class B2 extends A2 {
    protected void disp() {
        super.disp();
        System.out.println("B2 클래스");
    }
}

public class Round13_Ex06 {
    public static void main(String[] args) {
        B2 bp = new B2();
        bp.disp();
    }
}
