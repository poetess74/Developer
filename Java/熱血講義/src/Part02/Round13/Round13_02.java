package Part02.Round13;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

class Base {
    protected static BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
    protected String name, SSNFirst, SSNLast;
    private int[] SSN = new int[13];
    protected void InputSSN() throws IOException {
        System.out.print("이름 = ");
        name = in.readLine();
        System.out.print("주민번호 앞 6자리 입력 = ");
        SSNFirst = in.readLine();
        System.out.print("주민번호 뒤 7자리 입력 = ");
        SSNLast = in.readLine();
        SSNFirst += SSNLast;
        String[] SSNCharset = SSNFirst.split("");
        for (int i = 0; i < SSN.length; i++) {
            SSN[i] = Integer.parseInt(SSNCharset[i]);
        }
        CheckSSN();
    }
    protected void CheckSSN() throws IOException {
        int sum = 0;
        for (int i = 0; i < SSN.length; i++) {
            sum += i > 9 ? SSN[i] * (i / 10 + 3) : SSN[i] * (i + 3);
        }
        float temp = (int)(sum / 11.0f) * 11.0f + 11.0f - sum;
        temp = temp - (int)(temp / 10.0f) * 10.0f;
        if (temp != SSN[SSN.length - 1]) {
            System.out.println("주민번호가 올바르지 않습니다. ");
            InputSSN();
        }

    }
}

class Score extends Base {
    static class ScoreInfo {
        protected static int[] subjectScore = new int[4];
        protected static float avg;
        protected static char scoreChar;
        protected static void InputScore() throws IOException {
            System.out.print("국어 = ");
            subjectScore[0] = Integer.parseInt(in.readLine());
            System.out.print("영어 = ");
            subjectScore[1] = Integer.parseInt(in.readLine());
            System.out.print("수학 = ");
            subjectScore[2] = Integer.parseInt(in.readLine());
            CalcScore();
            PersonInfo.InputScale();
        }

        protected static void CalcScore() {
            subjectScore[3] = subjectScore[0] + subjectScore[1] + subjectScore[2];
            avg = subjectScore[3] / 3.0f;
            switch ((int)avg / 10) {
                case 10:
                case 9: scoreChar = 'A'; break;
                case 8: scoreChar = 'B'; break;
                case 7: scoreChar = 'C'; break;
                case 6: scoreChar = 'D'; break;
                default: scoreChar = 'F';
            }
        }
    }
    static class PersonInfo {
        protected static float height, weight, eyeScale;
        protected static void InputScale() throws IOException {
            System.out.print("키 = ");
            height = Float.parseFloat(in.readLine());
            System.out.print("몸무게 = ");
            weight = Float.parseFloat(in.readLine());
            System.out.print("시력 = ");
            eyeScale = Float.parseFloat(in.readLine());
        }
    }
}

public class Round13_02 {
    protected static BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
    public static void main(String[] args) throws IOException {
        Base person = new Base();

        person.InputSSN();
        Score.ScoreInfo.InputScore();

        System.out.println("==============================");
        System.out.println(person.name + "님~!");
        System.out.println();
        System.out.println("총점 = " + Score.ScoreInfo.subjectScore[3]);
        System.out.println("평균 = " + Score.ScoreInfo.avg);
        System.out.println("학점 = " + Score.ScoreInfo.scoreChar + " 학점");
        System.out.println();
        System.out.println("키 = " + Score.PersonInfo.height+ "cm");
        System.out.println("몸무게 = " + Score.PersonInfo.weight+ "kg");
        System.out.println("시력 = " + Score.PersonInfo.eyeScale);
        System.out.println("==============================");
    }
}
