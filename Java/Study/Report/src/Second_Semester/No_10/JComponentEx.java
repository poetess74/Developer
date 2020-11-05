package Second_Semester.No_10;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class JComponentEx extends JFrame {
	JComponentEx() {
		super("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());
		JButton button1 = new JButton("Magenta/Yellow Button");
		JButton button2 = new JButton("Disabled Button");
		JButton button3 = new JButton("getX(), getY()");

		button1.setBackground(Color.YELLOW);
		button1.setForeground(Color.MAGENTA);
		button1.setFont(new Font("Arial", Font.ITALIC, 20));
		button2.setEnabled(false);
		button3.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				JButton button = (JButton)e.getSource();
				setTitle(button.getX() + ", " + button.getY());
			}
		});
		button1.setOpaque(true);
		container.add(button1);
		container.add(button2);
		container.add(button3);
		setSize(260, 200);
		setVisible(true);
	}

	public static void main(String[] args) {
		new JComponentEx();
	}
}
