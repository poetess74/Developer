package Part02.Round15;

import java.util.Enumeration;
import java.util.Hashtable;

class AAA { }
class BBB { }

public class Round15_Ex25 {
    public static void main(String[] args) {
        Hashtable hashtable = new Hashtable();
        AAA ap = new AAA();
        BBB bp = new BBB();
        String cp = "JAVA";
        hashtable.put("kim", ap);
        hashtable.put("lee", bp);
        hashtable.put("park", cp);
        //Object object = hashtable.get("kim");
        Enumeration keys = hashtable.keys();
        System.out.println("Keys!!!");
        while (keys.hasMoreElements()) {
            System.out.println(keys.nextElement());
        }
        System.out.println("Keys End!!");
        System.out.println("Values!!!");
        Enumeration elements = hashtable.elements();
        while (elements.hasMoreElements()) {
            System.out.println(elements.nextElement());
        }
        System.out.println("Values End!!");
    }
}
