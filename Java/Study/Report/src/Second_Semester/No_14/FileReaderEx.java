package Second_Semester.No_14;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class FileReaderEx {
	public static void main(String[] args) {
		FileReader input = null;
		try {
			input = new FileReader("/Users/hm/Library/Logs/IdeaIC2019.3/idea_updater.log");
			int c;
			while ((c = input.read()) != -1) {
				System.out.print((char)c);
			}
			input.close();
		} catch(FileNotFoundException e) {
			System.err.println("No such file or directory");
		} catch(IOException e) {
			System.err.println("I/O error");
		}
	}
}
