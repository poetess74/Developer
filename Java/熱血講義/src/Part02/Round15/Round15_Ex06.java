package Part02.Round15;

import java.util.Date;

class A6 extends Thread {
    public void run() {
        while (true) {
            Date date = new Date();
            System.out.println("date = " + date.toString());
            try {
                Thread.sleep(1000);
            } catch (InterruptedException ie) { }
        }
    }
}
class B6 extends Thread {
    public void run() {
        for (int i = 0; i < 1000; i++) {
            System.out.println(i);
            try {
                Thread.sleep(400);
            } catch (InterruptedException ie) { }
        }
    }
}
public class Round15_Ex06 {
    public static void main(String[] args) {
        System.out.println("Main Start!!");
        A6 mt = new A6();
        B6 ms = new B6();
        mt.setDaemon(false);
        ms.setDaemon(false);
        mt.start();
        ms.start();
        System.out.println("Main End!!");
    }
}
