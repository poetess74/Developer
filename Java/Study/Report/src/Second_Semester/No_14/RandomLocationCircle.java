package Second_Semester.No_14;

import javax.swing.*;
import java.awt.*;

public class RandomLocationCircle extends JFrame {
	RandomLocationCircle() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setContentPane(new CirclePanel());
		setSize(350, 350);
		setVisible(true);
	}
	class CirclePanel extends JPanel implements Runnable {
		private int x = 100, y = 100;
		public CirclePanel() { new Thread(this).start(); }
		public void paintComponent(Graphics g) {
			super.paintComponent(g);
			g.setColor(Color.MAGENTA);
			g.drawOval(x, y, 50, 50);
		}
		public void run() {
			while(true) {
				try {
					Thread.sleep(500);
				} catch(InterruptedException e) { return; }
				x = (int)(Math.random() * (this.getWidth() - 50));
				y = (int)(Math.random() * (this.getHeight() - 50));
				repaint();
			}
		}
	}

	public static void main(String[] args) { new RandomLocationCircle(); }
}
