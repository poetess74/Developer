package Part03.Round18;

import java.awt.*;

public class Round18_Ex04 {
    public static void main(String[] args) {
        Round18_Ex04_Sub round18_ex04_sub = new Round18_Ex04_Sub();
    }
}

class Round18_Ex04_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Label label = new Label("Test");
    protected Round18_Ex04_Sub() {
        super();
        this.init();
        this.start();
        this.setSize(250, 200);
        dimension = Toolkit.getDefaultToolkit().getScreenSize();
        dimension1 = this.getSize();
        xpos = (int)(dimension.getWidth() / 2 - dimension1.getWidth() / 2);
        ypos = (int)(dimension.getHeight() / 2 - dimension1.getHeight() / 2);
        this.setLocation(xpos, ypos);
        this.setVisible(true);
    }
    protected void init() {
        Cursor cursor = new Cursor(Cursor.HAND_CURSOR);
        Cursor cursor1 = new Cursor(Cursor.WAIT_CURSOR);
        this.setCursor(cursor);
        FlowLayout flowLayout = new FlowLayout();
        this.setLayout(flowLayout);
        label.setCursor(cursor1);
        label.setBackground(Color.YELLOW);
        this.add(label);
    }
    protected void start() { }
}
