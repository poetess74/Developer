package Part03.Round16;

import java.io.*;

public class Round16_Ex08 {
    public static void main(String[] args) {
        DataInputStream dataInputStream = null;
        try {
            dataInputStream = new DataInputStream(new BufferedInputStream(new FileInputStream(new File("c:\\java\\work", "kimsh.txt"))));
        } catch (FileNotFoundException noSuchFile) { }
        int a = 0; double b = 0; byte[] c = null;
        try {
            a = dataInputStream.readInt();
            b = dataInputStream.readDouble();
            c = new byte[10];
            dataInputStream.read(c);
            dataInputStream.close();
        } catch (IOException ie) { }
        System.out.println("a = " + a);
        System.out.println("b = " + b);
        System.out.println("c = " + new String(c));
    }
}
