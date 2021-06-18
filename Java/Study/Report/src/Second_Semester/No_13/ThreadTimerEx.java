package Second_Semester.No_13;

import javax.swing.*;
import java.awt.*;

class TimerThread extends Thread {
	JLabel timerLabel;
	TimerThread(JLabel timerLabel) {
		this.timerLabel = timerLabel;
	}

	public void run() {
		int num = 0;
		while (true) {
			timerLabel.setText(Integer.toString(num));
			num++;
			try {
				Thread.sleep(1000);
			} catch(InterruptedException e) { return; }
		}

	}
}
public class ThreadTimerEx extends JFrame {
	ThreadTimerEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());

		JLabel time = new JLabel();
		time.setFont(new Font("Gothic", Font.ITALIC, 80));
		container.add(time);
		TimerThread thread = new TimerThread(time);
		setSize(250, 150);
		setVisible(true);
		thread.start();
	}

	public static void main(String[] args) { new ThreadTimerEx(); }
}
