package Part01.Round06;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round06_03 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("주민번호 8번째 자리를 입력하세요 : ");
        int input = Integer.parseInt(in.readLine()); String loc;
        switch (input) {
            case 0: loc = "서울"; break;
            case 1: loc = "부산 또는 인천"; break;
            case 2: loc = "경기도"; break;
            case 3: loc = "강원도 또는 충청북도"; break;
            case 4: case 5: loc = "충청 남 * 북도"; break;
            case 6: case 7: loc = "전라 남 * 북도"; break;
            default: loc = "경상 남 * 북도"; break;
        }
        System.out.println();
        System.out.println("당신은 " + loc + " 출생이시군요 ^^");
    }
}
