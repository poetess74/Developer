package Part03.Round16;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class Round16_Ex10 {
    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(new FileReader(new File("c:\\java\\work", "kim.txt")));
        String data = in.readLine();
        in.close();
        System.out.println("Data = " + data);
    }
}
