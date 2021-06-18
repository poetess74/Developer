package Second_Semester.No_12;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class BackgroundColorChanger extends JFrame {
	private JRadioButton[] radios = new JRadioButton[2];
	private String[] radioString = {"Red", "Blue"};
	private Container container = getContentPane();

	BackgroundColorChanger() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		container.setLayout(new FlowLayout());
		ButtonGroup group = new ButtonGroup();
		MyItemListener listener = new MyItemListener();
		for(int i = 0; i < radios.length; i++) {
			radios[i] = new JRadioButton(radioString[i]);
			radios[i].addItemListener(listener);
			if (i == 0) { radios[0].setSelected(true); }
			group.add(radios[i]);
			container.add(radios[i]);
		}
		setSize(200, 150);
		setVisible(true);
	}

	class MyItemListener implements ItemListener {
		public void itemStateChanged(ItemEvent e) {
			if (e.getStateChange() != ItemEvent.SELECTED) { return; }
			container.setBackground(e.getItem() == radios[0] ? Color.RED : Color.BLUE);
		}
	}

	public static void main(String[] args) { new BackgroundColorChanger(); }
}
