package Part03.Round18;

import java.awt.*;

public class Round18_Ex01 {
    public static void main(String[] args) {
        Round18_Ex01_Sub round18_ex01_sub = new Round18_Ex01_Sub();
    }
}

class Round18_Ex01_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Label label = new Label("Test");
    private Label label1 = new Label("Test");
    protected Round18_Ex01_Sub() {
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
        BorderLayout borderLayout = new BorderLayout();
        this.setLayout(borderLayout);
        label.setBackground(Color.YELLOW);
        label1.setBackground(Color.MAGENTA);
        GridLayout gridLayout = new GridLayout(5, 5);
        Panel panel = new Panel(gridLayout); this.add("South", panel);
        panel.add(label);
        panel.add(label1);
    }
    protected void start() {
    }
}
