package Second_Semester.No_2;

public class Multiplication_Table {
	public static void main(String[] args) {
		for(int i = 1; i < 10; i++) {
			for(int j = 1; j < 10; j++) {
				System.out.printf("%2d * %2d = %2d\t", i, j, i * j);
			}
			System.out.println();
		}
	}
}
