package Part02.Round12;

public class Round12_Ex06 {
    public static void main(String[] args) {
        final int x = 100;
        class Inner5 {
            int y = 200;
            protected void aaa() {
                System.out.println("x = " + x);
                System.out.println("y = " + y);
            }
        }
        Inner5 in = new Inner5();
        in.aaa();
    }
}
