package Homework.No_5;

class Card {
    private String kind;
    private int num;
    public static int width, height;
    public void showInfo() { System.out.println(kind + "숫자 : " + num); }
    public static void showSize() { System.out.println("카드 사이즈 : " + width + " x " + height); }
    public static void setSize(int w, int h) {
        width = w; height = h;
        showSize();
    }

    public String getKind() { return kind; }
    public void setKind(String kind) { this.kind = kind; }
    public int getNum() { return num; }
    public void setNum(int num) { this.num = num; }
}

public class CardTest {
    public static void main(String[] args) {
        Card.showSize();
        Card card1 = new Card(); Card card2 = new Card();
        card1.setKind("Heart"); card1.setNum(7);
        card2.setKind("Spade"); card2.setNum(4);
        card1.showInfo(); card1.showSize();
        card2.showInfo(); card2.showSize();
        System.out.println("카드 사이즈 변경");
        Card.setSize(50, 80);
    }
}
