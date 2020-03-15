package Part02.Round15;

import java.io.IOException;

public class Round15_Ex18 {
    public static void main(String[] args) throws IOException {
        Runtime rt = Runtime.getRuntime();
        System.out.print("1. 네이버 2. 다음 = ");
        int input = System.in.read() - 48;
        String string = "";
        string = input == 1 ? "https://www.naver.com" : "https://www.daum.net";
        rt.exec("explorer.exe" + string);
    }
}
