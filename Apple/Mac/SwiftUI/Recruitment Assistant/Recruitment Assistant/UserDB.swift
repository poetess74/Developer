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
    
    @Published var TestFile: String? // 테스트 파일 경로
    @Published var UserFile: String? // 신상 정보 파일 경로
    @Published var AnswerFile: String? // 정답 파일 경로
    @Published var ResultDirPath: String? // 결과 출력 폴더 경로
    @Published var ResultDirUrl: URL? // 결과 출력 폴더 주소
    @Published var testItem: [String]? // 테스트 파일 내용
    @Published var userIDItem: [String]? // 신상 정보 파일 내용
    @Published var answerItem: [String]? // 정답 파일 내용
    
    @Published var userID = "" // 식별자
    @Published var userPW = "" // PIN
    @Published var userAnswer: [String] = [] // 지원자 응답
    @Published var userPoint = 0 // 정답 개수
}
