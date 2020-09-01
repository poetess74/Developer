package First_Semester.No_7;

import java.util.Scanner;

class Phone {
    private String name, telephone;
    protected Phone() { name = "홍길동"; telephone = "000-0000-0000"; }
    protected Phone(String name, String telephone) { this.name = name; this.telephone = telephone; }

    protected String getTelephone() { return telephone; }
    protected String getName() { return name; }
    protected void setName(String name) { this.name = name; }
    protected void setTelephone(String telephone) { this.telephone = telephone; }
}
public class PhoneManager {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("인원수>> ");
        Phone[] phones = new Phone[scanner.nextInt()];
        Phone phone = new Phone();
        for (int i = 0; i < phones.length; i++) {
            System.out.print("이름과 전화번호 (번호는 연속적으로 입력)>> ");
            phones[i] = new Phone(scanner.next(), scanner.next());
        }
        System.out.println("저장되었습니다. ");
        while (true) {
            System.out.print("검색할 이름>> ");
            String name = scanner.next();
            if (name.equals("exit")) {
                System.out.println("프로그램을 종료합니다. ");
                break;
            }
            int i = 0;
            for (i = 0; i < phones.length; i++) {
                if(name.equals(phones[i].getName())) {
                    System.out.println(phones[i].getName());
                    break;
                }
            }
            if (i == phones.length) {
                System.out.println(name + "이 존재하지 않습니다. ");
            }
        }
    }
}
