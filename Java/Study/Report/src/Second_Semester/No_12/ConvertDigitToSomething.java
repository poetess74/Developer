package Second_Semester.No_12;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class ConvertDigitToSomething extends JFrame {
	private JRadioButton[] convertTo = new JRadioButton[4];
	private String[] radioString = {"decimal", "binary", "octal", "hex"};
	private ButtonGroup group = new ButtonGroup();
	private Container container = getContentPane();
	private TextField original = new TextField(8);
	private TextField converted = new TextField(8);

	ConvertDigitToSomething() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		MyItemListener listener = new MyItemListener();
		JPanel up = new JPanel();
		JPanel down = new JPanel();
		up.add(original);
		up.add(new Label("→"));
		up.add(converted);
		for(int i = 0; i < convertTo.length; i++) {
			convertTo[i] = new JRadioButton(radioString[i]);
			convertTo[i].addItemListener(listener);
			group.add(convertTo[i]);
			down.add(convertTo[i]);
		}
		container.add(up, BorderLayout.NORTH);
		container.add(down, BorderLayout.CENTER);
		setSize(300, 150);
		setVisible(true);
	}

	class MyItemListener implements ItemListener {
		public void itemStateChanged(ItemEvent e) {
			if (e.getStateChange() != ItemEvent.SELECTED) { return; }
			int convert;

			try {
				if(e.getItem() == convertTo[0]) {
					converted.setText(original.getText());
				} else if(e.getItem() == convertTo[1]) {
					convert = Integer.parseInt(original.getText());
					converted.setText(Integer.toBinaryString(convert));
				} else if(e.getItem() == convertTo[2]) {
					convert = Integer.parseInt(original.getText());
					converted.setText(Integer.toOctalString(convert));
				} else if(e.getItem() == convertTo[3]) {
					convert = Integer.parseInt(original.getText());
					converted.setText(Integer.toHexString(convert));
				}
			} catch(Exception exception) {
				JOptionPane.showMessageDialog(null, "숫자를 입력해 주세요", "에러", JOptionPane.ERROR_MESSAGE);
				original.setText("");
				group.clearSelection();
			}
		}
	}

	public static void main(String[] args) { new ConvertDigitToSomething(); }
}
