package Second_Semester.No_6;

class MyGeneric<W> {
	private W x;
	public MyGeneric(W x) { this.x = x; }
	public W take() { return x; }
	public boolean compare(W a) {
		return x.equals(a);
	}
}
public class GenTest {
	public static void main(String[] args) {
		MyGeneric<String> myGeneric = new MyGeneric<>("aaa");
		System.out.println(myGeneric.take());
		System.out.println(myGeneric.compare("Bbb") ? "같음" : "다름");
		System.out.println(myGeneric.compare("aaa") ? "같음" : "다름");
	}
} //김형민
