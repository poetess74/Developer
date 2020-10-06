package Second_Semester.No_6;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Scanner;
import java.util.Set;

public class MaximumPeoples {
	public static void main(String[] args) {
		HashMap<String, Integer> nations = new HashMap<>();
		Scanner scanner = new Scanner(System.in);
		System.out.println("나라 이름과 인구를 5개 입력하세요. (예: Korea 5000)");
		for(int i = 0; i < 5; i++) {
			System.out.print("나라 이름, 인구 >> ");
			nations.put(scanner.next(), scanner.nextInt());
		}
		Set<String> keys = nations.keySet();
		Iterator<String> country = keys.iterator();
		int maxPeople = 0;
		String maxCountry = "";
		while(country.hasNext()) {
			String name = country.next();
			Integer peopleCount = nations.get(name);
			if (peopleCount > maxPeople) { maxCountry = name; maxPeople = peopleCount; }
		}
		System.out.printf("제일 인구가 많은 나라는 (%s, %d)", maxCountry, maxPeople);
	}
} //김형민
