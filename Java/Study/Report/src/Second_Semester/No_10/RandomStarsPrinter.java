package Second_Semester.No_10;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

public class RandomStarsPrinter extends JFrame {
	private TopPanel Top = new TopPanel();
	private CenterPanel Center = new CenterPanel();
	private BottomPanel Bottom = new BottomPanel();

	public RandomStarsPrinter() {
		setTitle("[김형민]");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Container container = getContentPane();
		container.add(Top, BorderLayout.NORTH);
		container.add(Center, BorderLayout.CENTER);
		container.add(Bottom, BorderLayout.SOUTH);
		setSize(325, 325);
		setVisible(true);
		Center.draw(10);
	}

	class TopPanel extends JPanel {
		JButton reload = new JButton("새로고침");
		JButton exit = new JButton("종료");
		public TopPanel() {
			setBackground(Color.YELLOW);
			add(reload);
			add(exit);
			reload.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					Center.draw();
				}
			});
			exit.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					System.exit(0);
				}
			});
		}
	}

	class CenterPanel extends JPanel {
		private ArrayList<JLabel> list = new ArrayList<>();
		public CenterPanel() {
			setBackground(Color.WHITE);
			setLayout(null);
			draw(10);
		}
		public void draw() {
			for(JLabel label : list) {
				label.setSize(20, 20);
				label.setForeground(Color.RED);
				label.setLocation((int) (Math.random() * (this.getWidth() - 20)),
						(int) (Math.random() * (this.getHeight() - 20)));
			}
		}
		public void draw(int count) {
			list.clear();
			this.removeAll();
			for(int i = 0; i < count; i++) {
				JLabel label = new JLabel("*");
				list.add(label);
				label.setSize(20, 20);
				label.setForeground(Color.RED);
				label.setLocation((int)(Math.random() * (this.getWidth() - 20)),
						(int)(Math.random() * (this.getHeight() - 20)));
				add(label);
			}
			this.repaint();
		}
	}

	class BottomPanel extends JPanel {
		JButton modify = new JButton("개수수정");
		JTextField count = new JTextField();
		public BottomPanel() {
			modify.addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					Center.draw(Integer.parseInt(count.getText()));
				}
			});
		}
	}

	public static void main(String[] args) {
		new RandomStarsPrinter();
	}
}
