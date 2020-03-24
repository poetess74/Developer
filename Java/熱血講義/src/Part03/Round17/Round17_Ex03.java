package Part03.Round17;

import java.awt.*;

public class Round17_Ex03 {
    public static void main(String[] args) {
        Round17_Ex03_Sub round17_ex03_sub = new Round17_Ex03_Sub();
    }
}

class Round17_Ex03_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Label label = new Label("AAA");
    private Label label1 = new Label("BBB");
    private Label label2 = new Label("CCC");

    protected Round17_Ex03_Sub() {
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
        FlowLayout flowLayout = new FlowLayout(FlowLayout.CENTER);
        this.setLayout(flowLayout);
        label.setForeground(Color.BLACK);
        label.setBackground(Color.YELLOW);
        label1.setForeground(Color.BLACK);
        label1.setBackground(Color.YELLOW);
        label2.setForeground(Color.BLACK);
        label2.setBackground(Color.YELLOW);
        this.add(label);
        this.add(label1);
        this.add(label2);
    }
    protected void start() { }
}
