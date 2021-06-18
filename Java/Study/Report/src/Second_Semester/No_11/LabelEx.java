package Second_Semester.No_11;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class LabelEx extends JFrame {
	JLabel text = new JLabel("제임스 고슬링 입니더!");
	LabelEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());
		text.addMouseListener(new MouseAdapter() {
			public void mousePressed(MouseEvent e) {
				text.setText(text.getText().equals("반갑습니더!") ? "제임스 고슬링 입니더!" : "반갑습니더!");
			}
		});
		ImageIcon image = new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/gosling.jpg");
		JLabel imageLabel = new JLabel(image);
		ImageIcon icon = new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/icon.gif");
		JLabel label = new JLabel("커피한잔 하실래예, 전화주이소", icon, SwingConstants.CENTER);
		container.add(text);
		container.add(imageLabel);
		container.add(label);
		setSize(300, 500);
		setVisible(true);
	}
	public static void main(String[] args) {
		new LabelEx();
	}
}
