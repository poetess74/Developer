package Part03.Round16;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.Serializable;

public class Round16_Ex14 implements Serializable {
    private String name;
    private String SSN;
    private String telephone;
    private String address;
    private static transient BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
    protected Round16_Ex14() throws IOException {
        System.out.print("name = ");
        name = in.readLine();
        System.out.print("SSN = ");
        SSN = in.readLine();
        System.out.print("telephone = ");
        telephone = in.readLine();
        System.out.print("address = ");
        address = in.readLine();
    }
    protected void disp() {
        System.out.print(name + "\t");
        System.out.print(SSN + "\t");
        System.out.print(telephone + "\t");
        System.out.println(address);
    }
}
