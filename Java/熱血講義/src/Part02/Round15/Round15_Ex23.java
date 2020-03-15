package Part02.Round15;

import java.util.HashSet;
import java.util.Iterator;

class A23 { }
class B23 { }

public class Round15_Ex23 {
    public static void main(String[] args) {
        HashSet hashSet = new HashSet();
        A23 ap = new A23();
        B23 bp = new B23();
        String cp = "ABC";
        hashSet.add(ap);
        hashSet.add(bp);
        hashSet.add(cp);
        Iterator iterator = hashSet.iterator();
        while (iterator.hasNext()) {
            System.out.println(iterator.next());
        }
    }
}
