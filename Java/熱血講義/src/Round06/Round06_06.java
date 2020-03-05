package Round06;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round06_06 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("1.  년도를 4자리로 입력하세요(예 : 2004) => ");
        int year = Integer.parseInt(in.readLine());
        System.out.print("2.  월을 입력하세요(예 : 6) => ");
        int month = Integer.parseInt(in.readLine());
        int[] monthLimit = {31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        System.out.println("====== < " + year + "년 " + month + "월 > ======");
        System.out.println("일\t월\t화\t수\t목\t금\t토");
        if ((year % 4 == 0 && year % 100 != 0) || (year % 4 == 0 && year % 400 == 0)) {
            monthLimit[1] = 29;
            int day = 1;
            boolean stop = false;
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 7; j++) {
                    if (monthLimit[month - 1] >= day) {
                        System.out.printf("%2d\t", day);
                        day += 1;
                    } else {
                        stop = true;
                        break;
                    }
                }
                if (stop) {
                    break;
                }
                System.out.println();
            }
        } else {
            monthLimit[1] = 28;
            int day = 1;
            boolean stop = false;
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 7; j++) {
                    if (monthLimit[month - 1] >= day) {
                        System.out.printf("%2d\t", day);
                        day += 1;
                    } else {
                        stop = true;
                        break;
                    }
                }
                if (stop) {
                    break;
                }
                System.out.println();
            }
        }
        if (month < 10) {
            System.out.println();
            System.out.println("===========================");
        } else {
            System.out.println();
            System.out.println("============================");
        }
    }
}
