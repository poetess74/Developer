package Part02.Round13;

class A6 {
    private int x = 100;
    private int y = 200;
    protected void setX(int x) {
        this.x = x;
    }
    protected void setY(int y) {
        this.y = y;
    }
    protected void disp() {
        System.out.println(x + ", " + y);
    }
}

class B6 extends A6 {
    private int y = 300;
    private int z = 400;
    protected void setY(int y) {
        this.y = y;
    }
    protected void setZ(int z) {
        this.z = z;
    }
    protected void disp() {
        super.disp();
        System.out.println(y + ", " + z);
    }
}

public class Round13_Ex11 {
    public static void main(String[] args) {
        A6 ap = new B6();
        ap.disp();
        System.out.println();
        ap.setX(1);
        ap.disp();
        System.out.println();
        ap.setY(2);
        ap.disp();
        //ap.setZ(3);
        //ap.disp();
    }
}
