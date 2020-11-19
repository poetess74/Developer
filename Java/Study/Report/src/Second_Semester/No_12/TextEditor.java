package Second_Semester.No_12;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.*;

public class TextEditor extends JFrame {
	JTextArea input = new JTextArea();
	JScrollPane content = new JScrollPane(input);

	TextEditor() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		createMenu();
		getContentPane().add(content, BorderLayout.CENTER);
		setSize(250, 200);
		setVisible(true);
	}

	void createMenu() {
		JMenuBar menuBar = new JMenuBar();
		JMenuItem menu = new JMenuItem("저장");
		JMenu screenMenu = new JMenu("파일");
		MenuActionListener listener = new MenuActionListener();
		menu.addActionListener(listener);
		screenMenu.add(menu);
		menuBar.add(screenMenu);
		setJMenuBar(menuBar);
	}

	class MenuActionListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			String cmd = e.getActionCommand();
			if (cmd.equals("저장")) {
				String name = JOptionPane.showInputDialog(null, "저장할 파일명을 입력하세요", "입력", JOptionPane.QUESTION_MESSAGE);
				if (name == null) {
					JOptionPane.showMessageDialog(null, "파일을 저장하지 않습니다. ", "Warning", JOptionPane.WARNING_MESSAGE);
					return;
				}
				File path = new File("/Users/hm/Documents/Dev/Java/Study/Report/out/production/Report/Second_Semester/No_12/" + name);
				try {
					FileWriter writer = new FileWriter(path);
					writer.write(input.getText());
					writer.close();
					JOptionPane.showMessageDialog(null, name + "파일을 성공적으로 저장하였습니다. ", "완료", JOptionPane.INFORMATION_MESSAGE);
				} catch(IOException exception) {
					exception.printStackTrace();
					JOptionPane.showMessageDialog(null, "파일을 저장하는 도중 에러가 발생하였습니다. ", "Error", JOptionPane.ERROR_MESSAGE);
				}
			}
		}
	}

	public static void main(String[] args) { new TextEditor(); }
}
