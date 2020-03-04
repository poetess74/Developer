package Round05;

public class Round05_01 {
    public static void main(String[] args) throws java.io.IOException {
        System.out.print("성별을 입력하세요. (남성 : 1, 여성 : 2) : ");
        int input = System.in.read() - 48;
        System.out.println(input == 1 ? "당신은 남성입니다. " : "당신은 여성입니다. ");
    }
}
