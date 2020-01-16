//
//  AdminController.swift
//  Recruitment Assistant
//
//  Created by HM on 2/17/19.
//  Copyright © 2019 HM. All rights reserved.
//

import Cocoa

class AdminController: NSViewController {
    @IBOutlet weak var adminID: NSTextField!
    @IBOutlet weak var adminPW: NSSecureTextField!
    @IBOutlet weak var adminLogin: NSButton!
    @IBOutlet weak var adminStatus: NSTextField!
    @IBOutlet weak var userSearch: NSSearchField!
    @IBOutlet weak var userSearchBtn: NSButton!
    @IBOutlet weak var userSearchResult: NSTextField!
    @IBOutlet weak var userAddName: NSTextField!
    @IBOutlet weak var userAddBirth: NSTextField!
    @IBOutlet weak var userAddPhone: NSTextField!
    @IBOutlet weak var userAddTag: NSTextField!
    @IBOutlet weak var userAddBtn: NSButton!
    @IBOutlet weak var userAddResult: NSTextField!
    @IBOutlet weak var eraseUserInfo: NSButton!
    @IBOutlet weak var eraseUserLabel: NSTextField!
    
    let userDB = UserDB()
    
    private var token = false
    
    @IBAction func Authentication(_ sender: Any) {
        if (token) {
            logout()
        } else {
            login()
        }
    }
    @IBAction func Search(_ sender: Any) {
        userSearchResult.isHidden = false
        if (userSearch.stringValue.count == 12) {
            adminStatus.isHidden = true
            
            if (userDB.userSearch(Tag: userSearch.stringValue) == "") {
                userSearchResult.stringValue = "없음"
                userSearchResult.textColor = NSColor.red
            } else {
                userSearchResult.stringValue = "존재"
                userSearchResult.textColor = NSColor.blue
            }
        } else {
            adminStatus.isHidden = false
            adminStatus.stringValue = "12자리 코드를 올바르게 입력하십시오. "
            userSearchResult.stringValue = "X"
            userSearchResult.textColor = NSColor.red
            userSearch.stringValue = ""
        }
    }
    @IBAction func Save(_ sender: Any) {
        userAddResult.isHidden = false
        if (userAddName.stringValue.isEmpty || userAddBirth.stringValue.count != 6 || userAddPhone.stringValue.count != 4 || userAddTag.stringValue.count != 12) {
            adminStatus.isHidden = false
            adminStatus.stringValue = "사원 정보를 저장하려면 정보를 입력하십시오. "
            userAddName.stringValue = ""
            userAddBirth.stringValue = ""
            userAddPhone.stringValue = ""
            userAddTag.stringValue = ""
            userAddResult.stringValue = "X"
            userAddResult.textColor = NSColor.red
        } else {
            adminStatus.isHidden = true
            userDB.userAppend(Name: userAddName.stringValue, Birth: userAddBirth.stringValue, Phone: userAddPhone.stringValue, Tag: userAddTag.stringValue)
            userAddName.stringValue = ""
            userAddBirth.stringValue = ""
            userAddPhone.stringValue = ""
            userAddTag.stringValue = ""
            userAddResult.stringValue = "√"
            userAddResult.textColor = NSColor.blue
        }
    }
    
    @IBAction func EraseAll(_ sender: Any) {
        userDB.userDelete()
    }
    
    private func login() {
        if (userDB.adminLogintry >= userDB.adminTrustlogin) {
            NSLog("EXC_BAD_ACCESS. Recruitment Assistant.app had terminated for security.")
            exit(EXIT_FAILURE)
        } else if (adminID.stringValue.isEmpty || adminPW.stringValue.isEmpty) {
            adminStatus.isHidden = false
            adminStatus.stringValue = "아이디 또는 비밀번호를 입력하십시오. "
        } else if (adminID.stringValue != userDB.adminID || adminPW.stringValue != userDB.adminPW) {
            adminStatus.isHidden = false
            adminStatus.stringValue = "아이디 또는 비밀번호가 다릅니다. \(userDB.adminTrustlogin - userDB.adminLogintry)회 남음"
            adminPW.stringValue = ""
            userDB.adminLogintry += 1
        } else {
            userDB.adminLogintry = 1
            adminStatus.isHidden = true
            token = true
            
            userSearch.stringValue = ""
            userAddName.stringValue = ""
            userAddBirth.stringValue = ""
            userAddPhone.stringValue = ""
            userAddTag.stringValue = ""
            
            adminID.isEnabled = false
            adminPW.isEnabled = false
            adminLogin.title = "변 경"
            
            userSearch.isHidden = false
            userSearchBtn.isHidden = false
            userAddName.isHidden = false
            userAddBirth.isHidden = false
            userAddPhone.isHidden = false
            userAddTag.isHidden = false
            userAddBtn.isHidden = false
            eraseUserInfo.isHidden = false
            eraseUserLabel.isHidden = false
        }
    }
    
    private func logout() {
        token = false
        
        adminID.isEnabled = true
        adminPW.isEnabled = true
        adminID.stringValue = ""
        adminPW.stringValue = ""
        
        adminLogin.title = "인 증"
        
        userSearch.isHidden = true
        userSearchBtn.isHidden = true
        userAddName.isHidden = true
        userAddBirth.isHidden = true
        userAddPhone.isHidden = true
        userAddTag.isHidden = true
        userAddBtn.isHidden = true
        eraseUserInfo.isHidden = true
        eraseUserLabel.isHidden = true
        userAddResult.isHidden = true
        userSearchResult.isHidden = true
    }
}
