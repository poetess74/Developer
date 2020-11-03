package Second_Semester.No_10;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class MouseMovingLabel extends JFrame {
	JLabel label = new JLabel("C");
	MouseMovingLabel() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(null);
		label.setBounds(50, 50, 50, 50);
		label.addMouseListener(new MouseAdapter() {
			public void mouseClicked(MouseEvent e) {
				int clampX = getContentPane().getWidth() - label.getWidth();
				int clampY = getContentPane().getWidth() - label.getWidth();
				label.setLocation((int)(Math.random() * clampX), (int)(Math.random() * clampY));
			}
		});
		container.add(label);
		setSize(300, 300);
		setVisible(true);
	}

	public static void main(String[] args) { new MouseMovingLabel(); }
}
