package Round07;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round07_Ex02 {
    private static int aaa() throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("첫번째 수 = ");
        int a = Integer.parseInt(in.readLine());
        System.out.print("두번째 수 = ");
        int b = Integer.parseInt(in.readLine());
        return a > b ? a : b;
    }
    private static void bbb() throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("첫번째 수 = ");
        int a = Integer.parseInt(in.readLine());
        System.out.print("두번째 수 = ");
        int b = Integer.parseInt(in.readLine());
        int tot = 0;
        if (a > b) {
            int temp = a;
            a = b;
            b = temp;
        }
        for (int i = a; i <= b; i++) {
            tot += i;
        }
        System.out.println(a + " ~ " + b + "사이의 합 = " + tot);
    }
    private static String ccc(int x, int y, int z) {
        if (y >= x && y >= z) {
            int temp = x;
            x = y;
            y = temp;
        } else if (z >= x && z >= y) {
            int temp = x;
            x = z;
            z = temp;
        }
        if (z >= y) {
            int temp = y;
            y = z;
            z = temp;
        }
        String result = x + " >= " + y + " >= " + z;
        return result;
    }
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        while (true) {
            System.out.print("1:최대수 2:사이합 3:수나열 4:종료 => ");
            int x = Integer.parseInt(in.readLine());
            if (x == 1) {
                int k = aaa();
                System.out.println("둘 중 최대수는" + k + "입니다. ");
            } else if (x == 2) {
                bbb();
            } else if (x == 3) {
                System.out.print("첫번째 수 = ");
                int firstNum = Integer.parseInt(in.readLine());
                System.out.print("두번째 수 = ");
                int secondNum = Integer.parseInt(in.readLine());
                System.out.print("세번째 수 = ");
                int thirdNum = Integer.parseInt(in.readLine());
                String string = ccc(firstNum, secondNum, thirdNum);
                System.out.println("큰 순으로 나열은" + string);
            } else if (x == 4) {
                break;
            } else {
                System.out.println("잘못 입력하셨습니다. ");
            }
            System.out.println();
        }
        System.out.println("수고 하셨습니다. ");
    }
}
