package Homework.No_9;

interface Touchable { void touch(int x, int y); }
interface Callable { void request(String phoneNumber); }

class GalaxyNote implements Touchable, Callable {
    String name, company, os;
    GalaxyNote(String name, String company, String os) {
        this.name = name; this.company = company; this.os = os;
    }
    public void touch(int x, int y) { System.out.printf("%d, %d 좌표에 터치한다.\n", x, y); }
    public void request(String callLoc) { System.out.printf("%s 로 전화를 건다.\n", callLoc); }
    void printInfo() {
        System.out.println("이름: " + name);
        System.out.println("제조사: " + company);
        System.out.println("운영체제: " + os);
    }
}

public class GalaxyNoteEx {
    public static void main(String[] args) {
        GalaxyNote phone = new GalaxyNote("갤럭시노트9", "삼성", "안드로이드");
        System.out.println("*************************");
        phone.printInfo();
        System.out.println("*************************");
        phone.touch(10, 20); phone.request("010-1234-1111");
    }
}
