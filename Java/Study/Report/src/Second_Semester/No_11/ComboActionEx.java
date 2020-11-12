package Second_Semester.No_11;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class ComboActionEx extends JFrame {
	String[] fruits = {"apple", "banana", "mango"};
	ImageIcon[] images = {
			new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/apple.jpg"),
			new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/banana.jpg"),
			new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/mango.jpg")
	};
	private JLabel imageLabel = new JLabel(images[0]);
	ComboActionEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());
		Toolkit tool = Toolkit.getDefaultToolkit();
		Image image = tool.getImage("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/icon1.png");
		setIconImage(image);

		JComboBox<String> comboBox = new JComboBox<>(fruits);
		container.add(comboBox);
		container.add(imageLabel);

		comboBox.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				JComboBox<String> jComboBox = (JComboBox<String>)e.getSource();
				int index = comboBox.getSelectedIndex();
				imageLabel.setIcon(images[index]);
			}
		});
		setSize(300, 250);
		setVisible(true);
		setResizable(false);
	}

	public static void main(String[] args) { new ComboActionEx(); }
}
