package Part01.Round08;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round08_02 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        int[] num = new int[5];
        for (int i = 0; i < num.length; i++) {
            System.out.print("수" + (i + 1) + " = ");
            num[i] = Integer.parseInt(in.readLine());
        }
        for (int i = 0; i < num.length; i++) {
            for (int j = i + 1; j < num.length; j++) {
                if (num[i] < num[j]) {
                    int temp = num[j];
                    num[j] = num[i];
                    num[i] = temp;
                }
            }
        }
        for (int i = 0; i < num.length - 1; i++) {
            System.out.print(num[i] + " > ");
        }
        System.out.println(num[4]);
    }
}
