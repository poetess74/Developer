package Round07;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round07_Ex05 {
    private static int getInt(String string) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print(string + " = ");
        int temp = Integer.parseInt(in.readLine());
        return temp;
    }

    public static void main(String[] args) throws IOException {
        int kor = getInt("국어");
        System.out.println("국어 점수는" + kor + "입니다. ");
    }
}
