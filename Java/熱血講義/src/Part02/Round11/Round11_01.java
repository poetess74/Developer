package Part02.Round11;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

public class Round11_01 {
    private static BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
    private static class JBank {
        private static ArrayList<String> name = new ArrayList<>();
        private static ArrayList<Integer> won = new ArrayList<>();
        private static int plus = 5;
        private static int userCount = 0;
    }

    private static void NewUser() throws IOException {
        System.out.println("=== 신규 가입 ===");
        System.out.print("이름 = ");
        JBank.name.add(in.readLine());
        System.out.print("입금 금액 = ");
        JBank.won.add(Integer.parseInt(in.readLine()));
        Date time = new Date();
        SimpleDateFormat format = new SimpleDateFormat("yyyy년 MM월 dd일 HH시 mm분");
        System.out.println();
        System.out.println("신규 가입이 " + format.format(time) + "에 처리되었습니다. ");
        System.out.println("입금한 금액은 " + JBank.won.get(JBank.userCount) + "원 입니다. ");
        System.out.println("현재 적용 이율은 " + JBank.plus + "%입니다. ");
        System.out.println("=== 신규 가입 끝 ===");
        JBank.userCount += 1;
    }

    private static void ChangePlus() throws IOException {
        System.out.print("관리자 패스워드를 입력하세요 : ");
        if (1111 == Integer.parseInt(in.readLine())) {
            System.out.println("현재 " + JBank.plus + "%의 이율이 적용되고 있습니다. 얼마로 변경하시겠습니까?");
            System.out.print("적용 이율 = ");
            JBank.plus = Integer.parseInt(in.readLine());
            System.out.println("모든 고객에게 " + JBank.plus + "%로 변경 적용됩니다. ");
        } else {
            System.out.println("잘못 입력하셨습니다. ");
        }
    }

    private static void UserStatus() throws IOException {
        System.out.println("=== 현재 등록 고객 정보 ===");
        System.out.println(" 이름    금액   이율");
        System.out.println("======================");
        for (int i = 0; i < JBank.userCount; i++) {
            System.out.println(JBank.name.get(i) + " " + JBank.won.get(i) +  ".0원 " + JBank.plus + "%");
        }
        System.out.println("======================");

    }

    public static void main(String[] args) throws IOException {
        while (true) {
            System.out.println();
            System.out.print("1. 신규가입 2. 이율변경 3. 등록인원정보 4. 종료 ==> ");
            int input = Integer.parseInt(in.readLine());
            System.out.println();
            switch (input) {
                case 1:
                    NewUser();
                    break;
                case 2:
                    ChangePlus();
                    break;
                case 3:
                    UserStatus();
                    break;
                case 4:
                    System.out.println("은행 영업을 마감합니다. 수고하셨습니다!!!");
                    System.exit(0);
                    break;
                default: continue;
            }
        }
    }
}
