package Round06;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round06_Ex04 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        int num1, num2, tot = 0; char op;
        System.out.print("첫번째 수 = ");
        num1 = Integer.parseInt(in.readLine());
        System.out.print("연산자(+, -, *, /, %) = ");
        op = (char)System.in.read();
        System.in.read();
        System.out.print("두번째 수 = ");
        num2 = Integer.parseInt(in.readLine());
        switch (op) {
            case '+': tot = num1 + num2; break;
            case '-': tot = num1 - num2; break;
            case '*': tot = num1 * num2; break;
            case '/': tot = num1 / num2; break;
            case '%': tot = num1 % num2; break;
            default:
                System.out.println("잘못된 연산자 입력");
                System.exit(1);
        }
        System.out.println();
        System.out.println(num1 + " " + op + " " + num2 + " = " + tot);
//      System.out.println(num1 + op + num2 + " = " + tot);
    }
}
