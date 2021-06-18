package Part03.Round18;

import java.awt.*;

public class Round18_Ex09 {
    public static void main(String[] args) {
        Round18_Ex09_Sub round18_ex09_sub = new Round18_Ex09_Sub();
    }
}

class Round18_Ex09_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Label label = new Label("생년월일: ", Label.RIGHT);
    private Label label1 = new Label("년", Label.LEFT);
    private Label label2 = new Label("월", Label.LEFT);
    private Label label3 = new Label("일", Label.LEFT);
    private Choice choice = new Choice();
    private Choice choice1 = new Choice();
    private Choice choice2 = new Choice();
    protected Round18_Ex09_Sub() {
        super("출생일");
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
        choice.select("1980");
        choice1.select("12");
        choice2.select("25");
        choice2.requestFocus();
    }
    protected void init() {
        for (int i = 2004; i >= 1970; i--) {
            choice.add(String.valueOf(i));
        }
        for (int i = 1; i <= 12; i++) {
            choice1.add(String.valueOf(i));
        }
        for (int i = 1; i <= 31; i++) {
            choice2.add(String.valueOf(i));
        }
        GridBagLayout gridBagLayout = new GridBagLayout();
        GridBagConstraints gridBagConstraints = new GridBagConstraints();
        this.setLayout(gridBagLayout);
        gridBagLayout.setConstraints(label, gridBagConstraints);
        this.add(label);
        gridBagLayout.setConstraints(choice, gridBagConstraints);
        this.add(choice);
        gridBagLayout.setConstraints(label1, gridBagConstraints);
        this.add(label1);
        gridBagLayout.setConstraints(choice1, gridBagConstraints);
        this.add(choice1);
        gridBagLayout.setConstraints(label2, gridBagConstraints);
        this.add(label2);
        gridBagLayout.setConstraints(choice2, gridBagConstraints);
        this.add(choice2);
        gridBagLayout.setConstraints(label3, gridBagConstraints);
        this.add(label3);
    }
    protected void start() { }
}
