package Part03.Round17;

import java.awt.*;

public class Round17_Ex01 {
    public static void main(String[] args) {
        Frame frame = new Frame();
        frame.setSize(300, 200); //or f.pack();
        Dimension dimension = Toolkit.getDefaultToolkit().getScreenSize();
        Dimension dimension1 = frame.getSize();
        int xpos = (int)(dimension.getWidth() / 2 - dimension1.getWidth() / 2);
        int ypos = (int)(dimension.getHeight() / 2 - dimension1.getHeight() / 2);
        frame.setLocation(xpos, ypos);
        frame.setTitle("제목부분");
        frame.setVisible(true);
    }
}
