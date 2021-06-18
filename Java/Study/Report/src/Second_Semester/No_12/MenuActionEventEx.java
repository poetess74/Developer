package Second_Semester.No_12;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class MenuActionEventEx extends JFrame {
	JLabel imageLabel = new JLabel();

	MenuActionEventEx() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		createMenu();
		getContentPane().add(imageLabel, BorderLayout.CENTER);
		setSize(250, 200);
		setVisible(true);
	}

	void createMenu() {
		JMenuBar menuBar = new JMenuBar();
		JMenuItem[] menus = new JMenuItem[4];
		String[] menuString = { "Load", "Hide", "Reshow", "Quit" };
		JMenu screenMenu = new JMenu("Screen");
		MenuActionListener listener = new MenuActionListener();
		for(int i = 0; i < menus.length; i++) {
			menus[i] = new JMenuItem(menuString[i]);
			menus[i].addActionListener(listener);
			screenMenu.add(menus[i]);
		}
		menuBar.add(screenMenu);
		setJMenuBar(menuBar);
	}

	class MenuActionListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			String cmd = e.getActionCommand();
			switch(cmd) {
				case "Load":
					if(imageLabel.getIcon() != null) {
						return;
					}
					imageLabel.setIcon(new ImageIcon("/Users/hm/Documents/Dev/Java/Study/Report/src/Second_Semester/images/Chapter10/img0.jpg"));
					break;
				case "Hide": imageLabel.setVisible(false); break;
				case "Reshow": imageLabel.setVisible(true); break;
				case "Quit": System.exit(0); break;
			}
		}
	}

	public static void main(String[] args) { new MenuActionEventEx(); }
}
