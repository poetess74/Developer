package Second_Semester.Practice.No_3;

import java.util.Scanner;

class Rect {
	private int width, height;
	public Rect(int width, int height) {
		this.width = width;
		this.height = height;
	}
	public int getArea() { return width * height; }
}

public class RectArray {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		Rect[] rects = new Rect[4];
		for(int i = 0; i < rects.length; i++) {
			System.out.printf("%d 너비와 높이 >> ", i + 1);
			rects[i] = new Rect(scanner.nextInt(), scanner.nextInt());
		}
		System.out.println("저장하였습니다...");
		int areaSum = 0;
		for(var rect:rects) {
			areaSum += rect.getArea();
		}
		System.out.printf("사각형의 전체 합은 %d", areaSum); // 4개 사각형 넓이 합
	}
}
