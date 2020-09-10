package Second_Semester.Practice_2;

public class ZeroToNineMatrixSum {
	public static void main(String[] args) {
		int[][] intArray;
		intArray = new int[3][4];

		for(int i = 0; i < intArray.length; i++) {
			for(int j = 0; j < intArray[i].length; j++) {
				intArray[i][j] = (int)(Math.random() * 10);
				System.out.print(intArray[i][j] + " ");
			}
			System.out.println();
		}

		int i = 0, sum = 0;
		while(i < 3) {
			for(int j = 0; j < intArray[i].length; j++) {
				sum += intArray[i][j];
			}
			i++;
		}
		System.out.println("합은 " + sum);
	}
}
