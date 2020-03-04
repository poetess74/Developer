package Round06;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round06_02 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("연도를 입력하세요 : ");
        int year = Integer.parseInt(in.readLine());
        System.out.println((year % 4 == 0 && year % 100 != 0) || (year % 4 == 0 && year % 400 == 0) ? year + "년은 윤년입니다. " : year + "년은 윤년이 아닙니다. ");
    }
}
