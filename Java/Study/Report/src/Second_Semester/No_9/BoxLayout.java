package Second_Semester.No_9;

import javax.swing.*;
import java.awt.*;

public class BoxLayout extends JFrame {
	BoxLayout() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

		Container container = getContentPane();
		container.setLayout(new javax.swing.BoxLayout(container, javax.swing.BoxLayout.X_AXIS));

		for(int i = 0; i < 6; i++) {
			container.add(new JButton("버튼 " + (i + 1)));
		}

		setSize(370, 200);
		setVisible(true);
	}

	public static void main(String[] args) {
		new BoxLayout();
	}
}
