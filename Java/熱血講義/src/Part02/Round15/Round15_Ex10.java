package Part02.Round15;

import java.io.PrintStream;
import java.io.PrintWriter;

class MyException extends Exception {
    private String message;
    private Throwable cause;
    protected MyException() {
        super();
    }
    protected MyException(String message) {
        super();
        this.message = message;
    }
    protected MyException(Throwable cause) {
        super();
        this.cause = cause;
    }
    protected MyException(String message, Throwable cause) {
        super();
        this.message = message;
        this.cause = cause;
    }
    protected void setCause(Throwable cause) {
        this.cause = cause;
    }
    public Throwable getCause() {
        return cause;
    }
    protected void setMessage(String message) {
        this.message = message;
    }
    public String getMessage() {
        return message;
    }
    public void printStackTrace() {
        System.out.println(":: Error 발생 !! ::");
        System.out.println("에러 사유 = " + message);
        System.out.println("관련 클래스 = " + cause);
        System.out.println(":: Error 출력 끝 !! ::");
    }
    public void printStackTrace(PrintStream out) {
        super.printStackTrace(out);
    }
    public void printStackTrace(PrintWriter out) {
        super.printStackTrace(out);
    }
}

public class Round15_Ex10 {
    public static void main(String[] args) {
        int x = 100, y = 0, total = 0;
        try {
            total = x / y;
        } catch (ArithmeticException ae) {
            MyException myException = new MyException("나눗셈", ae);
            myException.printStackTrace();
        }
        System.out.println("tot = " + total);
    }
}
