package Second_Semester.No_6;

import java.util.*;

public class HashMapDicEx {
	public static void main(String[] args) {
		HashMap<String, String> dictionary = new HashMap<>();
		dictionary.put("baby", "아기");
		dictionary.put("love", "사랑");
		dictionary.put("apple", "사과");
		Set<String> keys = dictionary.keySet();
		Iterator<String> iterator = keys.iterator();
		while(iterator.hasNext()) {
			String key = iterator.next();
			String value = dictionary.get(key);
			System.out.printf("(%s, %s)", key, value);
		}
		System.out.println();
		Scanner scanner = new Scanner(System.in);
		while(true) {
			System.out.print("찾고 싶은 단어는? (종료: exit 입력) ");
			String input = scanner.next();
			if(input.equals("exit")) { System.out.println("단어찾기 종료"); break; }
			String output = dictionary.get(input);
			System.out.println(output == null ? input + "는 없는 단어입니다. " : output);
		}
	}
}
