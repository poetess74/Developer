package Round06;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round06_06 {
    private static void  PrintingCal(int year, int month, boolean leap) {
        System.out.println("====== < " + year + "년 " + month + "월 > ======");
        System.out.println("일\t월\t화\t수\t목\t금\t토");
        if (leap) {
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 7; j++) {

                }
            }
        } else {

        }
        if (month < 10) {
            System.out.println("============================");
        } else {
            System.out.println("===========================");
        }
    }
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("1.  년도를 4자리로 입력하세요(예 : 2004) => ");
        int year = Integer.parseInt(in.readLine());
        System.out.print("2.  월을 입력하세요(예 : 6) => ");
        int month = Integer.parseInt(in.readLine());
        PrintingCal(year, month, ((year % 4 == 0 && year % 100 != 0) || (year % 4 == 0 && year % 400 == 0)));
    }
}
