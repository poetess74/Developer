package Second_Semester.No_2;

import java.util.InputMismatchException;
import java.util.Scanner;

public class ThreeNumberAddCalc {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		System.out.println("정수 3개를 입력하세요. ");
		int sum = 0, num = 0;
		for(int i = 0; i < 3; i++) {
			System.out.print(i + ">>> ");
			try {
				num = scanner.nextInt();
			} catch(InputMismatchException error) {
				System.out.println("정수가 아닙니다. 다시 입력하세요!");
				scanner.next();
				i--;
				continue;
			}
			sum += num;
		}
		System.out.println("합은 " + sum);
		scanner.close();
	}
}
