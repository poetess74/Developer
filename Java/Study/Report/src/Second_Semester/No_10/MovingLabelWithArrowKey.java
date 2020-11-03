package Second_Semester.No_10;

import javax.swing.*;
import java.awt.*;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

public class MovingLabelWithArrowKey extends JFrame {
	private JLabel label = new JLabel("HELLO");
	public MovingLabelWithArrowKey() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(null);
		container.addKeyListener(new MyKeyListener());
		label.setLocation(50, 50);
		label.setSize(100, 20);
		container.add(label);
		setSize(300, 300);
		setVisible(true);
		container.setFocusable(true);
		container.requestFocus();
	}

	class MyKeyListener extends KeyAdapter {
		public void keyPressed(KeyEvent e) {
			int input = e.getKeyCode();
			switch(input) {
				case KeyEvent.VK_UP:
					label.setLocation(label.getX(), label.getY() - 10); break;
				case KeyEvent.VK_DOWN:
					label.setLocation(label.getX(), label.getY() + 10); break;
				case KeyEvent.VK_LEFT:
					label.setLocation(label.getX() - 10, label.getY()); break;
				case KeyEvent.VK_RIGHT:
					label.setLocation(label.getX() + 10, label.getY()); break;
			}
		}
	}

	public static void main(String[] args) { new MovingLabelWithArrowKey(); }
}
