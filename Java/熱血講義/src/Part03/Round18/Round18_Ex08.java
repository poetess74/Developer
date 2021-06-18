package Part03.Round18;

import java.awt.*;

public class Round18_Ex08 {
    public static void main(String[] args) {
        Round18_Ex08_Sub round18_ex08_sub = new Round18_Ex08_Sub();
    }
}

class Round18_Ex08_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Label label = new Label("좋아하는 과일을 모두 체크하세요!");
    private Checkbox checkbox = new Checkbox("사과");
    private Checkbox checkbox1 = new Checkbox("딸기", false);
    private Checkbox checkbox2 = new Checkbox("키위", true);
    private Checkbox checkbox3 = new Checkbox("포도");
    private Button button = new Button("승인");
    private Button button1 = new Button("취소");
    protected Round18_Ex08_Sub() {
        super("선택");
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
        BorderLayout borderLayout = new BorderLayout();
        this.setLayout(borderLayout);
        this.add("North", label);
        GridLayout gridLayout = new GridLayout(2, 2);
        Panel panel = new Panel(gridLayout);
        panel.add(checkbox);
        panel.add(checkbox1);
        panel.add(checkbox2);
        panel.add(checkbox3);
        this.add("Center", panel);
        FlowLayout flowLayout = new FlowLayout(FlowLayout.RIGHT);
        Panel panel1 = new Panel(flowLayout);
        panel1.add(button);
        panel1.add(button1);
        this.add("South", panel1);
    }
    protected void start() { }
}
