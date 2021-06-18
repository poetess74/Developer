package Part01.Round06;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round06_05 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        int inputA, inputB, tot; char op, request;
        do {
            System.out.print("첫번째 수 = ");
            inputA = Integer.parseInt(in.readLine());
            System.out.print("연산자(+, -, *, /, %) = ");
            op = (char)System.in.read();
            System.in.read();
            System.out.print("두번째 수 = ");
            inputB = Integer.parseInt(in.readLine());
            switch (op) {
                case '+':
                    System.out.println(inputA + " + " + inputB + " = " + (inputA + inputB)); break;
                case '-':
                    System.out.println(inputA + " - " + inputB + " = " + (inputA - inputB)); break;
                case '*':
                    System.out.println(inputA + " * " + inputB + " = " + (inputA * inputB)); break;
                case '/':
                    System.out.println(inputA + " / " + inputB + " = " + (inputA / inputB)); break;
                case '%':
                    System.out.println(inputA + " % " + inputB + " = " + (inputA % inputB)); break;
                default:
                    System.out.println("잘못된 연산자입니다. ");
            }
            System.out.print("계속 하시겠습니까? (y/n) : ");
            request = (char)System.in.read();
            System.in.read();
        } while (request == 'y');
    }
}
