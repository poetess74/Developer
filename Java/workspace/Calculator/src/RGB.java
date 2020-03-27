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


public class RGB extends Frame implements MouseMotionListener, ActionListener {

	Color c;
	private Button a;
	private Button b;
	private Button d;
	private Button g;
	private Button h;
	public RGB() {
		super("RGB 색깔 변경,6ic");
		System.out.println("App Text Message : START");
		addWindowListener(new WindowAdapter() {
			public void windowClosing(WindowEvent e) {
				dispose();
			}
		});
//		setSize(200, 200);
		setSize(200, 300);
		addMouseMotionListener(this); //마우스 좌표 찍는 라인
		setResizable(false);
		setLayout(null);
		
		//Red Button
		a = new Button("Red");
		a.setBounds(50, 50, 100, 20);
		this.add(a);
		a.addActionListener(this);
		
		//Green Button
		b = new Button("Green");
		b.setBounds(50, 100, 100, 20);
		this.add(b);
		b.addActionListener(this);
		
		//Blue Button
		d = new Button("Blue");
		d.setBounds(50, 150, 100, 20);
		this.add(d);
		d.addActionListener(this);
		
		//Random Button
		g = new Button("Random");
		g.setBounds(50, 250, 100, 20);
		this.add(g);
		g.addActionListener(this);
		
		h = new Button("Black");
		h.setBounds(50, 200, 100, 20);
		this.add(h);
		h.addActionListener(this);
		
		c = new Color(0,0,0); //바탕에 검은색 컬러가 나타남
	}
	
	public void  paint(Graphics g) {
		g.setColor(c);
		g.fillRect(0, 0, getSize().width, getSize().height);
	}
	
	
	public static void main(String[] args) {
		RGB win = new RGB();
		win.setLocation(580, 300); //디바이스 디스플레이에 나타나는 창의 위치를 좌표로 선정
		win.setVisible(true);//화면에 보이기
		
	}
	@Override
	//Mouse drag
	public void mouseDragged(MouseEvent e) {
		System.out.printf("App Text Message : Mouse Dragged -> x = %d, y = %d\n", e.getX(), e.getY());
	}
	@Override
	//Mouse move
	public void mouseMoved(MouseEvent e) {
		System.out.printf("App Text Message : Mouse Moved -> x = %d, y = %d\n", e.getX(), e.getY());
	}

	@Override
	//Mouse click
	public void actionPerformed(ActionEvent e) {
		if (e.getSource() == a) {
			System.out.println("App Text Message : Button Pushed 'Red'");
			c = new Color(255, 0, 0);
		} else if (e.getSource() == b) {
			System.out.println("App Text Message : Button Pushed 'Green'");
			c = new Color(0, 255, 0);
		} else if (e.getSource() == d) {
			System.out.println("App Text Message : Button Pushed 'Blue'");
			c = new Color(0, 0, 255);
		} else if (e.getSource() == h) {
			System.out.println("App Text Message : Button Pushed 'Black'");
			c = new Color(0, 0, 0);
		}else if (e.getSource() == g) {	
			System.out.println("App Text Message : Random Button Pushed");
			c = new Color((int)(Math.random()*256),(int)(Math.random()*256),(int)(Math.random()*256));
		}
		repaint();
	}
}
