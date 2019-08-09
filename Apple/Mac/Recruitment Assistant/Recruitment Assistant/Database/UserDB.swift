//
//  UserDB.swift
//  Recruitment Assistant
//
//  Created by HM on 2/17/19.
//  Copyright © 2019 HM. All rights reserved.
//

import Foundation

class UserDB {
    let adminID = "admin"
    let adminPW = "qwerty1234"
    
    let adminTrustlogin = 3
    var adminLogintry = 1
    
    var userName: [String] = []
    var userBirth: [String] = []
    var userPhone: [String] = []
    var userTag: [String] = []
    
    public func userLogin(Name: String, Tag: String) -> Bool {
        NSLog("userDB18.userLogin: userTag.count: \(userTag.count)")
        if !(userTag.isEmpty) {
            for _ in 0..<(userTag.count) {
                if (userTag == [Tag]) {
                    return true
                }
            }
        }
        return false
    }
    
    public func userFind(Name: String, Birth: String, Phone: String) -> String {
        NSLog("userDB30.userFind: userTag.count: \(userTag.count)")
        for _ in 0..<(userTag.count) {
            //FIXIT: userTag.count has 0
            if !(userName.isEmpty && userBirth.isEmpty && userPhone.isEmpty) {
                var a = 0
                var b = 0
                var c = 0
                
                for i in 0..<(userName.count) {
                    if (userName == [Name]) {
                        a = i
                    }
                }
                
                for j in 0..<(userBirth.count) {
                    if (userBirth == [Birth]) {
                        b = j
                    }
                }
                
                for k in 0..<(userPhone.count) {
                    if (userPhone == [Phone]) {
                        c = k
                    }
                }
                if (a != b || b != c || c != a) {
                    NSLog("userDB56.userFind: userName: \(a), userBirth: \(b), userPhone: \(c)")
                    continue
                } else {
                    NSLog("userDB59.userFind: userName: \(a), userBirth: \(b), userPhone: \(c)")
                    return userTag[a]
                }
            }
        }
        return ""
    }
    
    public func userSearch(Tag: String) -> String {
        NSLog("userDB68.userSearch: userTag.count: \(userTag.count)")
        if !(userTag.isEmpty) {
            for i in 0..<(userTag.count) {
                if (userTag == [Tag]) {
                    return userTag[i]
                }
            }
        }
        return ""
    }
    
    public func userAppend(Name: String, Birth: String, Phone: String, Tag: String) {
        userName.append(Name)
        userBirth.append(Birth)
        userPhone.append(Phone)
        userTag.append(Tag)
        NSLog("userDB84.userAppend: Name: \(userName), Birth: \(userBirth), Phone: \(userPhone), Tag: \(userTag)")
        NSLog("userDB85.userAppend: userTag.count: \(userTag.count)")
    }
    
    public func userDelete() {
        userName.removeAll()
        userBirth.removeAll()
        userPhone.removeAll()
        userTag.removeAll()
    }
}
