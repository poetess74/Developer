//
//  UserDB.swift
//  Recruitment Assistant
//
//  Created by HM on 2020/02/08.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation

class UserDB: ObservableObject {
    let UserID = "admin"
    let UserPW = "passwd"
    
    @Published var status = "Intro"
    @Published var TestFile:String?
}
