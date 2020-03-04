package Round06;

import java.io.IOException;

public class Round06_01 {
    public static void main(String[] args) throws IOException {
        System.out.print("문자를 입력하세요 : ");
        int input = System.in.read();
        if (input <= 90 && input >= 65) {
            System.out.println((char)input + "는 대문자 입니다. ");
        } else if (input <= 122 && input >= 97) {
            System.out.println((char)input + "는 소문자 입니다. ");
        }
    }
}
