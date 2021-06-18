package Part03.Round18;

import java.awt.*;

public class Round18_Ex10 {
    public static void main(String[] args) {
        Round18_Ex10_Sub round18_ex10_sub = new Round18_Ex10_Sub();
    }
}

class Round18_Ex10_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Button button = new Button("-->");
    private Button button1 = new Button("<--");
    private List list = new List(10, true);
    private List list1 = new List(10);
    protected Round18_Ex10_Sub() {
        super("목록 선택");
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
        list.select(2);
        list.select(4);
        list.select(6);
        list.select(8);
        try {
            Thread.sleep(5000);
        } catch (InterruptedException ee) { }
        String[] strings = list.getSelectedItems();
        for (int i = 0; i < strings.length; i++) {
            list1.add(strings[i]);
        }
        try {
            Thread.sleep(5000);
        } catch (InterruptedException ee) { }
        list.deselect(2);
        list.deselect(4);
        list.deselect(6);
        list.deselect(8);
    }
    protected void init() {
        for (int i = 0; i < 20; i++) {
            list.add("TEST " + (i + 1));
        }
        GridBagLayout gridBagLayout = new GridBagLayout();
        GridBagConstraints gridBagConstraints = new GridBagConstraints();
        this.setLayout(gridBagLayout);
        gridBagConstraints.insets = new Insets(0, 0, 0, 10);
        gridBagLayout.setConstraints(list, gridBagConstraints);
        this.add(list);
        GridLayout gridLayout = new GridLayout(2, 1, 0, 20);
        Panel panel = new Panel(gridLayout);
        panel.add(button);
        panel.add(button1);
        gridBagConstraints.insets = new Insets(0, 0, 0, 0);
        gridBagLayout.setConstraints(panel, gridBagConstraints);
        this.add(panel);
        gridBagConstraints.insets = new Insets(0, 10, 0, 0);
        gridBagLayout.setConstraints(list1, gridBagConstraints);
        this.add(list1);
    }
    protected void start() { }
}
