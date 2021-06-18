package Part02.Round15;

import java.io.IOException;

public class Round15_Ex07 {
    public static void main(String[] args) {
        try {
            System.out.print("x = ");
            int x = System.in.read() - 48;
            System.out.println("x = " + x);
        } catch (IOException io) {
            System.err.println("Unexpected error raised. Please recheck input hardware system installed correctly.");
            System.exit(1);
        }
    }
}
