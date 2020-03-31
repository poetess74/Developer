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
    private Dialog dialog = new Dialog(this, "종속된 Dialog1", false);
    private Label dialogLabel = new Label("종속된 Dialog1 이다. ", Label.CENTER);
    private Dialog dialog1 = new Dialog(this, "종속된 Dialog2", false);
    private Label dialog1Label1 = new Label("종속된 Dialog2 이다. ", Label.CENTER);
    protected Round18_Ex13_Sub() {
        super("최상위 Frame!!!");
        this.init();
        this.start();
        this.setSize(300, 200);
        dimension = Toolkit.getDefaultToolkit().getScreenSize();
        dimension1 = this.getSize();
        xpos = (int)(dimension.getWidth() / 2 - dimension1.getWidth() / 2);
        ypos = (int)(dimension.getHeight() / 2 - dimension1.getHeight() / 2);
        this.setLocation(xpos, ypos);
        this.setVisible(true);
        try {
            Thread.sleep(5000);
        } catch (InterruptedException ee) { }
        dialog.setVisible(true);
        try {
            Thread.sleep(5000);
        } catch (InterruptedException ee) { }
        dialog.setVisible(false);
        dialog1.setVisible(true);
        try {
            Thread.sleep(5000);
        } catch (InterruptedException ee) { }
        dialog1.setVisible(false);
    }
    protected void init() {
        Dimension dimension = Toolkit.getDefaultToolkit().getScreenSize();
        BorderLayout borderLayout = new BorderLayout();
        dialog.setLayout(borderLayout);
        dialog.add("Center", dialogLabel);
        dialog.setSize(150, 120);
        Dimension dimension2 = dialog.getSize();
        int xpos1 = (int)(dimension.getWidth() / 2 - dimension2.getWidth() / 2);
        int ypos1 = (int)(dimension.getHeight() / 2 - dimension2.getHeight() / 2);
        dialog.setLocation(xpos1, ypos1);
        BorderLayout borderLayout1 = new BorderLayout();
        dialog1.setLayout(borderLayout1);
        dialog1.add("Center", dialog1Label1);
        dialog1.setSize(150, 120);
        Dimension dimension3 = dialog1.getSize();
        int xpos2 = (int)(dimension.getWidth() / 2 - dimension3.getWidth() / 2);
        int ypos2 = (int)(dimension.getHeight() / 2 - dimension3.getHeight() / 2);
        dialog1.setLocation(xpos2, ypos2);
    }
    protected void start() { }
}
