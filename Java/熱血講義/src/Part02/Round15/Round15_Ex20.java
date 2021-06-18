package Part02.Round15;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round15_Ex20 {
    private static String getType(long num) {
        String type = "";
        if (num >= Byte.MIN_VALUE && num <= Byte.MAX_VALUE) {
            type = "byte";
        } else if (num >= Short.MIN_VALUE && num <= Short.MAX_VALUE) {
            type = "short";
        } else if (num >= Integer.MIN_VALUE && num <= Integer.MAX_VALUE) {
            type = "int";
        } else {
            type = "long";
        }
        return type;
    }

    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("num1 = ");
        long num1 = Long.parseLong(in.readLine());
        System.out.print("op = ");
        char op = (char)System.in.read();
        System.in.read();
        System.out.print("num2 = ");
        long num2 = Long.parseLong(in.readLine());

        System.out.println(getType(num1) + " a = " + num1 + ";");
        System.out.println("char b = '" + op + "'");
        System.out.println(getType(num2) + " c = " + num2 + ";");
        String type = "";
        switch (op) {
            case '+': type = getType(num1 + num2); break;
            case '-': type = getType(num1 - num2); break;
            case '*': type = getType(num1 * num2); break;
            case '/': type = getType(num1 / num2); break;
        }
        System.out.println(type + " d = a " + op + " b;");
    }
}
