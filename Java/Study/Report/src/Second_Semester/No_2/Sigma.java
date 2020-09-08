package Second_Semester.No_2;

import java.util.Scanner;

public class Sigma {
	public static void main(String[] args) {
		System.out.print("정수 입력 > ");
		Scanner scanner = new Scanner(System.in);
		int input = scanner.nextInt();
		int result = 0;
		for(int i = 1; i <= input; i++) { result += i; }
		System.out.println("1 부터 " + input + "까지의 합 : " + result);
	}
}
