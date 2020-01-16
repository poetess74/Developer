//
//  UserInfoDB.swift
//  AntiDriEye
//
//  Created by HM on 2017. 12. 19..
//  Copyright © 2017년 HM. All rights reserved.
//

import Foundation

class UserInfoDB {
    var currentURL: String = "https://www.google.com/"

    var blinkalert: Bool = true
    var forceBreak: Bool = false
    var sleepBool: Bool = false
    var bannerAds: Bool = true
    
    var nomalTime: UInt = 3000
    var cooldownTime: UInt = 600
    var blinkeyeTime: UInt = 180
    
    var currentTime: UInt = 3000
    var cooldownCurrenttime: UInt = 600
    
    var credit: UInt = 10
    
    static let sharedInstance = UserInfoDB()
    
    init() {}
}
