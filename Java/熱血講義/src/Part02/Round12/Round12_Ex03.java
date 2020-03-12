package Part02.Round12;

class Outer2 {
    private static int x = 100;
    static class Inner2 {
        private int y = 200;
        protected void aaa() {
            System.out.println("x = " + x);
            System.out.println("x = " + y);
        }
    }
}

public class Round12_Ex03 {
    public static void main(String[] args) {
        Outer2.Inner2 oi = new Outer2.Inner2();
        oi.aaa();
    }
}
