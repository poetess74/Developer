package Second_Semester.No_10;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class MouseEventTest extends JFrame {
	JLabel label = new JLabel("Hello");
	Container container = getContentPane();
	MouseEventTest() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		container.setLayout(null);
		Action action = new Action();
		container.addMouseListener(action);
		container.addMouseMotionListener(action);
		label.setSize(80, 20);
		label.setLocation(100, 80);
		container.add(label);
		setSize(300, 200);
		setVisible(true);
	}

	class Action extends MouseAdapter {
		public void mousePressed(MouseEvent e) {
			label.setLocation(e.getX(), e.getY());
			setTitle("mousePressed(" + e.getX() + ", " + e.getY() + ")");
		}
		public void mouseReleased(MouseEvent e) {
			label.setLocation(e.getX(), e.getY());
			setTitle("mouseReleased(" + e.getX() + ", " + e.getY() + ")");
		}
		public void mouseEntered(MouseEvent e) { container.setBackground(Color.CYAN); }
		public void mouseExited(MouseEvent e) {
			container.setBackground(Color.YELLOW);
			setTitle("mouseExited(" + e.getX() + ", " + e.getY() + ")");
		}

		public void mouseDragged(MouseEvent e) {
			label.setLocation(e.getX(), e.getY());
			setTitle("mouseDragged(" + e.getX() + ", " + e.getY() + ")");
		}
		public void mouseMoved(MouseEvent e) {
			label.setLocation(e.getX(), e.getY());
			setTitle("mouseMoved(" + e.getX() + ", " + e.getY() + ")");
		}
	}

	public static void main(String[] args) { new MouseEventTest(); }
}
