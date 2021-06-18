package Part01.Round06;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round06_Ex01 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        int firstNum, secondNum;
        System.out.print("첫번째 수 = ");
        firstNum = Integer.parseInt(in.readLine());
        System.out.print("두번째 수 = ");
        secondNum = Integer.parseInt(in.readLine());

        if (firstNum > secondNum) {
            System.out.print("첫번째 수(" + firstNum + ")");
            System.out.print("가 두번째 수(" + secondNum + ")");
            System.out.println("보다 큰 수 입니다. ");
        } else {
            System.out.print("첫번째 수(" + firstNum + ")");
            System.out.print("가 두번째 수(" + secondNum + ")");
            System.out.println("보다 작은 수 입니다. ");
        }
    }
}
