//
//  FindAccount.swift
//  Recruitment Assistant
//
//  Created by HM on 1/27/19.
//  Copyright © 2019 HM. All rights reserved.
//

import Cocoa

class FindAccount: NSViewController {
    @IBOutlet weak var userName: NSTextField!
    @IBOutlet weak var userBirth: NSTextField!
    @IBOutlet weak var userPhone: NSSecureTextField!
    @IBOutlet weak var userAgree: NSButton!
    @IBOutlet weak var userSearch: NSButton!
    @IBOutlet weak var userSearchError: NSTextField!
    @IBOutlet weak var userResult: NSTextField!
    @IBOutlet weak var userResultLabel: NSTextField!
    
    let userDB = UserDB()
    
    private var noSuchID = 1
    private let trustSuch = 3
    
    
    private var Searched = false
    private var Limited = false
    
//    private let testUser: [String] = []
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        // Do any additional setup after loading the view.
    }
    
    override var representedObject: Any? {
        didSet {
            // Update the view, if already loaded.
        }
    }
    
    @IBAction func AgreePrivacy(_ sender: NSButton) {
        let alert = NSAlert()
        alert.messageText = "개인 정보 식별에 동의하셨습니다. "
        alert.informativeText = "이제 '조회' 버튼을 눌러 지원 번호를 조회하십시오. "
        alert.addButton(withTitle: "승인")
        alert.alertStyle = .informational
        alert.runModal()
        userAgree.isEnabled = false
        userSearch.isEnabled = true
    }
    
    @IBAction func Search(_ sender: NSButton) {
        if !(Limited) {
            if (Searched) {
                logout()
            } else {
                login()
            }
        } else {
            Authorization()
        }
    }
    
    private func login() {
        if (userName.stringValue.isEmpty && userBirth.stringValue.isEmpty && userPhone.stringValue.isEmpty) {
            userSearchError.isHidden = false
            userSearchError.stringValue = "인적 사항을 기재하셔야 조회하실 수 있습니다. "
        } else if (userName.stringValue.isEmpty) {
            userSearchError.isHidden = false
            userSearchError.stringValue = "이름을 기재하여 주십시오. "
        } else if (userBirth.stringValue.isEmpty) {
            userSearchError.isHidden = false
            userSearchError.stringValue = "생년월일을 기재하여 주십시오. "
        } else if (userPhone.stringValue.isEmpty) {
            userSearchError.isHidden = false
            userSearchError.stringValue = "휴대폰 번호 뒤 4자리를 기재하여 주십시오. "
        } else if (userName.stringValue.count < 2) {
            userSearchError.isHidden = false
            userSearchError.stringValue = "이름을 정확히 기재하여 주십시오. "
            userName.stringValue = ""
        } else if (userBirth.stringValue.count != 6) {
            userSearchError.isHidden = false
            userSearchError.stringValue = "생년월일을 정확히 기재하여 주십시오. "
            userBirth.stringValue = ""
        } else if (userPhone.stringValue.count != 4) {
            userSearchError.isHidden = false
            userSearchError.stringValue = "휴대폰 번호 뒤 4자리를 정확히 기재하여 주십시오. "
            userPhone.stringValue = ""
        } else {
            userName.isEnabled = false
            userBirth.isEnabled = false
            userPhone.isEnabled = false
            userSearchError.isHidden = true
            Searched = true
            userAgree.isHidden = true
            userAgree.isEnabled = true
            userSearch.title = "변 경"
            let userIdentyfi = userDB.userFind(Name: userName.stringValue, Birth: userBirth.stringValue, Phone: userPhone.stringValue)
            if (noSuchID >= trustSuch) {
                Searched = false
                userBirth.isEnabled = true
                userPhone.isEnabled = true
                userSearchError.isHidden = false
                userResultLabel.isHidden = true
                userResult.isHidden = true
                userSearchError.stringValue = "개인정보 보호를 위하여 조회할 수 없습니다. "
                userBirth.placeholderString = "관리자 이름"
                userPhone.placeholderString = "비밀 번호"
                userName.stringValue = ""
                userBirth.stringValue = ""
                userPhone.stringValue = ""
                userSearch.title = "인 증"
                Limited = true
                self.view.window?.standardWindowButton(NSWindow.ButtonType.closeButton)!.isEnabled = false
            } else if (userIdentyfi == "") {
                Searched = false
                userSearchError.isHidden = false
                userSearchError.stringValue = "인적 사항을 찾을 수 없습니다. (\(trustSuch - noSuchID)회 남음)"
                noSuchID += 1
                userSearch.isEnabled = true
                userName.stringValue = ""
                userBirth.stringValue = ""
                userPhone.stringValue = ""
                userResult.isHidden = false
                userResultLabel.isHidden = false
                userResult.stringValue = ""
                userName.isEnabled = true
                userBirth.isEnabled = true
                userPhone.isEnabled = true
                userSearch.title = "조 회"
            } else {
                noSuchID = 1
                userResult.stringValue = userIdentyfi
                userResult.isHidden = false
                userResultLabel.isHidden = false
            }
            
            
// ************** DEBUG *****************
//            let randomNum = Int(arc4random_uniform(5))
//            userResult.stringValue = testUser[]
// **************************************
        }
    }
    
    private func Authorization() {
        if (userDB.adminLogintry >= userDB.adminTrustlogin) {
            NSLog("EXC_BAD_ACCESS. Recruitment Assistant.app/FindAccount/NSViewController had terminated for security.")
            self.view.window?.close()
        } else if (userBirth.stringValue.isEmpty || userPhone.stringValue.isEmpty) {
            userSearchError.isHidden = false
            userSearchError.stringValue = "아이디 또는 비밀번호를 입력하십시오. "
        } else if (userBirth.stringValue != userDB.adminID || userPhone.stringValue != userDB.adminPW) {
            userSearchError.isHidden = false
            userSearchError.stringValue = "아이디 또는 비밀번호가 다릅니다. (\(userDB.adminTrustlogin - userDB.adminLogintry)회 남음)"
            userDB.adminLogintry += 1
            userPhone.stringValue = ""
        } else {
            userDB.adminLogintry = 1
            Limited = false
            userName.isEnabled = true
            userPhone.stringValue = ""
            userBirth.stringValue = ""
            userSearchError.isHidden = true
            userBirth.placeholderString = "YYMMDD"
            userPhone.placeholderString = "뒤 4자리"
            userSearch.title = "조 회"
            userAgree.isHidden = false
            userAgree.isEnabled = false
            noSuchID = 1
            self.view.window?.standardWindowButton(NSWindow.ButtonType.closeButton)!.isEnabled = true
        }
    }
    
    private func logout() {
        userName.isEnabled = true
        userBirth.isEnabled = true
        userPhone.isEnabled = true
        userName.stringValue = ""
        userBirth.stringValue = ""
        userPhone.stringValue = ""
        Searched = false
        userResult.isHidden = true
        userAgree.isHidden = false
        //TODO: userAgree.isChecked = false
        userSearch.isEnabled = false
        userResultLabel.isHidden = true
        userSearch.title = "조 회"
    }
}
