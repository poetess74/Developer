package Part01.Round05;

public class Round05_02 {
    public static void main(String[] args) throws java.io.IOException {
        System.out.print("산술 연산자를 입력하세요. ('+', '-', '*', '/', '%') : ");
        char input = (char)System.in.read();
        System.out.println(input == '+' || input == '-' || input == '*' || input == '/' || input == '%' ? "'" + input + "'는 산술 연산자 입니다. " : "'"+ input + "'는 산술 연산자가 아닙니다. ");
    }
}
