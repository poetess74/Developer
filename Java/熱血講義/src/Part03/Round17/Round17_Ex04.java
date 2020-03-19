package Part03.Round17;

import java.awt.*;

public class Round17_Ex04 {
    public static void main(String[] args) {
        Round17_Ex04_Sub round17_ex04_sub = new Round17_Ex04_Sub();
    }
}

class Round17_Ex04_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Label label = new Label("AAA");
    private Label label1 = new Label("BBB");
    private Label label2 = new Label("CCC");
    private Label label3 = new Label("DDD");
    private Label label4 = new Label("EEE");
    private Label label5 = new Label("FFF");
    private Label label6 = new Label("GGG");
    private Label label7 = new Label("HHH");
    private Label label8 = new Label("III");
    private Label label9 = new Label("JJJ");
    protected Round17_Ex04_Sub() {
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
        label.setBackground(Color.YELLOW);
        label1.setBackground(Color.YELLOW);
        label2.setBackground(Color.YELLOW);
        label3.setBackground(Color.YELLOW);
        label4.setBackground(Color.YELLOW);
        label5.setBackground(Color.YELLOW);
        label6.setBackground(Color.YELLOW);
        label7.setBackground(Color.YELLOW);
        label8.setBackground(Color.YELLOW);
        label9.setBackground(Color.YELLOW);
        GridBagLayout gridBagLayout = new GridBagLayout();
        GridBagConstraints gridBagConstraints = new GridBagConstraints();
        this.setLayout(gridBagLayout);
        gridBagConstraints.weightx = 5;
        gridBagLayout.setConstraints(label, gridBagConstraints); this.add(label);
        gridBagConstraints.weightx = 2;
        gridBagLayout.setConstraints(label1, gridBagConstraints); this.add(label1);
        gridBagConstraints.weightx = 1;
        gridBagLayout.setConstraints(label2, gridBagConstraints); this.add(label2);
    }
    protected void start() {
    }
}
