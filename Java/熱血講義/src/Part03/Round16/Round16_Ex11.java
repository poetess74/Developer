package Part03.Round16;

import java.io.*;

public class Round16_Ex11 {
    public static void main(String[] args) throws IOException {
        File dir = new File("c:\\java\\work");
        File file = new File(dir, "ksh.log");
        FileOutputStream fileOutputStream = new FileOutputStream(file, true);
        BufferedOutputStream bufferedOutputStream = new BufferedOutputStream(fileOutputStream,  1024);
        PrintStream printStream = new PrintStream(bufferedOutputStream);
        System.setErr(printStream);
        System.out.println("출력한다. 화면으로 ...");
        System.err.println("출력한다. 파일으로 ...");
        System.err.close();
    }
}
