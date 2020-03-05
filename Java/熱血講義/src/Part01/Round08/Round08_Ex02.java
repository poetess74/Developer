package Part01.Round08;

public class Round08_Ex02 {
    public static void main(String[] args) {
        if (args.length != 1) {
            System.out.println("Usage : java Round08_Ex02 num");
            System.exit(1);
        }
        int x = Integer.parseInt(args[0]);
        System.out.println("입력된 수 = " + x);
    }
}
