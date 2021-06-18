package Second_Semester.No_3;

import java.util.Scanner;

class Phone {
	private String name, tel;
	public Phone(String name, String tel) {
		this.name = name; this.tel = tel;
	}
	public String getName() { return name; }
	public String getTel() { return tel; }
}

public class PhoneTest {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		Phone[] phones = new Phone[2];
		for(int i = 0; i < phones.length; i++) {
			System.out.print("이름과 전화번호 입력 >> ");
			phones[i] = new Phone(scanner.next(), scanner.next());
		}
		for(int i = 0; i < phones.length; i++) {
			System.out.printf("%s의 번호 %s\n", phones[i].getName(), phones[i].getTel());
		}
	}
}
