package Part02.Round10;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round10_02 {
    private String userName, userSSN, userPhone, userAddress, userJob;
    private float userHeight, userWeight;

    private static void PersonInfo() throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        Round10_02 rd = new Round10_02();
        System.out.print("이름 = ");
        rd.userName = in.readLine();
        System.out.print("주민번호 = ");
        rd.userSSN= in.readLine();
        System.out.print("전화번호 = ");
        rd.userPhone= in.readLine();
        System.out.print("주소 = ");
        rd.userAddress= in.readLine();
        System.out.print("키 = ");
        rd.userHeight= Integer.parseInt(in.readLine());
        System.out.print("몸무게 = ");
        rd.userWeight= Integer.parseInt(in.readLine());
        System.out.print("직업 = ");
        rd.userJob= in.readLine();

        System.out.println("이름 = " + rd.userName);
        System.out.println("주민번호 = " + rd.userSSN);
        System.out.println("전화번호 = " + rd.userPhone);
        System.out.println("주소 = " + rd.userAddress);
        System.out.println("키 = " + rd.userHeight);
        System.out.println("몸무게 = " + rd.userWeight);
        System.out.println("직업 = " + rd.userJob);
    }

    public static void main(String[] args) throws IOException {
        PersonInfo();
    }
}
