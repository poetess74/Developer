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
                        ((self.userID == self.UserDB.adminID) && (self.userPW == self.UserDB.adminPW)) ? (self.auth = true) : (self.isAlert = true)
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
                        Button(action: {
                            //TODO: Test File picker popup make
                            let test = NSOpenPanel()
                            test.title = "테스트에 사용할 파일 선택..."
                            test.canChooseDirectories = false
                            test.canChooseFiles = true
                            test.canCreateDirectories = false
                            test.allowsMultipleSelection = false
                            test.allowedFileTypes = ["txt"]
                            test.allowsOtherFileTypes = false
                            DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
                                if test.runModal() == .OK {
                                    if (test.url != nil) {
                                        self.UserDB.TestFile = test.url!.path
                                        let fileResult = try! NSString(contentsOfFile: NSString(string: test.url!.path) as String, encoding: String.Encoding.utf8.rawValue)
                                        self.UserDB.testItem = fileResult.components(separatedBy: ",")
                                        for i in 0..<self.UserDB.testItem!.count {
                                            print(self.UserDB.testItem![i])
                                        }
                                    }
                                } else {
                                    return
                                }
                            }
                        }) {
                            Text("테스트 파일 선택...")
                        }.disabled(!self.auth)
                    }
                } else {
                    Text("현재 선택된 테스트 파일")
                    Text(self.UserDB.TestFile!)
                }
                if (self.UserDB.UserFile == nil) {
                    HStack {
                        Button(action: {
                            //TODO: Test File picker popup make
                            let user = NSOpenPanel()
                            user.title = "신상정보 식별에 사용할 파일 선택..."
                            user.canChooseDirectories = false
                            user.canChooseFiles = true
                            user.canCreateDirectories = false
                            user.allowsMultipleSelection = false
                            user.allowedFileTypes = ["txt"]
                            user.allowsOtherFileTypes = false
                            DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
                                if user.runModal() == .OK {
                                    if (user.url != nil) {
                                        self.UserDB.UserFile = user.url!.path
                                        let fileResult = try! NSString(contentsOfFile: NSString(string: user.url!.path) as String, encoding: String.Encoding.utf8.rawValue)
                                        self.UserDB.userIDItem = fileResult.components(separatedBy: "\n")
                                        for i in 0..<self.UserDB.userIDItem!.count {
                                            print(self.UserDB.userIDItem![i])
                                        }
                                    }
                                } else {
                                    return
                                }
                            }
                        }) {
                            Text("신상정보 파일 선택...")
                        }.disabled(!self.auth)
                    }
                } else {
                    Text("현재 선택된 신상 파일")
                    Text(self.UserDB.UserFile!)
                }
                Button(action: {
                    self.UserDB.TestFile = nil
                    self.UserDB.UserFile = nil
                    self.UserDB.testItem = nil
                    self.UserDB.userIDItem = nil
                }) {
                    Text("파일 제거")
                }.disabled(self.UserDB.TestFile == nil && self.UserDB.UserFile == nil).disabled(!self.auth)
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
