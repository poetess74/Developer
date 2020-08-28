package Part02.Round15;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round15_Ex09 {
    protected static int aaa() {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        int age = 0;
        try {
            System.out.print("나이 = ");
            age = Integer.parseInt(in.readLine());
            return age;
        } catch (NumberFormatException nfe) {
            System.out.println("error = " + nfe.getMessage());
            return -1;
        } catch (IOException ie) {
            return -1;
        } finally {
            System.out.println("나이 : " + age);
        }
    }

    public static void main(String[] args) {
        System.out.println("Main Start!!");
        aaa();
        System.out.println("Main End!!");
    }
}
