package Part03.Round18;

import java.awt.*;

public class Round18_Ex13 {
    public static void main(String[] args) {
        Round18_Ex13_Sub round18_ex13_sub = new Round18_Ex13_Sub();
    }
}

class Round18_Ex13_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    protected Round18_Ex13_Sub() {
        super();
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
    protected void start() { }
}
