package Second_Semester.No_9;

import javax.swing.*;
import java.awt.FlowLayout;
import java.awt.Container;
import java.awt.event.*;

public class IndepClassListener extends JFrame {
	IndepClassListener() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());

		JButton button = new JButton("Action");

		button.addActionListener(new Action());
		container.add(button);
		setSize(300, 300);
		setVisible(true);
	}

	class Action implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			button.setText(button.getText().equals("Action") ? "액션" : "Action");
		}
	}

	public static void main(String[] args) { new IndepClassListener(); }
}
