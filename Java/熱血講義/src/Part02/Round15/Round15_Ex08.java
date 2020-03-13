package Part02.Round15;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round15_Ex08 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        int x = 0, y = 0, div = 0;
        boolean bool;
        do {
            bool = false;
            System.out.print("x = ");
            try {
                x = Integer.parseInt(in.readLine());
            } catch (NumberFormatException exception) {
                System.out.println("x 는 숫자여야 합니다. ");
                bool = true;
            }
        } while (bool);
        do {
            bool = false;
            System.out.print("y = ");
            try {
                y = Integer.parseInt(in.readLine());
            } catch (NumberFormatException exception) {
                System.out.println("y 는 숫자여야 합니다. ");
                bool = true;
            }
        } while (bool);
        try {
            div = x / y;
        } catch (ArithmeticException ae) {
            div = x;
        }
        System.out.println(x + " / " + y + " = " + div);
    }
}
