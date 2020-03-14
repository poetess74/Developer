package Part02.Round15;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round15_Ex11 {
    private static BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
    public static void main(String[] args) throws IOException {
        int num1 = 0, num2 = 0, total = 0; char op = 0; boolean flag;
        while (true) {
            do {
                flag = false;
                try {
                    System.out.print("num1 = ");
                    num1 = Integer.parseInt(in.readLine());
                } catch (NumberFormatException nfe) {
                    System.out.println("숫자만 입력 가능!");
                    flag = true;
                }
            } while (flag);
            do {
                flag = false;
                String string = "";
                try {
                    System.out.print("operator (+, -, *, /) = ");
                    string = in.readLine();
                    op = string.charAt(0);
                } catch (StringIndexOutOfBoundsException outOfRange) {
                    System.out.println("연산자가 null일 수는 없습니다. ");
                    flag = true;
                }
                if (string.length() != 1) {
                    System.out.println("연산자는 1자리여야 합니다. ");
                    flag = true;
                }
            } while (flag || (op != '+' && op != '-' && op != '*' && op != '/'));
            do {
                flag = false;
                try {
                    System.out.print("num2 = ");
                    num2 = Integer.parseInt(in.readLine());
                } catch (NumberFormatException nfe) {
                    System.out.println("숫자만 입력 가능!");
                    flag = true;
                }
            } while (flag);
            try {
                switch (op) {
                    case '+': total = num1 + num2; break;
                    case '-': total = num1 - num2; break;
                    case '*': total = num1 * num2; break;
                    case '/': total = num1 / num2; break;
                }
            } catch (ArithmeticException ae) {
                System.out.println("0 으로 나눌 수 없습니다. ");
                continue;
            }
            System.out.println(num1 + " " + op + " " + num2 + " = " + total);
        }
    }
}
