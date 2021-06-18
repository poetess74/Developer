package Second_Semester.No_13;

import javax.swing.*;
import java.awt.event.*;
import java.util.Random;

public class VibratingFrame extends JFrame implements Runnable {
	Thread thread;
	VibratingFrame() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(200, 300);
		setLocation(300, 300);
		setVisible(true);
		getContentPane().addMouseListener(new MouseAdapter() {
			public void mousePressed(MouseEvent e) {
				if (!thread.isAlive()) { return; }
				thread.interrupt();
			}
		});
		thread = new Thread(this);
		thread.start();
	}
	public void run() {
		Random position = new Random();
		while (true) {
			try {
				Thread.sleep(20);
			} catch(InterruptedException e) { return; }
			int x = getX() + position.nextInt() % 5;
			int y = getY() + position.nextInt() % 5;
			setLocation(x, y);
		}
	}

	public static void main(String[] args) { new VibratingFrame(); }
}
