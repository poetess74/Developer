package Part01.Round06;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round06_Ex02 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        int firstInput, secondInput, thirdInput, temp;
        System.out.print("첫번째 수 = ");
        firstInput = Integer.parseInt(in.readLine());
        System.out.print("두번째 수 = ");
        secondInput = Integer.parseInt(in.readLine());
        System.out.print("세번째 수 = ");
        thirdInput = Integer.parseInt(in.readLine());
        if (secondInput >= firstInput && secondInput >= thirdInput) {
            temp = firstInput;
            firstInput = secondInput;
            secondInput= temp;
        } else if (thirdInput >= firstInput && thirdInput >= secondInput) {
            temp = firstInput;
            firstInput = thirdInput;
            thirdInput = temp;
        }
        if (thirdInput >= secondInput) {
            temp = secondInput;
            secondInput = thirdInput;
            thirdInput = temp;
        }
        System.out.println();
        System.out.println(firstInput + " >= " + secondInput + " >= " + thirdInput);
    }
}
