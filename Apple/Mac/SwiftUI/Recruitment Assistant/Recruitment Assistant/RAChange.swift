//
//  RAChange.swift
//  Recruitment Assistant
//
//  Created by HM on 2020/02/13.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct RAChange: View {
    @EnvironmentObject var UserDB: UserDB
    @State private var adminID = ""
    @State private var adminPW = ""
    @State private var isAlert = false
    @State private var captcha = arc4random_uniform(9000) + 1000
    var body: some View {
        VStack {
            if self.UserDB.auth {
                Text("관계자 아이디 & 비밀번호 변경")
                    .font(.title).bold().padding().fixedSize()
            } else {
                Text("관계자 아이디 & 비밀번호 초기화")
                    .font(.title).bold().padding().fixedSize()
            }
            HStack {
                VStack {
                    if self.UserDB.auth {
                        Text("만약 현행 유지하고 싶으면 비워두기")
                        TextField("변경할 관계자 아이디", text: self.$adminID).frame(width: 150)
                        SecureField("변경할 관계자 비밀번호", text: self.$adminPW).frame(width: 150)
                    } else {
                        Text("\(self.captcha)")
                            .font(.title).padding().fixedSize()
                        TextField("숫자만 입력", text: self.$adminID).frame(width: 150)
                    }
                }
                VStack {
                    if self.UserDB.auth {
                        Button(action: {
                            if !self.adminID.isEmpty {
                                self.UserDB.adminID = self.adminID
                            }
                            if !self.adminPW.isEmpty {
                                self.UserDB.adminPW = self.adminPW
                            }
                            UserDefaults.standard.set(self.UserDB.adminID, forKey: "adminID")
                            UserDefaults.standard.set(self.UserDB.adminPW, forKey: "adminPW")
                            self.UserDB.auth = false
                            self.UserDB.status = "TestOFSelect"
                        }) { Text("변경") }.padding().disabled(self.adminID.isEmpty && self.adminPW.isEmpty)
                    } else if !self.UserDB.auth {
                        Button(action: {
                            if UInt(self.adminID) == UInt(self.captcha) && UInt(self.adminID) != nil {
                                self.UserDB.adminID = "admin"
                                self.UserDB.adminPW = "passwd"
                                self.UserDB.TestFile = nil
                                self.UserDB.UserFile = nil
                                self.UserDB.AnswerFile = nil
                                self.UserDB.testItem = nil
                                self.UserDB.userIDItem = nil
                                self.UserDB.userAnswer = []
                                self.UserDB.answerItem = nil
                                self.UserDB.ResultDirPath = nil
                                self.UserDB.ResultDirUrl = nil
                                UserDefaults.standard.set(self.UserDB.adminID, forKey: "adminID")
                                UserDefaults.standard.set(self.UserDB.adminPW, forKey: "adminPW")
                                UserDefaults.standard.removeObject(forKey: "TestFile")
                                UserDefaults.standard.removeObject(forKey: "UserFile")
                                UserDefaults.standard.removeObject(forKey: "AnswerFile")
                                UserDefaults.standard.removeObject(forKey: "testItem")
                                UserDefaults.standard.removeObject(forKey: "userIDItem")
                                UserDefaults.standard.removeObject(forKey: "answerItem")
                                UserDefaults.standard.removeObject(forKey: "ResultDirPath")
                                UserDefaults.standard.removeObject(forKey: "ResultDirUrl")
                                self.UserDB.status = "TestOFSelect"
                            } else {
                                self.isAlert = true
                                self.captcha = arc4random_uniform(9000) + 1000
                            }
                        }) { Text("초기화") }.padding().disabled(self.adminID.isEmpty).alert(isPresented: self.$isAlert) {
                            Alert(title: Text("보안코드를 올바르게 입력해 주세요."), dismissButton: .default(Text("승인"), action: {
                                self.adminID = ""
                            }))
                        }
                    }
                }
            }
            if !self.UserDB.auth {
                Text("관계자 아이디 & 비밀번호 초기화는 즉시 적용되며")
                Text("지정된 파일들은 정보 보호를 위해 설정이 초기화 됩니다. ")
            }
            Spacer()
            Button(action: {
                self.UserDB.auth = false
                self.UserDB.status = "TestOFSelect"
            }) { Text("이전") }
        }
    }
}

struct RAChange_Previews: PreviewProvider {
    static var previews: some View {
        RAChange()
    }
}
