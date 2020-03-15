package Part03.Round16;

import java.io.File;

public class Round16_Ex01 {
    public static void main(String[] args) {
        File file = new File("c:\\java\\work");
        if (file.exists()) {
            file.delete();
        }
        try {
            Thread.sleep(3000);
        } catch (InterruptedException ie) { }
        System.out.println("시점 !!");
        try {
            Thread.sleep(3000);
        } catch (InterruptedException ie) { }
        if (!file.exists()) file.mkdir();
    }
}
