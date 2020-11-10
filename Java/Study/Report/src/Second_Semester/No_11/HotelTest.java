package Second_Semester.No_11;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class HotelTest extends JFrame {
	JButton[] buttons = new JButton[5];
	Panel[] panels = new Panel[3];
	JLabel title = new JLabel("자바 호텔에 오신것을 환영합니다. 숙박일수를 선택하세요. ");
	JLabel day = new JLabel("숙박일수: 0일");
	Font font = new Font("Arial", Font.BOLD, 20);
	HotelTest() {
		super("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new GridLayout(3, 1));
		for(int i = 0; i < panels.length; i++) { panels[i] = new Panel(); }
		title.setFont(font);
		day.setFont(font);
		panels[0].add(title);
		for(int i = 0; i < buttons.length; i++) {
			buttons[i] = new JButton((i + 1) + "일");
			buttons[i].addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					JButton button = (JButton)e.getSource();
					day.setText("숙박일수: " + button.getText());
				}
			});
			panels[1].add(buttons[i]);
		}
		panels[2].add(day);
		for(int i = 0; i < 3; i++) {
			container.add(panels[i]);
		}
		setSize(500, 250);
		setVisible(true);
	}

	public static void main(String[] args) {
		new HotelTest();
	}
}

