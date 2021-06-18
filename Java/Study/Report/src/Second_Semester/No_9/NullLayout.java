package Second_Semester.No_9;

import javax.swing.*;
import java.awt.*;

public class NullLayout extends JFrame {
	NullLayout() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(300, 300);

		Container container = getContentPane();
		container.setLayout(null);

		for(int i = 0; i < 20; i++) {
			JLabel label = new JLabel(Integer.toString(i));
			label.setForeground(Color.MAGENTA);
			int x = (int)(Math.random() * (this.getWidth() - 50));
			int y = (int)(Math.random() * (this.getHeight() - 50));
			label.setLocation(x, y);
			label.setSize(20, 20);
			container.add(label);
		}
		setVisible(true);
	}

	public static void main(String[] args) {
		new NullLayout();
	}
}
