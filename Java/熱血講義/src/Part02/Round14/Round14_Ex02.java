package Part02.Round14;

interface A2 {
    void aaa();
    abstract void bbb();
}
class B2 implements A2 {
    public void aaa() {
        System.out.println("aaa 메서드");
    }
    public void bbb() {
        System.out.println("bbb 메서드");
    }
}
public class Round14_Ex02 {
    public static void main(String[] args) {
        B2 bp = new B2();
        bp.aaa();
        bp.bbb();
    }
}
