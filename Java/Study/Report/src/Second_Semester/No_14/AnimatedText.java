package Second_Semester.No_14;

import javax.swing.*;
import java.awt.*;

public class AnimatedText extends JFrame {
	AnimatedText() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());
		container.add(new WalkingLabel("나는 당신을 사랑합니다."));
		setSize(350, 350);
		setVisible(true);
	}
	class WalkingLabel extends JLabel implements Runnable {
		private String text;
		private int count = 1;
		public WalkingLabel(String text) {
			this.text = text;
			new Thread(this).start();
		}
		public void run() {
			while(true) {
				try {
					Thread.sleep(500);
				} catch(InterruptedException e) { return; }
				String str = text.substring(0, count);
				setText(str);
				count %= text.length();
				count++;
			}
		}
	}

	public static void main(String[] args) { new AnimatedText(); }
}
