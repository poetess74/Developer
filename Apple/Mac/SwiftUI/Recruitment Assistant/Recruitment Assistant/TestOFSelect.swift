//
//  TestOFSelect.swift
//  Recruitment Assistant
//
//  Created by HM on 2020/02/08.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct TestOFSelect: View {
    @EnvironmentObject var UserDB: UserDB
    @State private var userID = ""
    @State private var userPW = ""
    @State private var auth = false
    @State private var isAlert = false
    var body: some View {
        VStack {
            Text("테스트에 사용할 문제파일 선택")
                .font(.title).bold().padding().fixedSize()
            HStack {
                VStack {
                    TextField("관계자 아이디", text: $userID).frame(width: 125).disabled(self.auth)
                    SecureField("관계자 패스워드", text: $userPW).frame(width: 125).disabled(self.auth)
                }
                Button(action: {
                    if !self.auth {
                        ((self.userID == self.UserDB.UserID) && (self.userPW == self.UserDB.UserPW)) ? (self.auth = true) : (self.isAlert = true)
                    } else {
                        self.auth = false
                        self.userID = ""
                        self.userPW = ""
                    }
                }) { self.auth ? Text("로그아웃") : Text("로그인") }.alert(isPresented: self.$isAlert) {
                    Alert(title: Text("아이디 또는 비밀번호가 다릅니다. "), dismissButton: .default(Text("승인"), action: {self.userID = ""; self.userPW = ""}))
                }
            }
            VStack {
                HStack {
                    Text("현재 선택된 파일: ")
                    Text("\(self.UserDB.TestFile == "" ? "없음" : self.UserDB.TestFile)").id("selectedFile")
                }
                HStack {
                    Button(action: {
                        //TODO: Test File picker popup make
                        self.UserDB.status = "TestFileSelectAgent"
                    }) {
                        Text("파일 선택")
                    }
                    Button(action: {
                        self.UserDB.TestFile = ""
                    }) {
                        Text("파일 제거")
                    }
                }.disabled(!self.auth)
                Text("지원하는 형식: txt, json")
                
                Button(action: {self.UserDB.status = "Intro"}) {
                    Text("메인")
                }
            }
        }
    }
}

struct TestOFSelect_Previews: PreviewProvider {
    static var previews: some View {
        TestOFSelect()
    }
}
