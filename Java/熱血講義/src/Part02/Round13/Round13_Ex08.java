package Part02.Round13;

class A3 {
    public String toString() {
        return "A3 클래스";
    }
}
class B3 {
    public String toString() {
        return "B3 클래스";
    }
}

public class Round13_Ex08 {
    public static void main(String[] args) {
        Object[] obj = new Object[2];
        obj[0] = new A3();
        obj[1] = new B3();
        for (int i = 0; i < obj.length; i++) {
            System.out.println("obj[" + i + "] = " + obj[i]);
        }
    }
}
