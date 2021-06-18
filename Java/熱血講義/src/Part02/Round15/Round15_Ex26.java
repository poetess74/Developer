package Part02.Round15;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class Round15_Ex26 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("문자열 = ");
        String string = in.readLine();
        System.out.print("구분자 = ");
        String del = in.readLine();
        System.out.println(":: 결과 ::");
        StringTokenizer stringTokenizer = new StringTokenizer(string, del);
        while (stringTokenizer.hasMoreTokens()) {
            System.out.println(stringTokenizer.nextToken());
        }
        System.out.println(":: 출력 끝 ::");
    }
}
