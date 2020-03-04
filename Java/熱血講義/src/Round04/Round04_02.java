package Round04;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Round04_02 {
    public static void main(String[] args) throws java.io.IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("이름 = ");
        String name = in.readLine();
        System.out.print("국어 = ");
        int kor = Integer.parseInt(in.readLine());
        System.out.print("영어 = ");
        int eng = Integer.parseInt(in.readLine());
        System.out.print("수학 = ");
        int math = Integer.parseInt(in.readLine());
        int sum = kor + eng + math;
        System.out.print(name + "님 !! 당신의 성적은 다음과 같습니다. \n총점 : " + sum + "점\n평균 : " + sum / 3.0f + "점");
    }
}
