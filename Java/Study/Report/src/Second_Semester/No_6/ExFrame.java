package Second_Semester.No_6;

import javax.swing.*;

public class ExFrame extends JFrame {
	public ExFrame() {
		setTitle("[김형민] GUI 프레임 예제");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(400, 200);
		setVisible(true);
	}

	public static void main(String[] args) {
		new ExFrame();
	}
}
