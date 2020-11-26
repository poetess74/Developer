package Second_Semester.No_13;

import javax.swing.*;
import java.awt.*;


public class AutoTerminated5Sec extends JFrame {
	AutoTerminated5Sec() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		getContentPane().setBackground(Color.YELLOW);

		ColorChanger thread = new ColorChanger();
		setSize(250, 150);
		thread.start();
		setVisible(true);
	}

	class ColorChanger extends Thread {
		public void run() {
			try {
				setTitle("[김형민] 실행시작");
				Thread.sleep(5000);
				getContentPane().setBackground(Color.BLUE);
				setTitle("[김형민] 실행종료");
			} catch(InterruptedException e) { return; }
		}
	}

	public static void main(String[] args) { new AutoTerminated5Sec(); }
}
