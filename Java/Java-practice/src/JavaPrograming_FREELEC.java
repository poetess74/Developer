import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

//import java.lang.*; // 생략 가능한 패키지

/**
 * Java Programing 열혈강의
 * 김승현 저
 * 생성일 : 2019 년 6 월 28 일
 * 완료일 :
 */

public class JavaPrograming_FREELEC {
    int defined;
    public static void main (String [] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in)); // p.112
        System.out.println();
//      ------------------------------------- Round 2 -------------------------------------
        {
            System.out.println("Hello Java!"); // p.51
            System.out.println("안녕하세요! 여러분!\n자바 공부를 열심히 합시다. \n모두들 화이팅요 ^^"); //p.63
            System.out.println();
        } // p.51 ~ 63
//      ------------------------------------- Round 3 -------------------------------------
        {
            //int notDefined;
            //System.out.println(notDefined); // notDefined 변수를 초기화 해야 함
            JavaPrograming_FREELEC rd = new JavaPrograming_FREELEC();
            System.out.println(rd.defined); //p.85
            System.out.println();
        } // p.85
//      ------------------------------------- Round 4 -------------------------------------
        {
            byte by = 100;
            long lo = 123456l;
            String str = "김승현";
            System.out.print(12);
            System.out.println("ABC");
            System.out.print(by);
            System.out.println(lo);
            System.out.println(str); //p.92
            System.out.print("ABC");
            System.out.println("DEF");
            System.out.println("ABC");
            System.out.println("DEF"); // p.93
            {
                byte num = 65;
                short sh = 65;
                char ch = 65;
                int i = 65;
                long longfl = 65l;
                float fl = 65f;
                double du = 65;
                System.out.println(num);
                System.out.println(sh);
                System.out.println(ch);
                System.out.println(i);
                System.out.println(longfl);
                System.out.println(fl);
                System.out.println(du); // p.94
                System.out.println("char 는 숫자가 들어오면 문자로 변환됩니다. 예 : " + i + " -> " + ch + " (ASCII 표준을 따름)"); // p.96
                System.out.printf("%c", 'A');
                System.out.println();
                System.out.printf("%5c", 'A');
                System.out.println();
                System.out.printf("%-5c", 'A');
                System.out.println();
                System.out.printf("%d", 12345);
                System.out.println();
                System.out.printf("%o", 12345);
                System.out.println();
                System.out.printf("%x", 12345);
                System.out.println();
                System.out.printf("%10d", 12345);
                System.out.println();
                System.out.printf("%010d", 12345);
                System.out.println();
                System.out.printf("%f", 12.12745f);
                System.out.println();
                System.out.printf("%g", 12.12745f);
                System.out.println();
                System.out.printf("%e", 12.12745f);
                System.out.println();
                System.out.printf("%-10.2f", 12.12745f);
                System.out.println();
                System.out.printf("%010.2f", 12.12745f);
                System.out.println();
            } //p.99
            System.out.printf("%s\n", "김승현");
            System.out.printf("%10s\n", "김승현");
            String name = "김승현";
            int age = 20;
            System.out.printf("%10s님의 나이는 %05d세 입니다. \n", name, age); // p.100
            byte[] b_array = {'J', 'A', 'V', 'A'};
            System.out.write(b_array); //p.103
            System.out.println();
            /*
            System.out.print("insert = "); // IP : 9
            int aa = System.in.read();
            System.in.read();
            System.out.println("result : " + aa); // p.106
            System.out.print("insert = "); // IP : 4
            char ab = (char) System.in.read();
            System.in.read();
            System.out.print("insert = "); // IP : 4
            int bb = System.in.read() - 48;
            System.in.read();
            System.out.println("result : " + ab + ", " + bb); // p.108
            System.out.print("insert = "); // IP : abc
            int ac = System.in.read();
            int bc = System.in.read();
            int cc = System.in.read();
            int dc = System.in.read();
            System.out.println("result : " + ac + " " + bc + " " + cc + " " + dc); //p.110
            String na = "";
            System.out.print("insert : "); // IP : 김승현
            na = in.readLine();
            System.out.println("result : " + na); //p.112
            String temp = in.readLine();
            System.out.println("insert : "); //true
            boolean bool = Boolean.valueOf(temp).booleanValue();
            System.out.println("result : " + bool); //p.113
            System.out.print("input : ");
            age = Integer.parseInt(in.readLine()) - 1;
            System.out.println("result : " + age); //p.114
            System.out.print("insert : ");
            char aga = (char) System.in.read();
            System.in.read();
            int aba = (int) aga;
            System.out.println("result : " + aga + " " + aba);
            System.out.print("insert : ");
            name = in.readLine();
            int kor = System.in.read();
            System.in.read();
            int eng = System.in.read();
            System.in.read();
            int mat = System.in.read();
            System.in.read();
            System.out.print("result : " + name + " " + (kor + eng + mat) + " " + ((kor + eng + mat) / (float) 3)); //p.116
            */
        } // p.92 ~ 116
//      ------------------------------------- Round 5 -------------------------------------
        {
            System.out.println();
            System.out.println(4 + 5 > 2 - 1 * 7 && (12 & 3 * 2) > 7 || -2 != 2); //p.119
            String[]str = {"AAA", "BBB", "CCC"};
            System.out.println(str[0]); //p.122
            System.out.println((5 * 3 + 2) + " " + (5 * (3 + 2)));
            System.out.println(!(true)); //p.123
            int x = 5;
            int y = ++x;
            System.out.println(x + " " + y);
            x = 5;
            y = x++;
            System.out.println(x + " " + y);
            int a = 65;
            System.out.println((char)a); //p.127
            System.out.println(1.2f - 1.2d);
            a = 9;
            System.out.println((a / 4) + " " + (a % 4)); //p.129
            System.out.println(100 > 200);
            System.out.println(127 >= 127); //p.133
            System.out.println(100 == 100);
            System.out.println(100 != 100); //p.134
            System.out.println(7 & 4);
            System.out.println(7 ^ 4);
            System.out.println(7 | 4); //p.136
            System.out.println(10 > 20 ? 10 : 20); //p.140
            /*
            System.out.print("insert : ");
            a = System.in.read(); // IN : 1
            System.in.read();
            System.out.println(a == 50 ? "F" : "M");
            System.out.print("insert : ");
            char ch = (char) System.in.read(); // IN : a
            System.in.read();
            System.out.println(ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '%' ? "true" : "false"); //p.143
            */
        } // p.119 ~ 143
//      ------------------------------------- Round 6 -------------------------------------
        {
            System.out.println();
            System.out.print("insert : "); // IN : 0 ~ 9
            int a = System.in.read() - 48;
            if (a > 5) {
                System.out.println("result : " + a + " > 5");
            } else if (a < 5) {
                System.out.println("result : " + a + " < 5");
            } else {
                System.out.println("result : " + a + " = 5");
            } // p.151
        }
    }
}
