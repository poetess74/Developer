package Part03.Round16;

import java.io.*;

class Round16_Ex12_Sub implements Serializable {
    int x, y;
}

public class Round16_Ex12 {
    public static void main(String[] args) throws IOException {
        Round16_Ex12_Sub ap = new Round16_Ex12_Sub();
        ap.x = 100;
        ap.y = 200;
        File dir = new File("c:\\java\\work");
        File file = new File(dir, "object.txt");
        FileOutputStream fileOutputStream = new FileOutputStream(file);
        BufferedOutputStream bufferedOutputStream = new BufferedOutputStream(fileOutputStream);
        ObjectOutputStream objectOutputStream = new ObjectOutputStream(bufferedOutputStream);
        objectOutputStream.writeObject(ap);
        objectOutputStream.close();
    }
}
