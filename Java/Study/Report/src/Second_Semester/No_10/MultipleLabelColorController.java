package Second_Semester.No_10;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class MultipleLabelColorController extends JFrame {
	private JLabel[] labels = new JLabel[12];
	public MultipleLabelColorController() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new GridLayout(4, 3));
		for(int i = 0; i < labels.length; i++) {
			labels[i] = new JLabel(Integer.toString(i));
			labels[i].setBackground(Color.WHITE);
			labels[i].setOpaque(true);
			labels[i].addMouseListener(new MouseAdapter() {
				public void mouseClicked(MouseEvent e) {
					int red = (int)(Math.random() * 256);
					int green = (int)(Math.random() * 256);
					int blue = (int)(Math.random() * 256);
					JLabel label = (JLabel)e.getSource();
					label.setBackground(new Color(red, green, blue));
				}
			});
			container.add(labels[i]);
		}
		setSize(300, 300);
		setVisible(true);
	}

	public static void main(String[] args) { new MultipleLabelColorController(); }
}
