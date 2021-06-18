package Part02.Round13;

class A4 {
    int x = 100;
}

class B4 extends A4 {
    int x = 200;
}

public class Round13_Ex09 {
    public static void main(String[] args) {
        A4 ap = new B4();
        System.out.println("x = " + ap.x);
    }
}
