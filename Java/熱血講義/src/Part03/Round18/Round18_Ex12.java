package Part03.Round18;

import java.awt.*;

public class Round18_Ex12 {
    public static void main(String[] args) {
        Round18_Ex12_Sub round18_ex12_sub = new Round18_Ex12_Sub();
    }
}

class Round18_Ex12_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Label label = new Label("5초 이내에 특정 내용의 범위를 지정하시오!");
    private Label label1 = new Label("선택된 내용 : ", Label.RIGHT);
    private TextArea textArea = new TextArea("abcdefghijk\nlmnopqrs\ntuvwxyz\n");
    private TextField textField = new TextField();
    protected Round18_Ex12_Sub() {
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
        try {
            Thread.sleep(5000);
        } catch (InterruptedException ee) { }
        String string = textArea.getSelectedText().trim();
        int start = textArea.getSelectionStart();
        int end = textArea.getSelectionEnd();
        textField.setText(string);
        try {
            Thread.sleep(5000);
        } catch (InterruptedException ee) { }
        textArea.replaceRange("", start, end);
        try {
            Thread.sleep(5000);
        } catch (InterruptedException ee) { }
        string = textField.getText().trim();
        int length = textArea.getText().trim().length();
        textArea.setCaretPosition(length);
        textArea.append(string);
    }
    protected void init() {
        BorderLayout borderLayout = new BorderLayout(5, 5);
        this.setLayout(borderLayout);
        this.add("North", label);
        this.add("Center", textArea);
        BorderLayout borderLayout1 = new BorderLayout(3, 3);
        Panel panel = new Panel(borderLayout1);
        panel.add("West", label1);
        panel.add("Center", textField);
        this.add("South", panel);
    }
    protected void start() { }
}
