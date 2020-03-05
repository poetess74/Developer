package Part01.Round06;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round06_Ex05 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        int num1, num2, tot = 0;
        System.out.print("첫번째 수 = ");
        num1 = Integer.parseInt(in.readLine());
        System.out.print("두번째 수 = ");
        num2 = Integer.parseInt(in.readLine());
        if (num1 > num2) {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }
        for (int i = num1; i <= num2; i++) {
            tot += i;
        }
        System.out.println();
        System.out.print(num1 + "에서 " + num2 + "사이의 합은 ");
        System.out.println(tot + "입니다. ");
    }
}
