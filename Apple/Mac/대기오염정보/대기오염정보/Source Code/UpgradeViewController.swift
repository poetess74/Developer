//
//  UpgradeViewController.swift
//  대기오염정보
//
//  Created by Hyeongmin Kim on 2017. 7. 13..
//  Copyright © 2017년 HM. All rights reserved.
//

import Cocoa

class UpgradeViewController : NSViewController {
    @IBOutlet weak var userprofile1: NSTextField!
    @IBOutlet weak var userprofile2: NSTextField!
    @IBOutlet weak var devdonate: NSButton!
    @IBOutlet weak var upgrade: NSButton!
    @IBOutlet weak var nowupgrade: NSTextField!
    @IBOutlet weak var nowpri: NSTextField!
    @IBOutlet weak var thanks: NSTextField!
    
    
    @IBAction func Donate(_ sender: Any) {
        let alert = NSAlert.init()
        alert.messageText = "개발자에게 후원하기"
        alert.informativeText = "아래의 버튼으로 후원금액을 선택할 수 있습니다.\n기부해 주셔서 감사합니다."
        alert.addButton(withTitle: "$4.39")
        alert.addButton(withTitle: "$2.19")
        alert.addButton(withTitle: "$1.09")
        alert.addButton(withTitle: "취소")
        alert.runModal()
    }
    
    @IBAction func upgradeNow(_ sender: Any) {
        let alert = NSAlert.init()
        alert.messageText = "프리미엄 업그레이드 - 앱 내 구입"
        alert.informativeText = "GreengeckoGames. greengecko 대기오염정보\n가격 : US $2.19"
        alert.addButton(withTitle: "구입")
        alert.addButton(withTitle: "취소")
        alert.addButton(withTitle: "구매 복원")
        alert.runModal()
        self.upgrade.isHidden = true
        self.nowupgrade.isHidden = true
        self.nowpri.isHidden = false
        self.userprofile1.isHidden = true
        self.userprofile2.isHidden = false
        self.thanks.isHidden = false
        self.devdonate.isEnabled = true
    }
    override func viewDidAppear() {
        if let window = view.window {
            window.standardWindowButton(NSWindow.ButtonType.zoomButton)?.isEnabled = false
            window.styleMask.remove(.resizable)
        }
    }
}
