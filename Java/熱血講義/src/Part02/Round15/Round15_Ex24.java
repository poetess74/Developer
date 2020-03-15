package Part02.Round15;

import java.util.Enumeration;
import java.util.Vector;

class A24 { }
class B24 { }

public class Round15_Ex24 {
    public static void main(String[] args) {
        Vector vector = new Vector();
        A24 ap = new A24();
        B24 bp = new B24();
        String cp = "TEST";
        vector.addElement(ap);
        vector.add(bp);
        vector.add(cp);
        for (int i = 0; i < vector.size(); i++) {
            Object object = vector.elementAt(i);
            System.out.println(i + " : " + object);
        }
        Enumeration enumeration = vector.elements();
        while (enumeration.hasMoreElements()) {
            System.out.println(enumeration.nextElement());
        }
    }
}
