import java.util.*;

public class Test {
    public static void main(String[] args) throws Throwable {
        for (int i = 0; i < 10; i++) {
            final int no = i;
            new Thread() {
                public void run() {
                    long t = 0;
                    while (true) {
                        t++;
                        if (t % 10000 == 0) {
                            System.out.println("Thread #" + (no + 1) + " - " + t);
                        }
                    }
                }
            }.start();
        }
    }
}
