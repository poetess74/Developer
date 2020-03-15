package Part03.Round16;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Round16_01 {
    private static void regenList() { }
    private static void writeRegen(String input) { }
    private static void readRegen(int index) { }
    private static void modifyRegen(int index, String input) { }
    private static void deleteRegen(int index) { }

    public static void main(String[] args) {
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        while (true) {
            System.out.print("1. 목록 2. 쓰기 3. 읽기 4. 수정 5. 삭제 6. 종료 ==> ");
            int input = 0;
            try {
                input = Integer.parseInt(in.readLine());
            } catch (IOException ignored) {} catch (NumberFormatException ne) {
                System.err.println("잘못 입력하셨습니다. ");
                System.out.println();
                continue;
            }
            switch (input) {
                case 1: regenList(); break;
                case 2:
                    System.out.println("=== 작성할 내용 입력 ===");
                    System.out.print("> ");
                    String write = "";
                    try {
                        write = in.readLine();
                    } catch (IOException ignored) {}
                    writeRegen(write);
                    break;
                case 3:
                    System.out.print("읽을 글 번호 ? => ");
                    try {
                        input = Integer.parseInt(in.readLine());
                    } catch (IOException ignored) {} catch (NumberFormatException ne) {
                        System.err.println("잘못 입력하셨습니다. ");
                        System.out.println();
                        continue;
                    }
                    readRegen(input);
                    break;
                case 4:
                    System.out.print("수정할 글 번호 ? => ");
                    try {
                        input = Integer.parseInt(in.readLine());
                    } catch (IOException ignored) {} catch (NumberFormatException ne) {
                        System.err.println("잘못 입력하셨습니다. ");
                        System.out.println();
                        continue;
                    }
                    write = "";
                    System.out.println("=== 작성할 내용 입력 ===");
                    System.out.print("> ");
                    try {
                        write = in.readLine();
                    } catch (IOException ignored) {}
                    modifyRegen(input, write);
                    break;
                case 5:
                    System.out.print("삭제할 글 번호 ? => ");
                    try {
                        input = Integer.parseInt(in.readLine());
                    } catch (IOException ignored) {} catch (NumberFormatException ne) {
                        System.err.println("잘못 입력하셨습니다. ");
                        System.out.println();
                        continue;
                    }
                    deleteRegen(input);
                    break;
                case 6: System.exit(0); break;
                default: System.err.println("잘못 입력하셨습니다. "); System.out.println(); break;
            }
        }
    }
}
