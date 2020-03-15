package Part02.Round15;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round15_Ex16 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        while (true) {
            System.out.print("num = ");
            long num = Long.parseLong(in.readLine());
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
            System.out.println(type + "에 담기 적당!!");
        }
    }
}
