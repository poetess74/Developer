package Second_Semester.No_12;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class OptionPaneEx extends JFrame {
	OptionPaneEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		setSize(500, 200);
		container.add(new MyPanel(), BorderLayout.NORTH);
		setVisible(true);
	}

	class MyPanel extends JPanel {
		private JButton input = new JButton("Input Name");
		private JTextField textField = new JTextField(10);
		private JButton confirm = new JButton("Confirm");
		private JButton message = new JButton("Message");

		MyPanel() {
			setBackground(Color.LIGHT_GRAY);
			add(input);
			add(confirm);
			add(message);
			add(textField);
			input.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					String name = JOptionPane.showInputDialog("이름을 입력하세요. ");
					if (name != null) { textField.setText(name); }
				}
			});
			confirm.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					int result = JOptionPane.showConfirmDialog(null, "계속할 것입니까?", "Confirm", JOptionPane.YES_NO_OPTION);
					textField.setText(result == JOptionPane.YES_OPTION ? "YES" : "NO");
				}
			});
			message.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					JOptionPane.showMessageDialog(null, "조심하세요", "Message", JOptionPane.ERROR_MESSAGE);
				}
			});
		}
	}

	public static void main(String[] args) { new OptionPaneEx(); }
}
