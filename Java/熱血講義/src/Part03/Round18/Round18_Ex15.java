package Part03.Round18;

import java.awt.*;

public class Round18_Ex15 {
    public static void main(String[] args) {
        Round18_Ex15_Sub round18_ex15_sub = new Round18_Ex15_Sub();
    }
}

class Round18_Ex15_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private MenuBar menuBar = new MenuBar();
    private Menu file = new Menu("파일");
    private Menu edit = new Menu("편집");
    private Menu view = new Menu("보기");
    private Menu help = new Menu("도움말");
    protected Round18_Ex15_Sub() {
        super("메뉴 만들기");
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
        this.setMenuBar(menuBar);
        menuBar.add(file);
        menuBar.add(edit);
        menuBar.add(view);
        menuBar.add(help);
    }
    protected void start() { }
}
