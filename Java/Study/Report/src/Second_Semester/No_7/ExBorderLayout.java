package Second_Semester.No_7;

import javax.swing.*;
import java.awt.*;

public class ExBorderLayout extends JFrame {
	ExBorderLayout() {
		setTitle("BorderLayout 예제");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new BorderLayout(30, 20));

		JPanel panel = new JPanel();
		panel.setLayout(new FlowLayout());
		panel.add(new JButton("div"));
		panel.add(new JButton("패널Btn"));

		container.add(new JButton("Calculate"), BorderLayout.CENTER);
		container.add(new JButton("add"), BorderLayout.NORTH);
		container.add(new JButton("sub"), BorderLayout.SOUTH);
		container.add(new JButton("mul"), BorderLayout.EAST);
		container.add(panel, BorderLayout.WEST);

		setSize(300, 200);
		setVisible(true);
	}

	public static void main(String[] args) {
		new ExBorderLayout();
	}
}
