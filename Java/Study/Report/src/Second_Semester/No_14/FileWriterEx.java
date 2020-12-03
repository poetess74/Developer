package Second_Semester.No_14;

import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;

public class FileWriterEx {
	public static void main(String[] args) {
		InputStreamReader input = new InputStreamReader(System.in);
		FileWriter fout = null;
		int c;
		try {
			fout = new FileWriter("/Users/hm/Desktop/test.txt");
			while ((c = input.read()) != -1) {
				fout.write(c);
				fout.flush();
			}
			input.close();
			fout.close();
		} catch(IOException e) {
			System.err.println("I/O error");
		}
	}
}
