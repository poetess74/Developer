package Part03.Round16;

import java.io.File;
import java.util.Date;

public class Round16_Ex03 {
    public static void main(String[] args) {
        File file = new File("c:\\java\\work1");
        if (file.exists()) {
            file.deleteOnExit();
            System.out.println("파일명 : " + file.getName());
            System.out.println("파일 경로 : " + file.getPath());
            System.out.println("파일 경로 : " + file.getParent());
            System.out.println("파일 크기 : " + file.length() + " 바이트");
            System.out.println("최종 수정일 : " + new Date(file.lastModified()));
        } else {
            System.out.println(file.getName() + "라는 파일이 없습니다. ");
        }
    }
}
