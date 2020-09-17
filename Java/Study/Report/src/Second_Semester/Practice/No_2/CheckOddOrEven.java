package Second_Semester.Practice.No_2;

import java.util.InputMismatchException;
import java.util.Scanner;

public class CheckOddOrEven {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		while(true) {
			System.out.print("정수를 입력하세요 >> ");
			try {
				int input = scanner.nextInt();
				System.out.println(input % 2 == 0 ? "짝수" : "홀수");
			} catch(InputMismatchException error) {
				System.out.println("수를 입력하지 않아 프로그램을 종료합니다. ");
				break;
			}
		}
	}
}
