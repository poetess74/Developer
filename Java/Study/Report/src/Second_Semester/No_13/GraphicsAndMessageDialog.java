package Second_Semester.No_13;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class GraphicsAndMessageDialog extends JFrame {
	JTextField input = new JTextField(8);
	JButton button = new JButton("승인");
	GraphicsAndMessageDialog() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setContentPane(new MyPanel());
		Container container = getContentPane();
		container.add(input);
		container.add(button);
		button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				JOptionPane.showMessageDialog(null, "입력한 내용: " + input.getText(), "내용 확인", JOptionPane.INFORMATION_MESSAGE);
			}
		});
		setSize(300, 400);
		setVisible(true);
	}

	class MyPanel extends JPanel {
		private ImageIcon icon = new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter11/back.jpg");
		private Image image = icon.getImage();
		public void paintComponent(Graphics graphics) {
			super.paintComponent(graphics);
			graphics.drawImage(image, 0, 0, getWidth(), getHeight(), this);
		}
	}
	public static void main(String[] args) { new GraphicsAndMessageDialog(); }
}
