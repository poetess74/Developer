package Second_Semester.No_3;

class Card {
	private String kind;
	private int num;
	public static int width, height;

	public void showInfo() {
		System.out.printf("무늬 : %s 숫자 : %d", kind, num);
	}
	public void showSize() {
		System.out.printf("카드Size : %dX%d\n", width, height);
	}
	public static void setSize(int _width, int _height) {
		width = _width; height = _height;
		System.out.printf("카드 사이즈 변경!!\n");
	}
	public int getNum() { return num; }
	public void setNum(int num) { this.num = num; }
	public String getKind() { return kind; }
	public void setKind(String kind) { this.kind = kind; }
}

public class CardTest {
	public static void main(String[] args) {
		Card.width = 100; Card.height = 250;
		System.out.println("카드의 폭은 " + Card.width + ", 높이는 " + Card.height);
		Card card = new Card();
		Card card1 = new Card();
		card.setKind("Heart"); card.setNum(7);
		card1.setKind("Spade"); card1.setNum(4);
		System.out.print("c1은 "); card.showInfo(); card.showSize();
		System.out.print("c2는 "); card1.showInfo(); card1.showSize();
		Card.setSize(50, 80);
		System.out.print("c1은 "); card.showInfo(); card.showSize();
		System.out.print("c2는 "); card1.showInfo(); card1.showSize();
	}
}
