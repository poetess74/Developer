package Second_Semester.No_2;

public class ScorePrinter {
	public static void main(String[] args) {
		double[][] score = {
				{3.3, 3.4}, {3.5, 3.6},
				{3.7, 4.0}, {4.1, 4.2}
		};
		double sum = 0;
		for(int year = 0; year < score.length; year++) {
			for(int term = 0; term < score[year].length; term++) {
				sum += score[year][term];
			}
		}
		int width = score.length;
		int height = score[0].length;

		System.out.println("4년 전체 평점 평균은 " + sum / (width * height));
	}
}
