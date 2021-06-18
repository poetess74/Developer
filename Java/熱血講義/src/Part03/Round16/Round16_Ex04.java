package Part03.Round16;

import java.io.File;

public class Round16_Ex04 {
    public static void main(String[] args) {
        File file = new File("c:\\java\\eclipse\\workspace\\Round16_Examples");
        //String[] files = file.list();
        File[] files = file.listFiles();
        for (int i = 0, j = 0; i < files.length; i++) {
            if(files[i].getName().endsWith(".java")) {
                System.out.println(j++ + 1 + " : " + files[i].getName());
            }
        }
    }
}
