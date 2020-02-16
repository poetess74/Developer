//
//  UserDB.swift
//  Recruitment Assistant
//
//  Created by HM on 2020/02/08.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation

class UserDB: ObservableObject {
    @Published var adminID: String = UserDefaults.standard.string(forKey: "adminID") ?? "admin" // 관계자 아이디
    @Published var adminPW: String = UserDefaults.standard.string(forKey: "adminPW") ?? "passwd" // 관계자 패스워드
    
    @Published var status = "Intro" // 뷰 상태
    @Published var auth = false // 관계자 인증 상태
    
    @Published var TestFile: String? = UserDefaults.standard.string(forKey: "TestFile") ?? nil // 테스트 파일 경로
    @Published var UserFile: String? = UserDefaults.standard.string(forKey: "UserFile") ?? nil // 신상 정보 파일 경로
    @Published var AnswerFile: String? = UserDefaults.standard.string(forKey: "AnswerFile") ?? nil // 정답 파일 경로
    @Published var ResultDirPath: String? = nil // 결과 출력 폴더 경로
    @Published var ResultDirUrl: URL? = nil // 결과 출력 폴더 주소
    @Published var testItem: [String]? = UserDefaults.standard.stringArray(forKey: "testItem") ?? nil // 테스트 파일 내용
    @Published var userIDItem: [String]? = UserDefaults.standard.stringArray(forKey: "userIDItem") ?? nil // 신상 정보 파일 내용
    @Published var answerItem: [String]? = UserDefaults.standard.stringArray(forKey: "answerItem") ?? nil // 정답 파일 내용
    
    @Published var userID = "" // 식별자
    @Published var userPW = "" // PIN
    @Published var userAnswer: [String] = UserDefaults.standard.stringArray(forKey: "userAnswer") ?? [] // 지원자 응답
    @Published var userPoint = 0 // 정답 개수
}
