package Part02.Round13;

class UpperClass {
    int x, y;
    protected UpperClass() {
        x = 10;
        y = 20;
    }
    protected UpperClass(int x) {
        this();
        this.x = x;
    }
    protected UpperClass(int x, int y) {
        this(x);
        this.y = y;
    }
}
class LowerClass extends UpperClass {
    int r;
    protected LowerClass() {
        super();
        r = 30;
    }
    protected LowerClass(int x) {
        super(x);
        r = 30;
    }
    protected LowerClass(int x, int y) {
        super(x, y);
        r = 30;
    }
    protected LowerClass(int x, int y, int r) {
        super(x, y);
        this.r = r;
    }
}
public class Round13_Ex03 {
    public static void main(String[] args) {
        LowerClass lc = new LowerClass();
        LowerClass lc1 = new LowerClass(50);
        LowerClass lc2 = new LowerClass(50, 100);
        LowerClass lc3 = new LowerClass(50, 100, 150);
        System.out.println(lc.x + ", " + lc.y + ", " + lc.r);
        System.out.println(lc1.x + ", " + lc1.y + ", " + lc1.r);
        System.out.println(lc2.x + ", " + lc2.y + ", " + lc2.r);
        System.out.println(lc3.x + ", " + lc3.y + ", " + lc3.r);
    }
}
