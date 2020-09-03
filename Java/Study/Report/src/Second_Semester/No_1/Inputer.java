package Second_Semester.No_1;

import java.util.Scanner;

public class Inputer {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		int sum = 0;
		System.out.print("두 정수를 입력하세요>> ");
		int[] numbers = new int[2];
		for(int i = 0; i < numbers.length; i++) {
			numbers[i] = scanner.nextInt();
		}
		for(int i = 0; i < numbers.length; i++) {
			if (i != 0) { System.out.print(" + "); }
			sum += numbers[i];
			System.out.print(numbers[i]);
		}
		System.out.print(" = ");
		System.out.print(sum);
	}
}
