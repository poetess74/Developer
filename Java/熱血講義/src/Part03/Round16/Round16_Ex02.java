package Part03.Round16;

import java.io.File;
import java.io.IOException;

public class Round16_Ex02 {
    public static void main(String[] args) {
        File file = new File("c:\\java\\work");
        if(!file.exists()) file.mkdir();
        try {
            Thread.sleep(3000);
        } catch (InterruptedException ie) { }
        File file1 = new File(file, "abc.txt");
        if (!file1.exists()) {
            try {
                file1.createNewFile();
            } catch(IOException io) { }
        }
        if (file1.canWrite()) {
            file1.setReadOnly();
        }
    }
}
