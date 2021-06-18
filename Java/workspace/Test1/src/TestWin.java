import java.awt.Button;
import java.awt.Color;
import java.awt.Frame;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;


public class TestWin extends Frame implements MouseMotionListener, ActionListener{

	Color c;
	public TestWin() {
		super("무제");
		addWindowListener(new WindowAdapter() {
			public void windowClosing(WindowEvent e) {
				dispose();
			}
		});
		setSize(400, 300);
//		addMouseMotionListener(this);
		setResizable(false);
		setLayout(null);
		
		Button b = new Button("Color");
		b.setBounds(50, 50, 100, 22);
		this.add(b);
		b.addActionListener(this);
		c = new Color(0,0,0);
	}
	
	public void  paint(Graphics g) {
		g.setColor(c);
		g.fillRect(0, 0, getSize().width, getSize().height);
	}
	
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		TestWin win = new TestWin();
		win.setLocation(500, 300);
		win.setVisible(true);
		
	}
	@Override
	public void mouseDragged(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}
	@Override
	public void mouseMoved(MouseEvent e) {
		// TODO Auto-generated method stub
		System.out.printf("x=%d,y=%d\n", e.getX(), e.getY());
	}

	@Override
	public void actionPerformed(ActionEvent arg0) {
		// TODO Auto-generated method stub
		System.out.println("PUSHED");
		c = new Color((int)(Math.random()*256),(int)(Math.random()*256),(int)(Math.random()*256));
		repaint();
	}
	

}
