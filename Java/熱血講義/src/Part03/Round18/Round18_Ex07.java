package Part03.Round18;

import java.awt.*;

public class Round18_Ex07 {
    public static void main(String[] args) {
        Round18_Ex07_Sub round18_ex07_sub = new Round18_Ex07_Sub();
    }
}

class Round18_Ex07_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Button[] buttons = new Button[12];
    protected Round18_Ex07_Sub() {
        super("전화기 자판");
        this.init();
        this.start();
        this.setSize(300, 400);
        dimension = Toolkit.getDefaultToolkit().getScreenSize();
        dimension1 = this.getSize();
        xpos = (int)(dimension.getWidth() / 2 - dimension1.getWidth() / 2);
        ypos = (int)(dimension.getHeight() / 2 - dimension1.getHeight() / 2);
        this.setLocation(xpos, ypos);
        this.setVisible(true);
    }
    protected void init() {
        CardLayout cardLayout = new CardLayout(5, 5);
        this.setLayout(cardLayout);
        GridLayout gridLayout = new GridLayout(4, 3, 5, 5);
        Panel panel = new Panel(gridLayout);
        Font font = new Font("TimesRoman", Font.BOLD, 20);
        Font font1 = new Font("SansSerif", Font.BOLD, 20);
        String[] strings = {"*", "0", "#"};
        for (int i = 0; i < buttons.length; i++) {
            if(i < 9) {
                buttons[i] = new Button(String.valueOf(i + 1));
                buttons[i].setFont(font);
            } else {
                buttons[i] = new Button(strings[i - 9]);
                buttons[i].setFont(font1);
            }
            panel.add(buttons[i]);
        }
        this.add("view", panel);
    }
    protected void start() { }
}
