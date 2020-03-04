package Round04;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Round04_Ex09 {
    public static void main(String[] args) throws java.io.IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));

        System.out.print("이름을 입력하세요 : ");
        String name = in.readLine();
        System.out.println("당신이 입력하신 이름은 " + name + "입니다. ");
    }
}
