package Second_Semester.No_7;

import javax.swing.*;
import java.awt.*;

public class ExGridLayout extends JFrame {
	public ExGridLayout() {
		super("GridLayout 예제");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new GridLayout(2, 5));

		JPanel panel = new JPanel();
		panel.setLayout(new GridLayout(3, 1));
		panel.add(new JButton("P1"));
		panel.add(new JButton("P2"));
		panel.add(new JButton("P3"));

		for(int i = 0; i < 10; i++) {
			String label = Integer.toString(i);
			JButton button = new JButton(label);
			container.add(i == 8 ? panel : button);
		}
		setSize(500, 200);
		setVisible(true);
	}

	public static void main(String[] args) {
		new ExGridLayout();
	}
}
