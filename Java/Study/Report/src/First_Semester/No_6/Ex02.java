package First_Semester.No_6;

import java.util.Scanner;

class Phone {
    private String name, telephone;
    protected Phone(String name, String telephone) {
        this.name = name; this.telephone = telephone;
    }
    protected String getName() { return name; }
    protected String getTelephone() { return telephone; }
}

public class Ex02 {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.print("이름과 전화번호 입력>> ");
        Phone phone1 = new Phone(in.next(), in.next());
        System.out.print("이름과 전화번호 입력>> ");
        Phone phone2 = new Phone(in.next(), in.next());
        System.out.println(phone1.getName() + "의 번호 " + phone1.getTelephone());
        System.out.println(phone2.getName() + "의 번호 " + phone2.getTelephone());
    }
}
