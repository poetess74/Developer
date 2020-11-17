package Second_Semester.No_12;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class FileDialogEx extends JFrame {
	JLabel path = new JLabel("선택한 파일 위치 출력", SwingConstants.CENTER);
	FileDialogEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		JPanel panel = new JPanel();
		panel.setBackground(Color.CYAN);
		JButton open = new JButton("열기");
		JButton save = new JButton("저장");
		MyAction action = new MyAction();
		open.addActionListener(action);
		save.addActionListener(action);
		panel.add(open);
		panel.add(save);
		setSize(300, 300);
		container.add(panel, BorderLayout.NORTH);
		container.add(path);
		setVisible(true);
	}
	void DirOpen() {
		FileDialog load = new FileDialog(this, "열기모드");
		load.setDirectory("/Users/hm/Documents/Dev/Java/Study/Report");
		load.setVisible(true);
		String fileDir = load.getDirectory();
		String fileName = load.getFile();
		path.setText(fileDir + fileName);
	}
	void DirSave() {
		FileDialog save = new FileDialog(this, "저장모드");
		save.setDirectory("/Users/hm/Documents/Dev/Java/Study/Report");
		save.setVisible(true);
		String fileDir = save.getDirectory();
		String fileName = save.getFile();
		path.setText(fileDir + fileName);
	}
	class MyAction implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			switch(button.getText()) {
				case "열기": DirOpen(); break;
				case "저장": DirSave(); break;
			}
		}
	}

	public static void main(String[] args) { new FileDialogEx(); }
}
