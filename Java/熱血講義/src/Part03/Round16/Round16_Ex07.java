package Part03.Round16;

import java.io.*;

public class Round16_Ex07 {
    public static void main(String[] args) throws IOException {
        DataOutputStream dataOutputStream = new DataOutputStream(new BufferedOutputStream(new FileOutputStream(new File("c:\\java\\work", "kimsh.txt"))));
        dataOutputStream.writeInt(23);
        dataOutputStream.writeDouble(12.345);
        dataOutputStream.writeBytes("ABCDEFG!!!");
        dataOutputStream.close();
    }
}
