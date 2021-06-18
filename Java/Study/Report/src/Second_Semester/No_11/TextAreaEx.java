package Second_Semester.No_11;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class TextAreaEx extends JFrame {
	JTextField textField = new JTextField(20);
	JTextArea textArea = new JTextArea(7, 20);

	TextAreaEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());

		container.add(new JLabel("입력 후 <return> 키를 입력하세요"));
		container.add(textField);
		container.add(new JScrollPane(textArea));

		textField.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				JTextField textField = (JTextField)e.getSource();
				textArea.append(textField.getText() + "\n");
				textField.setText("");
			}
		});
		setSize(300, 250);
		setVisible(true);
	}

	public static void main(String[] args) { new TextAreaEx(); }
}
