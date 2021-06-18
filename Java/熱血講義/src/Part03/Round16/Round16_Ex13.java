package Part03.Round16;

import java.io.*;

public class Round16_Ex13 {
    public static void main(String[] args) throws IOException {
        File dir = new File("c:\\java\\work");
        File file = new File(dir, "object.txt");
        FileInputStream fileInputStream = new FileInputStream(file);
        BufferedInputStream bufferedInputStream = new BufferedInputStream(fileInputStream);
        ObjectInputStream objectInputStream = new ObjectInputStream(bufferedInputStream);
        Object object = null;
        try {
            object = objectInputStream.readObject();
        } catch (ClassNotFoundException classNotFound) { }
        objectInputStream.close();
        Round16_Ex12_Sub ap = (Round16_Ex12_Sub)object;
        System.out.println("x = " + ap.x);
        System.out.println("y = " + ap.y);
    }
}
