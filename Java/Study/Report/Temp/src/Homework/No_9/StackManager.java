package Homework.No_9;

import java.util.Scanner;

interface StackInterface {
    int length();
    String pop();
    boolean push(String obj);
}
class StringStack implements StackInterface {
    String[] strStack; int top;
    protected StringStack(int size) { strStack = new String[size]; top = 0; }
    public int length() { return top; }
    public String pop() { return top == 0 ? null : strStack[--top]; }
    public boolean push(String obj) {
        if (top == strStack.length) {
            return false;
        } else {
            strStack[top++] = obj;
            return true;
        }
    }
}
public class StackManager {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        StringStack stack = new StringStack(10);
        System.out.print(">> ");
        for (int i = 0; i < 5; i++) { stack.push(scanner.next()); }
        int count = stack.length();
        for (int i = 0; i < count; i++) { System.out.print(stack.pop() + " "); }
    }
}
