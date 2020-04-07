package Part03.Round18;

import java.awt.*;

public class Round18_Ex16 {
    public static void main(String[] args) {
        Round18_Ex16_Sub round18_ex16_sub = new Round18_Ex16_Sub();
    }
}

class Round18_Ex16_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Label label = new Label("많은 버튼들 추가...");
    private Button[] buttons = new Button[50];
    private Button button1 = new Button("확인");
    private Button button2 = new Button("취소");
    protected Round18_Ex16_Sub() {
        super("Scroll Pane!");
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
        BorderLayout borderLayout = new BorderLayout(5, 5);
        this.setLayout(borderLayout);
        this.add("North", label);

        GridLayout gridLayout = new GridLayout(10, 5, 2, 2);
        Panel panel = new Panel(gridLayout);
        for (int i = 0; i < buttons.length; i++) {
            buttons[i] = new Button("TEST" + i);
            panel.add(buttons[i]);
        }
        ScrollPane scrollPane = new ScrollPane();
        scrollPane.add(panel);
        this.add("Center", scrollPane);

        FlowLayout flowLayout = new FlowLayout(FlowLayout.RIGHT);
        Panel panel1 = new Panel(flowLayout);
        panel1.add(button1);
        panel1.add(button2);
        this.add("South", panel1);
    }
    protected void start() { }
}
