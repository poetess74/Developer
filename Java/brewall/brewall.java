import java.io.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class brewall extends JFrame {
    String scriptVersion = "1.1.0"; 
    String scriptBuild = "1A101b01";
    String home = new String(System.getProperty("user.home"));
    String brewallPath = home + "/.shellscript/brewall.sh";
    String logPath = home + "/Library/Logs/Homebrew";
    String daemonPath = home + "/Library/Application Support/com.greengecko.brewall";
    String parameter = new String("");

    JMenuBar menu = new JMenuBar();
    Panel panel = new Panel();
    Button update = new Button("Homebrew 업데이트 시작");
    TextArea status = new TextArea("이 화면은 brewall 스크립트를 실행할 시 결과를 보여줍니다. ", 30, 95);
    Panel setPanel = new Panel();
    Button changePath = new Button("경로 변경");
    Button resetPath = new Button("설정 초기화");
    TextField brewallLoc = new TextField(30);
    TextField logLoc = new TextField(30);
    TextField daemonLoc = new TextField(30);

    protected brewall() {
        String version = new String(scriptVersion + "(" + scriptBuild + ")");
        JMenu help = new JMenu("도움말");
        JMenuItem openLog = new JMenuItem("로그 폴더 열기");
        JMenuItem openDaemon = new JMenuItem("데몬 폴더 열기");
        JMenuItem openScript = new JMenuItem("스크립트 폴더 열기");
        JMenuItem checkUpdate = new JMenuItem("업데이트 확인 [버전: " + version + "]");
        JMenuItem setting = new JMenuItem("설정");
        brewallLoc.setText(brewallPath);
        logLoc.setText(logPath);
        daemonLoc.setText(daemonPath);
        GridBagConstraints grid = new GridBagConstraints();
        grid.gridwidth = 0;
        setPanel.add(new Label("brewall 스크립트: "), grid);
        setPanel.add(brewallLoc);
        setPanel.add(new Label("로그 디렉토리: "), grid);
        setPanel.add(logLoc);
        setPanel.add(new Label("데몬 디렉토리: "), grid);
        setPanel.add(daemonLoc);
        setPanel.add(changePath, grid);
        setPanel.add(resetPath);
        changePath.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent event) {
                brewallPath = brewallLoc.getText();
                logPath = logLoc.getText();
                daemonPath = daemonLoc.getText();
                JOptionPane.showMessageDialog(null, "성공적으로 변경되었습니다. ", "알림", JOptionPane.INFORMATION_MESSAGE);
            }
        });
        resetPath.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent event) {
                brewallPath = home + "/.shellscript/brewall.sh";
                logPath = home + "/Library/Logs/Homebrew";
                daemonPath = home + "/Library/Application\\ Support/com.greengecko.brewall";
                JOptionPane.showMessageDialog(null, "성공적으로 초기화되었습니다. ", "알림", JOptionPane.INFORMATION_MESSAGE);
                brewallLoc.setText(brewallPath);
                logLoc.setText(logPath);
                daemonLoc.setText(daemonPath);
            }
        });
        openDir(openLog, "Logs");
        help.add(openLog);
        openDir(openDaemon, "Daemon");
        help.add(openDaemon).setVisible(false);
        openDir(openScript, "Script");
        help.add(openScript);
        checkUpdate.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent event) {
                JOptionPane.showMessageDialog(null, "업데이트 서버에 연결할 수 없습니다. ", "서버 오류", JOptionPane.ERROR_MESSAGE);
            }
        });
        help.add(checkUpdate);
        setting.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent event) {
                JFrame frame = new JFrame("설정");
                frame.setResizable(false);
                frame.getContentPane().add(setPanel).setPreferredSize(new Dimension(300, 200));
                frame.pack();
                frame.setVisible(true);
            }
        });
        help.add(setting);
        menu.add(help);
        setJMenuBar(menu);
        status.setEditable(false);
        panel.add(status);
        update.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent event) {
                update.setEnabled(false);
                update.setLabel("Homebrew 업데이트 진행중...");
                status.setText("");
                parameter = JOptionPane.showInputDialog(null, "brewall 후 실행할 쉘 명령을 입력하세요. 실행할 명령이 없을 경우 공란으로 나두시면 됩니다. ", "다음에 실행할 명령 예약", JOptionPane.INFORMATION_MESSAGE);
                if (parameter != null) {
                    status.setText("Homebrew 업데이트가 진행 중 입니다...\n잠시만 기다려 주십시오. ");
                    JOptionPane.showMessageDialog(null, "아직 실시간 화면 갱신은 지원하지 않으므로 작업이 완료될 때까지 기다려 주시기 바랍니다. ", "경고", JOptionPane.WARNING_MESSAGE);
                    status.setText("");
                    try {
                        shellCmd(brewallPath, status);
                        status.append("\n\n[Homebrew 업데이트가 성공적으로 완료되었습니다. ]");
                    } catch (Exception e) {
                        status.append("\n\n[Homebrew 업데이트 도중 오류가 발생하였습니다. ]");
                    }
                } else {
                    status.setText("이 화면은 brewall 스크립트를 실행할 시 결과를 보여줍니다. ");
                    JOptionPane.showMessageDialog(null, "Homebrew 업데이트를 취소하였습니다. ", "경고", JOptionPane.WARNING_MESSAGE);
                }
                update.setLabel("Homebrew 업데이트 시작");
                update.setEnabled(true);
            }
        });
        panel.add(update);
        add(panel);
        setSize(800, 600);
        setResizable(false);
        setTitle("Homebrew 관리자");
        setVisible(true);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
    }

    public static void main(String[] args) { brewall b = new brewall(); }

    protected void openDir(JMenuItem target, String option) {
        target.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent event) {
                Runtime run = Runtime.getRuntime();
                try {
                    if(option.equals("Logs")) {
                        run.exec("/usr/bin/open " + logPath);
                    } else if (option.equals("Daemon")) {
                        run.exec("/usr/bin/open " + daemonPath);
                    } else if (option.equals("Script")) {
                        String result = brewallPath.substring(0, brewallPath.length() - 11);
                        JOptionPane.showMessageDialog(null, "아직 기능을 구현중이므로 스크립트 이름이 brewall이 아닌 다른 이름일 경우 지정된 디렉토리를 열 수 없습니다. ", "알림", JOptionPane.INFORMATION_MESSAGE);
                        run.exec("/usr/bin/open " + result);
                    }
                } catch (IOException io) {
                    JOptionPane.showMessageDialog(null, "지정된 디렉토리에 접근할 수 있는 권한이 없습니다. ", "오류", JOptionPane.ERROR_MESSAGE);
                }
            }
        });
    }

    protected void shellCmd(String command, TextArea output) throws Exception {
        Runtime runtime = Runtime.getRuntime();
        Process process = runtime.exec(command);
        InputStream in = process.getInputStream();
        InputStreamReader inr = new InputStreamReader(in);
        BufferedReader br = new BufferedReader(inr);
        String line;
        while ((line = br.readLine()) != null) {
            output.append(line);
            output.append("\n");
        }
        if (!parameter.isEmpty()) {
            runtime = Runtime.getRuntime();
            process = runtime.exec(parameter);
            in = process.getInputStream();
            inr = new InputStreamReader(in);
            br = new BufferedReader(inr);
            while ((line = br.readLine()) != null) {
                output.append(line);
                output.append("\n");
            }
        }
        br.close();
    }
}
