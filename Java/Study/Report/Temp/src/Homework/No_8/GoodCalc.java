package Homework.No_8;

abstract class Calculator {
    protected abstract int add(int a, int b);
    protected abstract int subtract(int a, int b);
    protected abstract double average(int[] a);
}

public class GoodCalc extends Calculator {
    protected int add(int a, int b) { return a + b; }
    protected int subtract(int a, int b) { return a - b; }
    protected double average(int[] a) {
        double sum = 0;
        for (int i = 0; i < a.length; i++) {
            sum += a[i];
        }
        return sum / a.length;
    }
    public static void main(String[] args) {
        GoodCalc calc = new GoodCalc();
        System.out.println(calc.add(2, 3));
        System.out.println(calc.subtract(2, 3));
        System.out.println(calc.average(new int[] {2, 3, 4}));
    }
}
