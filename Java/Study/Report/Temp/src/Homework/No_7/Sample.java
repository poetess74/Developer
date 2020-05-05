package Homework.No_7;

class SuperObject {
    protected void paint() { draw(); }
    protected void draw() {
        draw();
        System.out.println("Super Object");
    }
}

class SubObject extends SuperObject {
    protected void paint() { super.draw(); }
    protected void draw() { System.out.println("Sub Object"); }
}

public class Sample {
    public static void main(String[] args) {
        SuperObject superObject = new SubObject();
        superObject.paint();
    }
}

// 코드 실행 순서
// 17 - 18 - 19 - 12 - 5 - 6 - 13 - 7
