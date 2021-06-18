package Second_Semester.No_7;

import javax.swing.*;
import java.awt.*;

public class ExContainerComponent extends JFrame {
	public ExContainerComponent() {
		setTitle("[김형민]컨테이너&컴포넌트 예제");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container contentPane = getContentPane();
		contentPane.setLayout(null);
		contentPane.setBackground(Color.LIGHT_GRAY);

		LeftPanel leftPanel = new LeftPanel();
		leftPanel.setSize(140, 150);
		leftPanel.setLocation(10, 10);
		contentPane.add(leftPanel);

		RightPanel rightPanel = new RightPanel();
		rightPanel.setSize(140, 150);
		rightPanel.setLocation(170, 10);
		contentPane.add(rightPanel);

		JButton button = new JButton("OK");
		button.setLocation(130, 170);
		button.setSize(70, 30);
		contentPane.add(button);

		setSize(350, 250);
		setVisible(true);
	}
	class LeftPanel extends JPanel {
		LeftPanel() {
			setBackground(Color.YELLOW);
			add(new JLabel("Type ID"));
			add(new JTextField(10));
			add(new JLabel("Type Password"));
			add(new JTextField(10));
		}
	}
	class RightPanel extends JPanel {
		RightPanel() {
			setBackground(Color.GREEN);
			add(new JLabel("좋아하는 프로그램"));
			add(new JCheckBox("Java 프로그램"));
			add(new JCheckBox("C++ 프로그램"));
		}
	}

	public static void main(String[] args) {
		new ExContainerComponent();
	}
}
