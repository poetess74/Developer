package Part03.Round16;

import java.io.*;

public class Round16_Ex05 {
    public static void main(String[] args) {
        File file = new File("c:\\java\\work\\abc.txt");
        try {
            FileOutputStream fileOutputStream = new FileOutputStream(FileDescriptor.out);
            FileOutputStream fileOutputStream1 = new FileOutputStream(file);
            byte[] data = {66, 68, 70, 72, (byte) '!'};
            fileOutputStream.write(data);
            fileOutputStream1.write(data);
            //fileOutputStream.close();
            //fileOutputStream1.close();
        } catch (FileNotFoundException noFileSuch) {
            System.err.println("파일이 존재하지 않음.");
            System.exit(1);
        } catch (IOException io) {
            System.err.println("파일 쓰기 권한이 없음. ");
            System.exit(1);
        }
        System.out.println("실행 끝.. !");
    }
}
