package Part02.Round11;

public class Round11_Ex01 {
    private int x;
    private int y;
    private Round11_Ex01() {
        x = 0;
        y = 0;
    }
    private Round11_Ex01(int a, int b) {
        x = a;
        y = b;
    }
    private void printMessage() {
        System.out.println("x = " + x + ", y = " + y);
    }

    public static void main(String[] args) {
        Round11_Ex01 rd = new Round11_Ex01(100, 200);
        Round11_Ex01 rd1 = new Round11_Ex01(50, 60);
        rd.printMessage();
        rd1.printMessage();
    }
}
