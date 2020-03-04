package Round05;

public class Round05_Ex05 {
    private static boolean aaa() {
        System.out.println("AAA");
        return true;
    }
    private static boolean bbb() {
        System.out.println("BBB");
        return false;
    }
    public static void main(String[] args) {
        boolean b = aaa() | bbb();
        System.out.println("b = " + b);
    }
}
