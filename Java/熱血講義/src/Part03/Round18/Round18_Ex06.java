package Part03.Round18;

import java.awt.*;

public class Round18_Ex06 {
    public static void main(String[] args) {
        Round18_Ex06_Sub round18_ex06_sub = new Round18_Ex06_Sub();
    }
}

class Round18_Ex06_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Label label = new Label("최초문자(좌측정렬) -> ", Label.LEFT);
    protected Round18_Ex06_Sub() {
        super();
        this.init();
        this.start();
        this.setSize(500, 200);
        dimension = Toolkit.getDefaultToolkit().getScreenSize();
        dimension1 = this.getSize();
        xpos = (int)(dimension.getWidth() / 2 - dimension1.getWidth() / 2);
        ypos = (int)(dimension.getHeight() / 2 - dimension1.getHeight() / 2);
        this.setLocation(xpos, ypos);
        this.setVisible(true);
        try {
            Thread.sleep(5000);
        } catch(InterruptedException ee) { }
        String string = label.getText().trim();
        label.setAlignment(Label.CENTER);
        label.setText(string + "다음정렬(중앙정렬) -> ");
        try {
            Thread.sleep(5000);
        } catch(InterruptedException ee) { }
        string = label.getText().trim();
        label.setAlignment(Label.RIGHT);
        label.setText(string + "마지막정렬(우측정렬)");
    }
    protected void init() {
        GridBagLayout gridBagLayout = new GridBagLayout();
        GridBagConstraints gridBagConstraints = new GridBagConstraints();
        this.setLayout(gridBagLayout);
        label.setBackground(Color.YELLOW);
        gridBagConstraints.fill = GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 1;
        gridBagLayout.setConstraints(label, gridBagConstraints);
        this.add(label);
    }
    protected void start() { }
}
