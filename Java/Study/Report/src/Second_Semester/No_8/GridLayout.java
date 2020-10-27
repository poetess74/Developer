package Second_Semester.No_8;

import javax.swing.*;
import java.awt.*;

public class GridLayout extends JFrame {
	public GridLayout() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new java.awt.GridLayout(4, 4));

		JLabel[] labels = new JLabel[16];
		Color[] colors = {
				Color.RED, Color.ORANGE, Color.YELLOW, Color.GREEN, Color.CYAN,
				Color.BLUE, Color.MAGENTA, Color.GRAY, Color.PINK, Color.LIGHT_GRAY
		};

		for(int i = 0; i < labels.length; i++) {
			labels[i] = new JLabel(Integer.toString(i));
			labels[i].setOpaque(true);
			labels[i].setBackground(colors[i % 10]);
			labels[i].setHorizontalAlignment(JLabel.CENTER);
			container.add(labels[i]);
		}

		setSize(300, 200);
		setVisible(true);
	}

	public static void main(String[] args) {
		new GridLayout();
	}
}
