//
//  AppDelegate.swift
//  대기오염정보
//
//  Created by HM on 2017. 6. 16..
//  Copyright © 2017년 HM. All rights reserved.
//

import Cocoa

@NSApplicationMain
class AppDelegate: NSObject, NSApplicationDelegate {
//개발자 시작
    @IBOutlet weak var devMenu: NSMenuItem!
    @IBOutlet weak var showLog: NSMenuItem!
    @IBOutlet weak var deleteCookie: NSMenuItem!
//개발자 끝 | 도움말 시작
    @IBOutlet weak var koforcast: NSMenuItem!
    @IBOutlet weak var jpforcast: NSMenuItem!
    @IBOutlet weak var enforcast: NSMenuItem!
    @IBOutlet weak var airKorea: NSMenuItem!
//도움말 끝 | 개발자 시작
    @IBAction func DevMenu(_ sender: Any) {
        if UserDefaults.standard.bool(forKey: "dev_mode") {
            devMenu.isHidden = false
        } else {
            devMenu.isHidden = true
        }
    }
    @IBAction func ShowLogApp(_ sender: Any) {
        NSWorkspace.shared.open(URL(fileURLWithPath: "/Applications/Utilities/Console.app"))
    }
    @IBAction func DeleteCookie(_ sender: Any) {
        func dialogOKCancel(question: String, text: String) -> Bool {
            let alert = NSAlert()
            alert.messageText = question
            alert.informativeText = text
            alert.alertStyle = .warning
            alert.addButton(withTitle: "승인")
            alert.addButton(withTitle: "취소")
            return alert.runModal() == .alertFirstButtonReturn
        }
        
        let result = dialogOKCancel(question: "캐시 및 쿠키 모두 지우기", text: "이 동작은 모든 캐시 및 쿠키가 지워지며 실행취소할 수 없습니다. ")
        if result {
            DeleteData()
        }
    }
    private func DeleteData() {
        func dialogOKCancel(question: String, text: String) -> Bool {
            let alert = NSAlert()
            alert.messageText = question
            alert.informativeText = text
            alert.alertStyle = .critical
            alert.addButton(withTitle: "승인")
            return alert.runModal() == .alertFirstButtonReturn
        }
        
        _ = dialogOKCancel(question: "변경 사항을 적용하기 위하여 앱을 종료합니다.", text: "")
        sleep(1)
        exit(1)
    }
//개발자 끝 | 도움말 시작
    @IBAction func krForcast(_ sender: Any) {
        NSWorkspace.shared.open(NSURL(string: "http://kaq.or.kr")! as URL)
    }
    @IBAction func jpForcast(_ sender: Any) {
        NSWorkspace.shared.open(NSURL(string: "http://www.tenki.jp/particulate_matter/")! as URL)
    }
    @IBAction func enForcast(_ sender: Any) {
        NSWorkspace.shared.open(NSURL(string: "https://earth.nullschool.net/#current/chem/surface/level/overlay=cosc/orthographic=-231.20,38.86,790/loc=127.278,37.715")! as URL)
    }
    @IBAction func AirKorea(_ sender: Any) {
        NSWorkspace.shared.open(NSURL(string: "http://www.airkorea.or.kr/index")! as URL)
    }
//도움말 끝
}

