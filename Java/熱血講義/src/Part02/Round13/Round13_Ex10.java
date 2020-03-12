package Part02.Round13;

class A5 {
    protected void aaa() {
        System.out.println("aaa");
    }
    protected void bbb() {
        System.out.println("bbb");
    }
}

class B5 extends A5 {
    protected void bbb() {
        System.out.println("bbb1");
    }
    protected void ccc() {
        System.out.println("ccc");
    }
}

public class Round13_Ex10 {
    public static void main(String[] args) {
        A5 ap = new B5();
        ap.aaa();
        ap.bbb();
        //ap.ccc();
    }
}
