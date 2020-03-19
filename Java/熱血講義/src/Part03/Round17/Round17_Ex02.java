package Part03.Round17;

import java.awt.*;

public class Round17_Ex02 {
    public static void main(String[] args) {
        Round17_Ex02_Sub round17_ex02_sub = new Round17_Ex02_Sub();
    }
}

class Round17_Ex02_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    protected Round17_Ex02_Sub() {
        super("제목 넣기");
        this.init();
        this.start();
        this.setSize(300, 200);
        dimension = Toolkit.getDefaultToolkit().getScreenSize();
        dimension1 = this.getSize();
        xpos = (int)(dimension.getWidth() / 2 - dimension1.getWidth() / 2);
        ypos = (int)(dimension.getHeight() / 2 - dimension1.getHeight() / 2);
        this.setLocation(xpos, ypos);
        this.setVisible(true);
    }

    protected void init() {
    }
    protected void start() {
    }
}
