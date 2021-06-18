package Part02.Round14;

interface A1 {
    int w = 10;
    static int x = 20;
    final int y = 30;
    static final int z = 40;
}

public class Round14_Ex01 {
    public static void main(String[] args) {
        //A1 ap = new A1();
        //A1.w = 100;
        System.out.println("w = " + A1.w);
        System.out.println("w = " + A1.x);
        System.out.println("w = " + A1.y);
        System.out.println("w = " + A1.z);
    }
}
