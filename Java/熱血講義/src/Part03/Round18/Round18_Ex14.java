package Part03.Round18;

import java.awt.*;

public class Round18_Ex14 {
    public static void main(String[] args) {
        Round18_Ex14_Sub round18_ex14_sub = new Round18_Ex14_Sub();
    }
}

class Round18_Ex14_Sub extends Frame {
    private Dimension dimension, dimension1;
    private int xpos, ypos;
    private Label label = new Label("directory = ");
    private Label label1 = new Label("file = ");
    private FileDialog fileDialog = new FileDialog(this, "내파일열기");
    protected Round18_Ex14_Sub() {
        super("파일 다이얼로그");
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
        fileDialog.setVisible(true);
        String dir = fileDialog.getDirectory();
        String file = fileDialog.getFile();
        label.setText(label.getText().trim() + dir);
        label1.setText(label1.getText().trim() + file);
    }
    protected void init() {
        GridBagLayout gridBagLayout = new GridBagLayout();
        GridBagConstraints gridBagConstraints = new GridBagConstraints();
        this.setLayout(gridBagLayout);
        label.setBackground(Color.YELLOW);
        label1.setBackground(Color.YELLOW);
        gridBagConstraints.weightx = 1;
        gridBagConstraints.fill = GridBagConstraints.HORIZONTAL;
        gridBagConstraints.gridwidth = GridBagConstraints.REMAINDER;
        gridBagConstraints.insets = new Insets(0, 0, 10, 0);
        gridBagLayout.setConstraints(label, gridBagConstraints);
        this.add(label);
        gridBagLayout.setConstraints(label1, gridBagConstraints);
        this.add(label1);
    }
    protected void start() { }
}
