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
    private MenuItem fnew = new MenuItem("새 파일");
    private MenuItem fopen = new Menu("열기");
    private MenuItem fsave = new Menu("저장");
    private MenuItem fsaveas = new MenuItem("다른 이름으로 저장");
    private MenuItem fexit = new MenuItem("종료");
    private MenuItem esearch = new MenuItem("찾기");
    private MenuItem echange = new MenuItem("바꾸기");
    private MenuItem emove = new MenuItem("이동");
    private Menu vmo = new Menu("모양");
    private MenuItem vmbasic = new MenuItem("기본 모양");
    private MenuItem vmweb = new MenuItem("웹 모양");
    private MenuItem vmprint = new MenuItem("인쇄 모양");
    private Menu vtool = new Menu("도구 모음");
    private MenuItem hver = new Menu("버전 정보");
    private CheckboxMenuItem vtcustom = new CheckboxMenuItem("표준", true);
    private CheckboxMenuItem vtform = new CheckboxMenuItem("서식", true);
    private CheckboxMenuItem vtexam = new CheckboxMenuItem("검토", false);
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
        file.add(fnew);
        file.addSeparator();
        file.add(fopen);
        file.add(fsave);
        fsaveas.setEnabled(false);
        file.add(fsaveas);
        file.add(fexit);
        edit.add(esearch);
        edit.add(echange);
        edit.add(emove);
        view.add(vmo);
        vmo.add(vmbasic);
        vmo.add(vmweb);
        vmo.add(vmprint);
        view.add(vtool);
        help.add(hver);
        vtool.add(vtcustom);
        vtool.add(vtform);
        vtool.add(vtexam);
        menuBar.add(file);
        menuBar.add(edit);
        menuBar.add(view);
        menuBar.add(help);
    }
    protected void start() { }
}
