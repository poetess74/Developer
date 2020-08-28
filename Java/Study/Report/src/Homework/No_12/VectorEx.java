package Homework.No_12;

import java.util.Vector;

public class VectorEx {
    public static void main(String[] args) {
        Vector<Integer> vectorEx = new Vector<Integer>();
//        Vector<Integer> vectorEx2 = new Vector<>();
//        var vectorEx3 = new Vector<Integer>();
        vectorEx.add(5);
        vectorEx.add(4);
        vectorEx.add(-1);

        vectorEx.add(2, 100);
        System.out.println("벡터 내의 요소 객체 수: " + vectorEx.size());
        System.out.println("벡터의 용량 : " + vectorEx.capacity());

        for (int n : vectorEx) {
            System.out.println(n);
        }
        int sum = 0;
        for (int i = 0; i < vectorEx.size(); i++) {
            int n = vectorEx.elementAt(i);
            sum += n;
        }
        System.out.println("벡터에 있는 정수 합 : " + sum);
    }
}
