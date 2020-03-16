package Part03.Round16;

import java.io.*;
import java.util.ArrayList;

public class Round16_01 {
    private static ArrayList<String> regen = new ArrayList<>();
    private static void regenList() {
        try {
            if (regen.isEmpty()) {
                System.out.println("등록된 글이 하나도 없습니다. ");
            } else {
                for (int i = 0; i < regen.size(); i++) {
                    System.out.println("[" + i + "] " + regen.get(i));
                }
            }
        } catch (IndexOutOfBoundsException outOfRange) {
            System.err.println("목록을 출력하는 도중 오류가 발생하였습니다. ");
            System.out.println();
        }
    }
    private static void writeRegen(String input) {
        regen.add(input);
    }
    private static void readRegen(int index) {
        try {
            System.out.println(regen.get(index));
        } catch (IndexOutOfBoundsException outOfRange) {
            System.err.println("목록을 확인 후 다시 선택하여 주십시오. ");
            System.out.println();
        }
    }
    private static void modifyRegen(int index, String input) {
        try {
            regen.add(index + 1, input);
            regen.remove(index);
        } catch (IndexOutOfBoundsException outOfRange) {
            System.err.println("목록을 확인 후 다시 선택하여 주십시오. ");
            System.out.println();
        }
    }
    private static void deleteRegen(int index) {
        try {
            regen.remove(index);
        } catch (IndexOutOfBoundsException outOfRange) {
            System.err.println("목록을 확인 후 다시 선택하여 주십시오. ");
            System.out.println();
        }
    }

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
                case 6:
                    try {
                        File dir = new File("c:\\java\\work");
                        File file = new File(dir, "regen.txt");
                        ObjectOutputStream objectOutputStream = new ObjectOutputStream(new BufferedOutputStream(new FileOutputStream(file)));
                        objectOutputStream.writeObject(regen);
                        objectOutputStream.close();
                    } catch (FileNotFoundException noSuchFile) {
                        System.err.println("저장할 파일을 찾을 수 없습니다. ");
                    } catch (IOException ioe) { }
                    System.exit(0);
                    break;
                default: System.err.println("잘못 입력하셨습니다. "); System.out.println(); break;
            }
        }
    }
}
