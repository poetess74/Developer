package Second_Semester.Practice_2;

import java.util.Scanner;

public class ArrayPrintTreeMultiples {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		int[] inputNumber = new int[10];
		System.out.print("정수 10개 입력 >> ");
		for(int i = 0; i < inputNumber.length; i++) {
			inputNumber[i] = scanner.nextInt();
		}
		for(var input:inputNumber) {
			if (input % 3 == 0) {
				System.out.print(input + " ");
			}
		}
		System.out.println();
	}
}
