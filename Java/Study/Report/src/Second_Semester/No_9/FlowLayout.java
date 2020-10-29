package Second_Semester.No_9;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class FlowLayout extends JFrame {
	private JButton button;
	private JLabel label;
	FlowLayout() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new java.awt.FlowLayout());
		button = new JButton("=");
		label = new JLabel("0");

		container.add(new JLabel("100 + 200"));
		container.add(button);
		container.add(label);
		button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				label.setText("300");
			}
		});

		setSize(300, 80);
		setVisible(true);
	}

	public static void main(String[] args) {
		new FlowLayout();
	}
}
