package Second_Semester.No_7;

import javax.swing.*;
import java.awt.*;

public class ExFlowLayout extends JFrame {
	public ExFlowLayout() {
		setTitle("[김형민] FlowLayout 예제");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setBackground(Color.DARK_GRAY);
		container.setLayout(new FlowLayout(FlowLayout.LEFT, 30, 40));
		JButton button = new JButton("버튼 클릭");
		container.add(button);
		container.add(new JButton("add"));
		container.add(new JButton("sub"));
		container.add(new JButton("mul"));
		container.add(new JButton("div"));
		setSize(300, 200);
		setVisible(true);
	}

	public static void main(String[] args) {
		new ExFlowLayout();
	}
}
