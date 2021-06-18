package Second_Semester.No_11;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class RadioButtonEx extends JFrame {
	private JRadioButton[] fruits = new JRadioButton[3];
	private String[] names = {"사과", "배", "체리"};
	private JLabel selectedItem = new JLabel("선택된 아이템 출력");

	RadioButtonEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());
		ButtonGroup group = new ButtonGroup();
		MyItemListener listener = new MyItemListener();
		for(int i = 0; i < fruits.length; i++) {
			fruits[i] = new JRadioButton(names[i]);
			fruits[i].addItemListener(listener);
			if (i == 2) { fruits[2].setSelected(true); }
			group.add(fruits[i]);
			container.add(fruits[i]);
		}
		container.add(selectedItem);
		setSize(200, 150);
		setVisible(true);
	}

	class MyItemListener implements ItemListener {
		public void itemStateChanged(ItemEvent e) {
			JRadioButton button = (JRadioButton)e.getSource();
			selectedItem.setText("선택된 아이템: " + button.getText());
		}
	}

	public static void main(String[] args) { new RadioButtonEx(); }
}
