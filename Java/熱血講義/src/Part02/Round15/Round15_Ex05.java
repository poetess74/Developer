package Part02.Round15;

public class Round15_Ex05 {
    public static void main(String[] args) {
        int count = Thread.activeCount();
        System.out.println("count = " + count);
        Thread cnt = Thread.currentThread();
        System.out.println("cnt = " + cnt);
        System.out.println("cnt name = " + cnt.getName());
        try {
            Thread.sleep(2000);
        } catch (InterruptedException ie) {
            System.err.println("Thread.sleep(2000); 을 실행하는 도중 오류가 발생함");
        }
        System.out.println("cnt priority = " + cnt.getPriority());
        System.out.println("cnt alive = " + cnt.isAlive());
        System.out.println("cnt daemon = " + cnt.isDaemon());
    }
}
