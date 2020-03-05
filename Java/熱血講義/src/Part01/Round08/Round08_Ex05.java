package Part01.Round08;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Calendar;

public class Round08_Ex05 {
    private static boolean checkPin(String[] inputA, String[] inputB) {
        int sum = 0;
        for (int i = 1; i <= inputA.length - 1; i++) {
            sum += Integer.parseInt(inputA[i]) * i + 2;
        }
        for (int i = 1; i <= inputB.length - 1; i++) {
            sum += Integer.parseInt(inputB[i]) * i + 8;
        }
        float checksum = (int)(sum / 11.0f) * 11.0f + 11.0f - sum;
        checksum = checksum - (int)(checksum / 10.0f) * 10.0f;
        return checksum == Integer.parseInt(inputB[inputB.length - 1]);
    }
    private static boolean dateCheck(String[] strings) {
        if (Integer.parseInt(strings[2]) * 10 + Integer.parseInt(strings[3]) > 12) {
            System.out.println("태어난 달은 12월 보다 클 수 없습니다. ");
            return false;
        }
        if (Integer.parseInt(strings[4]) * 10 + Integer.parseInt(strings[5]) > 31) {
            System.out.println("태어난 일은 31일 보다 클 수 없습니다. ");
            return false;
        }
        return true;
    }
    private static boolean birthCheck(String[] strings) {
        if (Integer.parseInt(strings[0]) != 9 && Integer.parseInt(strings[0]) != 0 && Integer.parseInt(strings[0]) != 1 && Integer.parseInt(strings[0]) != 2 && Integer.parseInt(strings[0]) != 3 && Integer.parseInt(strings[0]) != 4) {
            System.out.println("성별을 나타내는 숫자는 9, 0, 1, 2, 3, 4 중 하나여야 합니다. ");
            return false;
        }
        return true;
    }
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        int year = 0, month = 0, day = 0;
        String name, SSNFirst, SSNLast;
        String[] SSNFront, SSNBack;
        while (true) {
            System.out.print("이름 = ");
            name = in.readLine();
            System.out.print("주민번호 앞 6자리 = ");
            SSNFirst = in.readLine();
            System.out.print("주민번호 뒤 7자리 = ");
            SSNLast = in.readLine();
            SSNFront = SSNFirst.split("");
            SSNBack = SSNLast.split("");
            if (!dateCheck(SSNFront)) {
                continue;
            }
            if (!birthCheck(SSNBack)) {
                continue;
            }
            if (!checkPin(SSNFront, SSNBack)) {
                System.out.println("입력된 주민번호에 오류가 있습니다. ");
                continue;
            }
            break;
        }
        System.out.println();
        System.out.println("이름 = " + name);
        System.out.println("주민번호 = " + SSNFirst + " - " + SSNLast);
        System.out.println();
        System.out.print("생년월일 = ");
        switch (Integer.parseInt(SSNBack[0])) {
            case 9: case 0: year = 1800; break;
            case 1: case 2: year = 1900; break;
            case 3: case 4: year = 2000; break;
        }
        year += Integer.parseInt(SSNFront[0]) * 10 + Integer.parseInt(SSNFront[1]);
        month = Integer.parseInt(SSNFront[2]) * 10 + Integer.parseInt(SSNFront[3]);
        day = Integer.parseInt(SSNFront[4]) * 10 + Integer.parseInt(SSNFront[5]);
        System.out.println(year + "년" + month + "월" + day + "일");
        System.out.print("성별 = ");
        System.out.println(Integer.parseInt(SSNBack[0]) % 2 == 0 ? "여성" : "남성");
        System.out.print("태어난 시도 = ");
        String area = "";
        switch (Integer.parseInt(SSNBack[1])) {
            case 0: area = "서울"; break;
            case 1: area = "경기, 인천"; break;
            case 2: area = "부산"; break;
            case 3: area = "강원도"; break;
            case 4: area = "충청도"; break;
            case 5: area = "전라도"; break;
            case 6: area = "대구, 광주"; break;
            case 7: area = "경북, 경남"; break;
            case 8: area = "경남"; break;
            case 9: area = "제주"; break;
        }
        System.out.println(area);
        System.out.print("나이 = ");
        Calendar calendar = Calendar.getInstance();
        int age = calendar.get(Calendar.YEAR) - year;
        System.out.print(age);
        System.out.println("세");
    }
}
