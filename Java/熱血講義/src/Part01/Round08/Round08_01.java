package Part01.Round08;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round08_01 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("태어난 년 = ");
        String birthYear = in.readLine();
        System.out.print("태어난 월 = ");
        String birthMonth = in.readLine();
        System.out.print("태어난 일 = ");
        String birthDay = in.readLine();
        System.out.print("태어난 지역(0:서울, 1:경기 인천, ..., 9:제주도) = ");
        String birthLoc = in.readLine();
        System.out.print("성별(0: 남성, 1: 여성) = ");
        String sex = in.readLine();
        String SSNFirst = birthYear.substring(2);
        String SSNLast = sex;
        String[] BirthM = birthMonth.split("");
        String[] BirthD = birthDay.split("");
        SSNFirst = SSNFirst.concat(BirthM.length == 1 ? "0" + birthMonth : birthMonth);
        SSNFirst = SSNFirst.concat(BirthD.length == 1 ? "0" + birthDay: birthDay);
        SSNLast = SSNLast.concat(birthLoc);
        SSNLast = SSNLast.concat("0000");
        String[] SSNFront = SSNFirst.split("");
        String[] SSNBack = SSNLast.split("");
        int sum = 0;
        for (int i = 1; i <= SSNFront.length - 1; i++) {
            sum = Integer.parseInt(SSNFront[i]) + i * 2;
        }
        for (int i = 1; i < SSNBack.length - 1; i++) {
            sum = Integer.parseInt(SSNBack[i]) + i * 8;
        }
        float temp = (int)(sum / 11.0f) * 11.0f + 11.0f - sum;
        temp = temp - (int)(temp / 10.0f) * 10.0f;
        SSNLast = SSNLast.concat(String.valueOf((int)temp));
        System.out.println("생성된 주민번호 : " + SSNFirst + " - " + SSNLast);
    }
}
