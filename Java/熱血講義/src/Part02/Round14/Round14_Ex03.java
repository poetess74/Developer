package Part02.Round14;

interface A3 {
    int x = 100;
    class B3 {
        private int y;
        public B3() {
            this.y = 200;
        }
        void disp() {
            System.out.println("x = " + x);
            System.out.println("y = " + this.y);
        }
    }
}
public class Round14_Ex03 {
    public static void main(String[] args) {
        A3.B3 bp = new A3.B3();
        bp.disp();
    }
}
