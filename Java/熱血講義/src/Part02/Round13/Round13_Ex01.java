package Part02.Round13;

class Inherit extends Object { }
public class Round13_Ex01 extends Object {
    public static void main(String[] args) {
        Inherit in = new Inherit();
        System.out.println("두 객체가 같니 ? " + in.equals(in));
        System.out.println("in 객체의 클래스 이름은 ? " + in.getClass());
        System.out.println("in 객체의 hashCode 는 ? " + in.hashCode());
        System.out.println("in 객체를 표현하는 기본 문자열은 ? " + in.toString());
        System.out.println("in 객체를 표현하는 기본 문자열 약식은 ? " + in);
    }
}
