package Second_Semester.No_10;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class LabelFontsizeController extends JFrame {
	private JLabel label = new JLabel("Hello");
	public LabelFontsizeController() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());
		container.addKeyListener(new MyKeyListener());
		label.setFont(new Font("Arial", Font.PLAIN, 10));
		container.add(label);
		setSize(300, 300);
		setVisible(true);
		container.setFocusable(true);
		container.requestFocus();
	}

	class MyKeyListener extends KeyAdapter {
		public void keyPressed(KeyEvent e) {
			Font font = label.getFont();
			int size = font.getSize(), input = e.getKeyCode();
			switch(input) {
				case KeyEvent.VK_UP, KeyEvent.VK_PLUS:
					label.setFont(new Font("Arial", Font.PLAIN, size + 5)); break;
				case KeyEvent.VK_DOWN, KeyEvent.VK_MINUS:
					if (size > 10) {
						label.setFont(new Font("Arial", Font.PLAIN, size - 5));
					}
					break;
			}
		}
	}

	public static void main(String[] args) { new LabelFontsizeController(); }
}
