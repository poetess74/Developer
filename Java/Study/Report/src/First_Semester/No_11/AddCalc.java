package First_Semester.No_11;

import java.util.Scanner;
import java.util.StringTokenizer;

public class AddCalc {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("덧셈식 입력 : ");
        String input = scanner.nextLine();
        StringTokenizer stringTokenizer = new StringTokenizer(input, "+");
        int sum = 0;
        while(stringTokenizer.hasMoreTokens()) {
            String string = stringTokenizer.nextToken();
            string = string.trim();
            sum += Integer.parseInt(string);
        }
        System.out.println("합은 " + sum);
    }
}
