package Second_Semester.No_11;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class CheckBoxItemEventEx extends JFrame {
	JCheckBox[] fruits = new JCheckBox[3];
	String[] names = {"사과", "배", "체리"};
	JLabel sumLabel;

	CheckBoxItemEventEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.setLayout(new FlowLayout());
		container.add(new JLabel("사과 100원, 배 500원, 체리 20,000원"));
		MyItemListener listener = new MyItemListener();
		for(int i = 0; i < fruits.length; i++) {
			fruits[i] = new JCheckBox(names[i]);
			fruits[i].setBorderPainted(true);
			container.add(fruits[i]);
			fruits[i].addItemListener(listener);
		}
		sumLabel = new JLabel("현재 0원입니다. ");
		container.add(sumLabel);
		setSize(250, 200);
		setVisible(true);
	}

	class MyItemListener implements ItemListener {
		private int sum = 0;
		public void itemStateChanged(ItemEvent e) {
			if(e.getStateChange() == ItemEvent.SELECTED) {
				if (e.getItem() == fruits[0]) {
					sum += 100;
				} else if (e.getItem() == fruits[1]) {
					sum += 500;
				} else {
					sum += 20000;
				}
			} else {
				if (e.getItem() == fruits[0]) {
					sum -= 100;
				} else if (e.getItem() == fruits[1]) {
					sum -= 500;
				} else {
					sum -= 20000;
				}
			}
			sumLabel.setText("현재 " + sum + "원 입니다. ");
		}
	}

	public static void main(String[] args) { new CheckBoxItemEventEx(); }
}
