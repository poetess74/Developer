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
            Text("테스트에 사용할 문제 & 신상파일 선택")
                .font(.title).bold().padding().fixedSize()
            HStack {
                VStack {
                    TextField("관계자 아이디", text: self.$userID).frame(width: 125).disabled(self.auth)
                    SecureField("관계자 패스워드", text: self.$userPW).frame(width: 125).disabled(self.auth)
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
                if (self.UserDB.TestFile == nil) {
                    HStack {
                        Text("현재 선택된 파일: ")
                        Text("없음")
                    }
                } else {
                    Text("현재 선택된 파일")
                    Text(self.UserDB.TestFile!)
                }
                HStack {
                    Button(action: {
                        //TODO: Test File picker popup make
                        let panel = NSOpenPanel()
                        panel.title = "테스트에 사용할 파일 선택..."
                        panel.canChooseDirectories = false
                        panel.canChooseFiles = true
                        panel.canCreateDirectories = false
                        panel.allowsMultipleSelection = false
                        panel.allowedFileTypes = ["txt"]
                        panel.allowsOtherFileTypes = false
                        DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
                            if panel.runModal() == .OK {
                                if (panel.url != nil) {
                                    self.UserDB.TestFile = panel.url!.path
                                    print(try! NSString(contentsOfFile: NSString(string: panel.url!.path) as String, encoding: String.Encoding.utf8.rawValue))
                                }
                            } else {
                                return
                            }
                        }
                    }) {
                        Text("파일 선택")
                    }
                    Button(action: {
                        self.UserDB.TestFile = nil
                    }) {
                        Text("파일 제거")
                    }.disabled(self.UserDB.TestFile == nil)
                }.disabled(!self.auth)
                Text("지원하는 형식: txt")
                
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
