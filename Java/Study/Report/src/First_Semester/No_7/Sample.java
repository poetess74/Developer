package First_Semester.No_7;

class SuperObject {
    protected void paint() { draw(); }
    protected void draw() {
        draw(); // 동적 바인딩
        System.out.println("Super Object");
    }
}

class SubObject extends SuperObject {
    protected void paint() { super.draw(); /* 정적 바인딩 */ }
    protected void draw() { System.out.println("Sub Object"); }
}

public class Sample {
    public static void main(String[] args) {
        SuperObject superObject = new SubObject(); // 업 캐스팅
        superObject.paint(); // 동적 바인딩
    }
}

// 코드 실행 순서
// 17 - 18 - 19 - 12 - 5 - 6 - 13 - 7
