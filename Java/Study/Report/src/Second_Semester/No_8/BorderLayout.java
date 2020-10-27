package Second_Semester.No_8;

import javax.swing.*;
import java.awt.*;

public class BorderLayout extends JFrame {
	BorderLayout() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new java.awt.BorderLayout(5, 7));

		container.add(new JButton("Center"), java.awt.BorderLayout.CENTER);
		container.add(new JButton("North"), java.awt.BorderLayout.NORTH);
		container.add(new JButton("South"), java.awt.BorderLayout.SOUTH);
		container.add(new JButton("East"), java.awt.BorderLayout.EAST);
		container.add(new JButton("West"), java.awt.BorderLayout.WEST);

		setSize(400, 200);
		setVisible(true);
	}

	public static void main(String[] args) {
		new BorderLayout();
	}
}
