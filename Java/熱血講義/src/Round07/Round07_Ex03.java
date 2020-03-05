package Round07;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round07_Ex03 {
    private static int plu(int x, int y) {
        return x + y;
    }
    private static int min(int x, int y) {
        return x - y;
    }
    private static int mul(int x, int y) {
        return x * y;
    }
    private static int div(int x, int y) {
        return x / y;
    }
    private static int per(int x, int y) {
        return x % y;
    }
    private static void res(int a, char b, int c, int d) {
        System.out.println();
        System.out.println(a + " " + b + " " + c + " = " + d);
    }
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        int tot = 0; char op;
        System.out.print("num1 = ");
        int num1 = Integer.parseInt(in.readLine());
        do {
            System.out.print("op(+, -, *, /, %) = ");
            op = (char)System.in.read();
            System.in.read();
        } while (op != '+' && op != '-' && op != '*' && op != '/' && op != '%');
        System.out.print("num2 = ");
        int num2 = Integer.parseInt(in.readLine());
        switch (op) {
            case '+': tot = plu(num1, num2); break;
            case '-': tot = min(num1, num2); break;
            case '*': tot = mul(num1, num2); break;
            case '/': tot = div(num1, num2); break;
            case '%': tot = per(num1, num2); break;
        }
        res(num1, op, num2, tot);
    }
}
