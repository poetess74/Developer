package Second_Semester.No_13;

import javax.swing.*;
import java.awt.*;

public class GraphicsDrawImage extends JFrame {
	GraphicsDrawImage() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setContentPane(new MyPanel());
		setSize(500, 500);
		setVisible(true);
	}

	class MyPanel extends JPanel {
		private ImageIcon icon = new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter11/image0.jpg");
		private Image image = icon.getImage();
		public void paintComponent(Graphics graphics) {
			super.paintComponent(graphics);
//			graphics.setClip(100, 200, 150, 150);
			graphics.drawImage(image, 0, 0, getWidth(), getHeight(), this);
//			graphics.drawImage(image, 20, 20, this);
		}
	}
	public static void main(String[] args) { new GraphicsDrawImage(); }
}
