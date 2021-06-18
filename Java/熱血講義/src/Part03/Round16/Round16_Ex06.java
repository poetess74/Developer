package Part03.Round16;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

public class Round16_Ex06 {
    public static void main(String[] args) throws IOException {
        File file = new File("c:\\java\\work\\abc.txt");
        FileInputStream fileInputStream = new FileInputStream(file);
        byte[] bytes = new byte[65536];
        int count = fileInputStream.read(bytes);
        for (int i = 0; i < count; i++) {
            System.out.println(i + " : " + (char)bytes[i]);
        }
    }
}
