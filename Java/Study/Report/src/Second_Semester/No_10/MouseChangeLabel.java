package Second_Semester.No_10;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class MouseChangeLabel extends JFrame {
	JLabel label = new JLabel("자기야");
	MouseChangeLabel() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());
		Action action = new Action();
		label.addMouseListener(action);
		label.addMouseMotionListener(action);
		container.add(label);
		setSize(300, 200);
		setVisible(true);
	}

	class Action extends MouseAdapter {
		public void mouseEntered(MouseEvent e) {
			label.setText("사랑해");
		}
		public void mouseExited(MouseEvent e) {
			label.setText("자기야");
		}
	}

	public static void main(String[] args) { new MouseChangeLabel(); }
}
