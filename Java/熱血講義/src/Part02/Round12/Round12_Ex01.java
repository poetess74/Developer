package Part02.Round12;

class Outer {
    private int x = 100;
        protected void aaa() {
            System.out.println("x = " + x);
            Inner in = new Inner();
            System.out.println("y = " + in.y);
        }
    class Inner {
        private int y = 200;
    }
}
public class Round12_Ex01 {
    public static void main(String[] args) {
        Outer ot = new Outer();
        Outer.Inner oi = ot.new Inner();
        ot.aaa();
    }
}
