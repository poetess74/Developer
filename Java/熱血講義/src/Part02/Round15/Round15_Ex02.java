package Part02.Round15;

class A2 extends Thread {
    public void run() {
        System.out.println("\nHere is MyThread!!");
        for (int i = 0; i < 100; i++) {
            for (char ch = 'A'; ch <= 'z'; ch++) {
                System.out.print(ch);
            }
        }
    }
}
public class Round15_Ex02 {
    public static void main(String[] args) {
        System.out.println("Main Thread!!!");
        A2 mt = new A2();
        mt.start();
        for (int i = 1; i < 1000; i++) {
            System.out.print(i);
            System.out.print(i % 10 == 0 ? "\n" : "\t");
        }
        System.out.println("\nMain Thread Destroy!!");
    }
}
