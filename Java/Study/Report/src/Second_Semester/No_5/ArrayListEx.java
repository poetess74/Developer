package Second_Semester.No_5;

import java.util.ArrayList;
import java.util.Scanner;

public class ArrayListEx {
	public static void main(String[] args) {
		ArrayList<String> arrayList = new ArrayList<String>();
		Scanner scanner = new Scanner(System.in);
		for(int i = 0; i < 4; i++) {
			System.out.print("이름을 입력하세요 >> ");
			String string = scanner.next();
			arrayList.add(string);
		}
		for(int i = 0; i < arrayList.size(); i++) {
			String name = arrayList.get(i);
			System.out.print(name + " ");
		}
		int longestIndex = 0;
		for(int i = 0; i < arrayList.size(); i++) {
			if (arrayList.get(longestIndex).length() < arrayList.get(i).length()) {
				longestIndex = i;
			}
		}
		System.out.println("\n가장 긴 이름은 : " + arrayList.get(longestIndex));
	}
}
