package Part02.Round10;

import java.io.IOException;

public class Round10_Ex11 {
    public static void main(String[] args) throws IOException {
        System.out.println("좌표 값 처리");
        Round10_Ex10 rd = new Round10_Ex10();
        rd.setX();
        rd.setY();
        rd.display();
        System.out.println("좌표를 50, 100으로 이동합니다. ");
        rd.setX(50);
        rd.setY(100);
        rd.display();
    }
}
