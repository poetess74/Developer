package First_Semester.No_12;

import java.util.Iterator;
import java.util.Vector;

public class IteratorEx {
    public static void main(String[] args) {
        Vector<Integer> vectorEx = new Vector<Integer>();
        vectorEx.add(5);
        vectorEx.add(4);
        vectorEx.add(-1);
        vectorEx.add(2, 100);

        Iterator<Integer> iterator = vectorEx.iterator();
        while(iterator.hasNext()) {
            int n = iterator.next();
            System.out.println(n);
        }

        int sum = 0;
        iterator = vectorEx.iterator();
        while(iterator.hasNext()) {
            int n = iterator.next();
            sum += n;
        }
        System.out.println("벡터에 있는 정수 합 : " + sum);
    }
}
