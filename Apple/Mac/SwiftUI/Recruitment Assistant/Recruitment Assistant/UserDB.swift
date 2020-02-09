//
//  UserDB.swift
//  Recruitment Assistant
//
//  Created by HM on 2020/02/08.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation

class UserDB: ObservableObject {
    let adminID = "admin"
    let adminPW = "passwd"
    
    @Published var status = "Intro"
    
    @Published var TestFile: String?
    @Published var UserFile: String?
    @Published var AnswerFile: String?
    @Published var ResultDirPath: String?
    @Published var ResultDirUrl: URL?
    @Published var testItem: [String]?
    @Published var userIDItem: [String]?
    @Published var answerItem: [String]?
    
    @Published var userID = ""
    @Published var userPW = ""
    @Published var userAnswer: [String] = []
    @Published var userPoint = 0
}
