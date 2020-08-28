package Homework.No_10;

class A {
    public A(int x) {
        System.out.println("A" + x);
    }
}
class B extends A {
    public B() {
        super(20);
        System.out.println("B");
    }
    public B(int x) {
        super(x + 20);
        System.out.println("B" + x);
    }
}
public class C {
}
