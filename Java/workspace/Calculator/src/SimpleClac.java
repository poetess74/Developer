import java.awt.Button;
import java.awt.Choice;
import java.awt.Font;
import java.awt.Frame;
import java.awt.Label;
import java.awt.TextField;
import java.awt.Window;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;


@SuppressWarnings("serial")
public class SimpleClac extends Frame implements ActionListener {
	TextField txtNum1;
	TextField txtNum2;
	Choice choOp;
	Button btnCalc;
	Button clear;
	Label lblResult;
	
	public SimpleClac() {
		setTitle("계산기");
		setSize(300, 120);
		addWindowListener(new WindowAdapter() {
			public void windowClosing(WindowEvent e) {
				dispose();
			}
		});
		setResizable(false);
		setLayout(null);
		
		txtNum1 = new TextField("0");
		txtNum1.setBounds(5, 30, 70, 20);
		add(txtNum1);
		
		txtNum2 = new TextField("0");
		txtNum2.setBounds(155, 30, 70, 20);
		add(txtNum2);
		
		choOp = new Choice();
		choOp.setBounds(80, 30, 70, 20);
		choOp.add("+");
		choOp.add("-");
		choOp.add("*");
		choOp.add("/");
		choOp.add("^");
		choOp.add("_/`");
		add(choOp);
		
		btnCalc = new Button("=");
		btnCalc.setBounds(230, 30, 32, 20);
		btnCalc.setActionCommand("op");
		add(btnCalc);
		btnCalc.addActionListener(this);
		
		clear = new Button("C");
		clear.setBounds(270, 30, 20, 20);
		clear.setActionCommand("c");
		add(clear);
		clear.addActionListener(this);
		
		lblResult = new Label("0");
		lblResult.setBounds(5, 55, 290, 60);
		lblResult.setAlignment(Label.RIGHT);
		lblResult.setFont(new Font("Ariel", Font.BOLD, 55));
		add(lblResult);
		
	}
	
	public static void main(String[] args) {
		SimpleClac win = new SimpleClac();
		win.setLocation(580, 300); //디바이스 디스플레이에 나타나는 창의 위치를 좌표로 선정
		win.setVisible(true);//화면에 보이기
		
	}

	@Override
	public void actionPerformed(ActionEvent e) {
//		System.out.println("PUSHED");
		
		if (e.getActionCommand() == "op") {
			String snum1 = txtNum1.getText();
			String snum2 = txtNum2.getText();
			String op = choOp.getSelectedItem();
			
			double num1 = Double.parseDouble(snum1);
			double num2 = Double.parseDouble(snum2);
			double r = 0;
			
			boolean needToFraction = false;
			
			if (op == "+") {
				r = num1 + num2;
				needToFraction = true;
			} else if (op == "-") {
				r = num1 - num2;
				needToFraction = true;
			} else if (op == "*") {
				r = num1 * num2;
				needToFraction = true;
			} else if (op == "/") {
				if (num2 == 0) {
					lblResult.setText("Infinity");
					return;
					
				}
				r = num1 / num2;
				needToFraction = true;
			} else if (op == "^") {
				r = (double) Math.pow(num1, num2);
				needToFraction = true;
			} else if (op == "_/`") {
				r = (double) Math.sqrt(num1);
				needToFraction = true;
			}
			
			if (needToFraction) {
				lblResult.setText(String.format("%.6f", r));
			} else {
				lblResult.setText(String.format("%.0f", r));
			}
		} else if (e.getActionCommand() == "c") {
			txtNum1.setText("0");
			txtNum2.setText("0");
			lblResult.setText("0");
			choOp.select("+");
		}
	}
	
}
