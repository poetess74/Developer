package Part02.Round12;

class Inner6 {
    int y = 200;
    protected Inner6() {
        this.disp();
    }
    protected void disp() {}
}

public class Round12_Ex07 {
    public static void main(String[] args) {
        final int x = 100;
        new Inner6() {
            protected void disp() {
                System.out.println("Default 생성자");
                System.out.println("x = " + x);
                System.out.println("y = " + y);
            }
        };
    }
}
