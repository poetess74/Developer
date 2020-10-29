package Second_Semester.No_9;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

public class MouseMovingString extends JFrame {
	JLabel label = new JLabel("Hello");
	MouseMovingString() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(null);
		label.setSize(50, 20);
		label.setLocation(30, 30);
		container.add(label);
		container.addMouseListener(new Action());
		setSize(300, 300);
		setVisible(true);
	}

	class Action extends MouseAdapter {
		public void mousePressed(MouseEvent e) {
			int mousePosX = e.getX();
			int mousePosY = e.getY();
			label.setLocation(mousePosX, mousePosY);
		}
	}

	public static void main(String[] args) { new MouseMovingString(); }
}
