//한 어린이의 키를 2000년도부터 2009년 사이에 1년 단위로 입력받아 벡터에 저장하라. 그리고 키가 가장 많이 자란 년도를 출력하라
package Second_Semester.No_6;

import java.util.Scanner;
import java.util.Vector;

public class ChildLongestHeight {
	public static void main(String[] args) {
		Vector<Integer> height = new Vector<>();
		Scanner scanner = new Scanner(System.in);
		System.out.println("2000~2009년 까지 1년 단위로 키(cm)를 입력");
		System.out.print(">> ");
		for(int i = 0; i < 10; i++) {
			height.add(scanner.nextInt());
		}
		float maximumGapValue = 0f;
		int maximumGapIndex = 0;
		for(int i = 1; i < height.size(); i++) {
			if(maximumGapValue < Math.abs(height.get(i - 1) - height.get(i))) {
				maximumGapValue = Math.abs(height.get(i - 1) - height.get(i));
				maximumGapIndex = i - 1;
			}
		}
		System.out.printf("가장 키가 많이 자란 년도는 200%d년 %.1fcm", maximumGapIndex, maximumGapValue);
	}
}
