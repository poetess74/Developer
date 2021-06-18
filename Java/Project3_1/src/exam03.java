public class exam03 {
    public static void main(String args[]) {
        int count = 85;

        if (count >= 60) {
            System.out.println("합격");
        } else {
            System.out.println("불합격");
        }

        int score = (count / 10) * 10;

        switch (score) {
            case 100:
            case 90:
            case 80:
            case 70:
            case 60:
                System.out.println("합격");
                break;
                default:
                    System.out.println("불합격");
        }
    }
}
