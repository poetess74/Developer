package Second_Semester.Practice.No_11;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class ImageSelector extends JFrame {
	final String[] characters = {"원더우먼", "배트맨", "스파이더맨", "슈퍼맨"};
	JComboBox<String> imageName = new JComboBox<>(characters);
	int selectedIndex = 2;
	Label title = new Label(characters[2]);
	ImageIcon[] images = {
			new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/image1.jpg"),
			new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/image2.jpg"),
			new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/image0.jpg"),
			new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/image3.jpg")
	};
	JLabel viewer = new JLabel(images[selectedIndex]);

	TopPanel Top = new TopPanel();
	CenterPanel Center = new CenterPanel();
	BottomPanel Bottom = new BottomPanel();

	public ImageSelector() {
		setTitle("[김형민] Report1");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.add(Top, BorderLayout.NORTH);
		container.add(Center, BorderLayout.CENTER);
		container.add(Bottom, BorderLayout.SOUTH);
		setSize(300, 500);
		setVisible(true);
	}

	class TopPanel extends JPanel {
		public TopPanel() {
			JLabel label = new JLabel("메뉴 직접 선택");
			imageName.setSelectedIndex(2);
			imageName.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					selectedIndex = imageName.getSelectedIndex();
					viewer.setIcon(images[selectedIndex]);
					title.setText(characters[selectedIndex]);
				}
			});
			setBackground(Color.CYAN);
			add(label);
			add(imageName);
		}
	}

	class CenterPanel extends JPanel {
		public CenterPanel() {
			setBackground(Color.WHITE);
			add(title);
			add(viewer);
		}
	}

	class BottomPanel extends JPanel {
		public BottomPanel() {
			ImageIcon left = new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/left.png");
			ImageIcon right = new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/right.png");
			JButton previous = new JButton(left);
			JButton forward = new JButton(right);
			previous.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					selectedIndex = selectedIndex <= 0 ? selectedIndex = 3 : selectedIndex - 1;
					imageName.setSelectedIndex(selectedIndex);
					viewer.setIcon(images[selectedIndex]);
					title.setText(characters[selectedIndex]);
				}
			});
			forward.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					selectedIndex = selectedIndex >= 3 ? selectedIndex = 0 : selectedIndex + 1;
					imageName.setSelectedIndex(selectedIndex);
					viewer.setIcon(images[selectedIndex]);
					title.setText(characters[selectedIndex]);
				}
			});
			setBackground(Color.LIGHT_GRAY);
			add(previous);
			add(forward);
		}
	}

	public static void main(String[] args) {
		new ImageSelector();
	}
}
