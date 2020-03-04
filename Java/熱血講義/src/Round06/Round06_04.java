package Round06;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round06_04 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("단수 = ");
        int input = Integer.parseInt(in.readLine());
        System.out.println("=== " + input + " 단 " + "===");
        for(int i = 1; i < 10; i++) {
            System.out.println(input + " * " + i + " = " + input * i);
        }
        System.out.println("=== " + input + " 단 " + "===");
    }
}
