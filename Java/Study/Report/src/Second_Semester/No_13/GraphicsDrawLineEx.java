package Second_Semester.No_13;

import javax.swing.*;
import java.awt.*;

public class GraphicsDrawLineEx extends JFrame {
	GraphicsDrawLineEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setContentPane(new MyPanel());
		setSize(200, 350);
		setVisible(true);
	}

	class MyPanel extends JPanel {
		public void paintComponent(Graphics graphics) {
			super.paintComponent(graphics);
			graphics.setColor(Color.RED);
			graphics.drawLine(20, 50, 100, 100);
			graphics.setColor(Color.BLUE);
			graphics.drawString("자바가 정말 재밌다.~~", 30, 30);
			graphics.setColor(Color.GREEN);
			graphics.fillRect(10, 120, 50, 50);
			graphics.setColor(Color.BLUE);
			graphics.fillOval(10, 200, 50, 50);
		}
	}

	public static void main(String[] args) { new GraphicsDrawLineEx(); }
}
