package Second_Semester.No_11;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class ButtonImageEx extends JFrame {
	ButtonImageEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());
		ImageIcon normal = new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/normalIcon.gif");
		ImageIcon rollover = new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/rolloverIcon.gif");
		ImageIcon pressed = new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/pressedIcon.gif");
		JButton button = new JButton("call~~", normal);
		button.setPressedIcon(pressed);
		button.setRolloverIcon(rollover);
		button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				setTitle(getTitle().equals("[김형민]") ? "버튼이 눌려졌습니다" : "[김형민]");
			}
		});
		container.add(button);
		setSize(250, 150);
		setVisible(true);
	}
	public static void main(String[] args) {
		new ButtonImageEx();
	}
}
