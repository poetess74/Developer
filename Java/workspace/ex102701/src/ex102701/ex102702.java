package ex102701;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintStream;
import java.util.ArrayList;

class Rec {
	String name;
	int kor;
	int mat;
	int eng;
	
    Rec(String name, int kor, int mat, int eng) {
    	this.name = name;
    	this.kor = kor;
    	this.mat = mat;
    	this.eng = eng;
    }

	public void print(PrintStream ps) {
		float tot = this.kor + this.mat + this.eng;
		float avg = tot / 3.0f;
		
		ps.printf("%s\t%3d\t%3d\t%3d\t%6.2f\t%6.2f\n",  
				this.name, 
				this.kor,
				this.mat,
				this.eng,
				tot,
				avg);
		
	}
}
public class ex102702 {
	public static void main(String[] args) throws IOException {
		BufferedReader br = new BufferedReader(new FileReader("data.txt"));
		
		ArrayList<Rec> records = new ArrayList<Rec>();
		
		String line;
		while ((line = br.readLine()) != null) {
			// StringTokenizer stok = new StringTokenizer(line, ",");
			String[] tokens = line.split(",");
			
			Rec rec = new Rec(
					tokens[0], 
					Integer.parseInt(tokens[1]),
					Integer.parseInt(tokens[2]),
					Integer.parseInt(tokens[3]));
			
			records.add(rec);
		}
		
		br.close();
		
		PrintStream ps = new PrintStream(new File("output.txt"));
		for (Rec r: records) {
			r.print(ps);
		}
		ps.close();
	}

}
