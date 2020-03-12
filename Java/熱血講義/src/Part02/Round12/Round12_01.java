package Part02.Round12;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

class Person {
    protected static BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
    private String name, SSNFirst, SSNLast;
    private String[] SSNCharset;
    private int[] SSN = new int[13];
    protected void InputSSN() throws IOException {
        System.out.print("주민번호 앞 6자리 입력 = ");
        SSNFirst = in.readLine();
        System.out.print("주민번호 뒤 7자리 입력 = ");
        SSNLast = in.readLine();
        SSNFirst += SSNLast; SSNCharset = SSNFirst.split("");
        for (int i = 0; i < SSN.length; i++) {
            SSN[i] = Integer.parseInt(SSNCharset[i]);
        }
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
    class Score {
        private int[] subjectScore = new int[5];
        private float avg;
        private char scoreChar;
        protected void InputScore() throws IOException {
            System.out.print("국어 = ");
            subjectScore[0] = Integer.parseInt(in.readLine());
            System.out.print("영어 = ");
            subjectScore[1] = Integer.parseInt(in.readLine());
            System.out.print("수학 = ");
            subjectScore[2] = Integer.parseInt(in.readLine());

        }
        protected void CalcScore() {
            subjectScore[3] = subjectScore[0] + subjectScore[1] + subjectScore[2];
            subjectScore[4] = 1;
            avg = subjectScore[3] / 3.0f;
            switch (subjectScore[3] / 10) {
                case 10:
                case 9: scoreChar = 'A'; break;
                case 8: scoreChar = 'B'; break;
                case 7: scoreChar = 'C'; break;
                case 6: scoreChar = 'D'; break;
                default: scoreChar = 'F';
            }
        }
    }
}

