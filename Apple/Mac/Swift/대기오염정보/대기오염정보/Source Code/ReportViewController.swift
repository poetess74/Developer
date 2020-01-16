//
//  ReportViewController.swift
//  대기오염정보
//
//  Created by HM on 2017. 6. 17..
//  Copyright © 2017년 HM. All rights reserved.
//

import Cocoa

class ReportViewController : NSViewController,  NSTextFieldDelegate{
    
//개선점 시작
    @IBOutlet weak var fromEmail: NSTextField!
    @IBOutlet weak var improveTextBox: NSTextField!
    @IBOutlet weak var improveBytesLable: NSTextField!
    @IBOutlet weak var agreeButton: NSButton!
    @IBOutlet weak var agreeCheckBox: NSButton!
    @IBOutlet weak var agreeLable: NSTextField!
    @IBOutlet weak var newsCheckBox: NSButton!
    @IBOutlet weak var sendEmail: NSButton!
//개선점 종료
//버그리포트 시작
    @IBOutlet weak var bugfromEmail: NSTextField!
    @IBOutlet weak var bugreportTitlebox: NSTextField!
    @IBOutlet weak var bugreportBytesLable: NSTextField!
    @IBOutlet weak var issuePopupbtn: NSPopUpButton!
    @IBOutlet weak var bugtypePopupbtn: NSPopUpButton!
    @IBOutlet weak var frequencyPopupbtn: NSPopUpButton!
    @IBOutlet weak var explainBytes: NSTextField!
    @IBOutlet weak var explainTextbox: NSTextField!
    @IBOutlet weak var deja_vuPopupbtn: NSPopUpButton!
    @IBOutlet weak var uncomPopupbtn: NSPopUpButton!
    @IBOutlet weak var osxverPopupbtn: NSPopUpButton!
    @IBOutlet weak var sendbtnOn: NSButton!
    @IBOutlet weak var sendBtn: NSButton!
    @IBOutlet weak var agreeOn: NSButton!
//버그리포트 종료
//개선점 시작
    @IBAction func agreeButton(_ sender: Any) {
        self.agreeButton.isHidden = true
        self.agreeCheckBox.isHidden = false
        self.agreeLable.isHidden = true
        self.sendEmail.isHidden = false
        
        let storyboard = NSStoryboard(name: NSStoryboard.Name(rawValue: "Main"), bundle: nil)
        let contractAgreeWindowController = storyboard.instantiateController(withIdentifier: NSStoryboard.SceneIdentifier(rawValue: "contractAgree")) as! NSViewController

        self.presentViewControllerAsModalWindow(contractAgreeWindowController)
    }
    
    @IBAction func agreeCheckBox(_ sender: NSButton) {
        self.newsCheckBox.isHidden = (sender.state.rawValue == 0)
        self.sendEmail.isEnabled = (sender.state.rawValue == 1)
    }
    @IBAction func sendEmailCheckBox(_ sender: Any) {
        // 준비중
    }
    @IBAction func improvesendButton(_ sender: Any) {
        func dialogOKCancel(question: String, text: String) -> Bool {
            let alert = NSAlert()
            alert.messageText = question
            alert.informativeText = text
            alert.alertStyle = .warning
            alert.addButton(withTitle: "보내기")
            alert.addButton(withTitle: "검토")
            return alert.runModal() == .alertFirstButtonReturn
        }
        
        let result = dialogOKCancel(question: "개선점을 지금 보내려고 합니다.", text: "마지막으로 맞춤법에 문제가 없는지 \n그리고 프리미엄 사용자인지 확인하신 후 보내시기 바랍니다.")
        if result {
            self.view.window?.close()
            let alert = NSAlert.init()
            alert.messageText = "전송을 완료하였습니다. "
            alert.informativeText = "대기오염정보를 이용해주셔서 감사합니다. 새로운 기능이 적용되면 해당 메일 주소로 안내해 드리겠습니다."
            alert.addButton(withTitle: "승인")
            alert.runModal()
        }
    }
//개선점 종료
//버그 리포트 시작
    @IBAction func showsendBtn(_ sender: NSButton) {
        self.sendbtnOn.isHidden = true
        self.agreeOn.isHidden = false
        let storyboard = NSStoryboard(name: NSStoryboard.Name(rawValue: "Main"), bundle: nil)
        let contractAgreeWindowController = storyboard.instantiateController(withIdentifier: NSStoryboard.SceneIdentifier(rawValue: "contractAgree")) as! NSViewController
        
        self.presentViewControllerAsModalWindow(contractAgreeWindowController)
    }
    @IBAction func agreeBool(_ sender: NSButton) {
        self.agreeOn.isHidden = true
        self.sendBtn.isHidden = false
    }
    @IBAction func sendBtn(_ sender: NSButton) {
        func dialogOKCancel(question: String, text: String) -> Bool {
            let alert = NSAlert()
            alert.messageText = question
            alert.informativeText = text
            alert.alertStyle = .warning
            alert.addButton(withTitle: "보내기")
            alert.addButton(withTitle: "검토")
            return alert.runModal() == .alertFirstButtonReturn
        }
        
        let result = dialogOKCancel(question: "버그 리포트를 지금 보내려고 합니다. ", text: "마지막으로 맞춤법에 문제가 없고 양식을 모두 채웠는지, \n그리고 프리미엄 사용자인지 확인하신 후 보내시기 바랍니다.")
        if result {
            self.view.window?.close()
            let alert = NSAlert.init()
            alert.messageText = "전송을 완료하였습니다. "
            alert.informativeText = "대기오염정보를 이용해주셔서 감사합니다. 더 좋은 앱을 만들기 위하여 앞으로도 노력하겠습니다."
            alert.addButton(withTitle: "승인")
            alert.runModal()
        }
    }
    
//버그 리포트 종료
    
    override func viewDidAppear() {
        if let window = view.window {
            window.standardWindowButton(NSWindow.ButtonType.zoomButton)?.isEnabled = false
            window.styleMask.remove(.resizable)
        }
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        self.view.window?.delegate = self as? NSWindowDelegate
        self.improveBytesLable.stringValue = "280"
        self.improveTextBox.delegate = self
        self.bugreportBytesLable.stringValue = "30"
        self.bugreportTitlebox.delegate = self
        self.explainBytes.stringValue = "70"
        self.explainTextbox.delegate = self
    }
    override func viewWillAppear() {
        super.viewWillAppear()
        updater()
        checkingString()
    }
    
    var timer = Timer()
    func checkingString() {
        timer = Timer.scheduledTimer(
            timeInterval: 0.1,
            target: self,
            selector: #selector(updater),
            userInfo: nil,
            repeats: true)
    }
    
    @objc func updater() {
        if improveTextBox.stringValue.count > 280 {
            self.improveTextBox.stringValue = String(self.improveTextBox.stringValue.last!)
            let alert = NSAlert.init()
            alert.messageText = "글자 수 제한을 넘어섰습니다."
            alert.informativeText = "글자 수 제한은 280자입니다.\n핵심만 간단하게 작성하여 주십시오."
            alert.addButton(withTitle: "승인")
            alert.runModal()
        } else {
            improveBytesLable.stringValue = String (280-(self.improveTextBox.stringValue.count))
        }
        if bugreportTitlebox.stringValue.count > 30 {
            self.bugreportTitlebox.stringValue = String(self.bugreportTitlebox.stringValue.last!)
            let alert = NSAlert.init()
            alert.messageText = "글자 수 제한을 넘어섰습니다."
            alert.informativeText = "글자 수 제한은 30자입니다.\n핵심만 간단하게 작성하여 주십시오."
            alert.addButton(withTitle: "승인")
            alert.runModal()
        } else {
            bugreportBytesLable.stringValue = String (30-(self.bugreportTitlebox.stringValue.count))
        }
        if explainTextbox.stringValue.count > 70 {
            self.explainTextbox.stringValue = String(self.explainTextbox.stringValue.last!)
            let alert = NSAlert.init()
            alert.messageText = "글자 수 제한을 넘어섰습니다."
            alert.informativeText = "글자 수 제한은 70자입니다.\n핵심만 간단하게 작성하여 주십시오."
            alert.addButton(withTitle: "승인")
            alert.runModal()
        } else {
            explainBytes.stringValue = String (70-(self.explainTextbox.stringValue.count))
        }
    }
}
