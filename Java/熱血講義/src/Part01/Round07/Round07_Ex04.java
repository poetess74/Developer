package Part01.Round07;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round07_Ex04 {
    private static String getString(String string) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print(string + " = ");
        String temp = in.readLine();
        return temp;
    }

    public static void main(String[] args) throws IOException {
        String name = getString("이름");
        System.out.println(name + "님! 안녕하세요!!");
    }
}
