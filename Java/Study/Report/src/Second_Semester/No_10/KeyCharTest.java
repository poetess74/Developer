package Second_Semester.No_10;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class KeyCharTest extends JFrame {
	private JLabel label = new JLabel("<return> 키로 배경색이 바뀝니다. ");
	public KeyCharTest() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());
		container.add(label);
		container.addKeyListener(new MyKeyListener());
		setSize(250, 150);
		setVisible(true);
		container.setFocusable(true);
		container.requestFocus();
	}

	class MyKeyListener extends KeyAdapter {
		public void keyPressed(KeyEvent e) {
			switch (e.getKeyChar()) {
				case '\n':
					int red = (int)(Math.random() * 256);
					int green = (int)(Math.random() * 256);
					int blue = (int)(Math.random() * 256);
					label.setText("r: " + red + ", g: " + green + ", b: " + blue);
					getContentPane().setBackground(new Color(red, green, blue));
					break;
				case 'q': System.exit(0);
			}
		}
	}

	public static void main(String[] args) { new KeyCharTest(); }
}
