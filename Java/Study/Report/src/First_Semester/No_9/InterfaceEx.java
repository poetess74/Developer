package First_Semester.No_9;

interface PhoneInterface {
    final int TIMEOUT = 10000;
    void sendCall();
    void receiveCall();
    default void printLogo() {
        System.out.println("** Phone **");
    }
}

class Calc {
    public int calculate(int x, int y) {
        return x + y;
    }
}

class SamsungPhone extends Calc implements PhoneInterface {
    public void sendCall() { System.out.println("띠리리리링"); }
    public void receiveCall() { System.out.println("전화가 왔습니다. "); }
    public void flash() { System.out.println("전화기에 불이 켜졌습니다. "); }
    public void schedule() { System.out.println("일정 관리합니다. "); }
}

public class InterfaceEx {
    public static void main(String[] args) {
        SamsungPhone phone = new SamsungPhone();
        phone.printLogo(); phone.sendCall();
        phone.receiveCall(); phone.flash();
        phone.schedule(); System.out.println("3과 5를 더하면 " + phone.calculate(3, 5));
    }
}
