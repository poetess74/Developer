import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class ex102701 {
	public static void main(String[] args) throws IOException {
		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
		String text = br.readLine();
		System.out.println("text="+text);
		
		StringTokenizer stok = new StringTokenizer(text, "+-*/", true);
		int step = 0;
		int a = 0, b = 0;
		char op = 0;
		while (stok.hasMoreTokens()) {
			String token = stok.nextToken();
			switch (step) {
			case 0:
				a = Integer.parseInt(token);
				break;
			case 1:
				op = token.charAt(0);
				break;
			case 2:
				b = Integer.parseInt(token);
				break;
			
			}
			step++;
		}
		switch (op) {
		case '+':
			System.out.println(a + b);
			break;
		case '-':
			System.out.println(a - b);
			break;
		case '*':
			System.out.println(a * b);
			break;
		case '/':
			System.out.println(a / b);
			break;

			
		}
	}
}
