package Second_Semester.No_14;

public class SynchronizedEx {
	public static void main(String[] args) {
		SharedPrinter printer = new SharedPrinter();
		String[] english = {
				"Wise men say, ", "only fools rush in", "But I can't help, ",
				"falling in love with you", "Shall I stay?", "Would it be a sin?",
				"If I can't help, ", "falling in love with you"
		};
		String[] korean = {
				"동해물과 백두산이 마르고 닳도록", "하느님이 보우하사 우리나라 만세", "무궁화 삼천리 화려강산",
				"대한 사람 대한으로 길이 보전하세", "남산 위에 저 소나무 철갑을 두른 듯", "바람서리 불변함은 우리기상일 세",
				"무궁화 삼천리 화려강산", "대한 사람 대한으로 길이 보전하세"
		};
		Thread thread1 = new WorkerThread(printer, english);
		Thread thread2 = new WorkerThread(printer, korean);
		thread1.start(); thread2.start();
	}
}
class SharedPrinter {
	synchronized void print(String text) {
		for(int i = 0; i < text.length(); i++) {
			System.out.print(text.charAt(i));
		}
		System.out.println();
	}
}

class WorkerThread extends Thread {
	private SharedPrinter printer;
	private String[] text;
	public WorkerThread(SharedPrinter printer, String[] text) {
		this.printer = printer; this.text = text;
	}
	public void run() {
		for(String s : text) {
			printer.print(s);
		}
	}
}
