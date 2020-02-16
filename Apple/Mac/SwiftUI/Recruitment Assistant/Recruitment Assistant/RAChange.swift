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
    @State private var captchaInput = ""
    @State private var adminID = ""
    @State private var adminPW = ""
    @State private var title = ""
    @State private var message = ""
    @State private var isAlert = false
    @State private var captcha = arc4random_uniform(8999) + 1000
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
                        SecureField("변경할 비밀번호 검증", text: self.$captchaInput).frame(width: 150)
                    } else {
                        Text("\(self.captcha)")
                            .font(.title).padding().fixedSize()
                        TextField("캡챠 숫자만 입력", text: self.$captchaInput).frame(width: 150)
                        TextField("기본 관계자 아이디 입력", text: self.$adminID).frame(width: 150)
                        SecureField("기본 관계자 비밀번호 입력", text: self.$adminPW).frame(width: 150)
                    }
                }
                VStack {
                    if self.UserDB.auth {
                        Button(action: {
                            if !self.adminPW.isEmpty {
                                if self.adminPW == self.captchaInput {
                                    self.UserDB.adminPW = self.adminPW
                                    UserDefaults.standard.set(self.UserDB.adminPW, forKey: "adminPW")
                                    if !self.adminID.isEmpty {
                                        self.UserDB.adminID = self.adminID
                                        UserDefaults.standard.set(self.UserDB.adminID, forKey: "adminID")
                                    }
                                    self.UserDB.auth = false
                                    self.UserDB.status = "TestOFSelect"
                                } else {
                                    self.isAlert = true
                                    self.title = "비밀번호와 검증이 다릅니다. "
                                }
                            } else if !self.adminID.isEmpty {
                                self.UserDB.adminID = self.adminID
                                UserDefaults.standard.set(self.UserDB.adminID, forKey: "adminID")
                                self.UserDB.auth = false
                                self.UserDB.status = "TestOFSelect"
                            }
                        }) { Text("변경") }.padding().disabled(self.adminID.isEmpty && (self.adminPW.isEmpty ||  self.captchaInput.isEmpty) || !self.adminID.isEmpty && (!self.adminPW.isEmpty && self.captchaInput.isEmpty) || !self.adminID.isEmpty && (self.adminPW.isEmpty && !self.captchaInput.isEmpty)).alert(isPresented: self.$isAlert) {
                            Alert(title: Text(self.title), message: Text(self.message), dismissButton: .default(Text("승인"), action: {
                                self.captchaInput = ""
                                self.adminPW = ""
                            }))
                        }
                    } else if !self.UserDB.auth {
                        Button(action: {
                            self.captcha = arc4random_uniform(8999) + 1000
                        }) { Text("새로고침") }.padding()
                        Button(action: {
                            if UInt(self.captchaInput) == UInt(self.captcha) && UInt(self.captchaInput) != nil && self.adminID == "admin" && self.adminPW == "passwd" {
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
                                self.UserDB.status = "TestOFSelect"
                            } else if UInt(self.captchaInput) == UInt(self.captcha) && UInt(self.captchaInput) != nil && (self.adminID != "admin" || self.adminPW != "passwd"){
                                self.isAlert = true
                                self.adminID = ""
                                self.adminPW = ""
                                self.title = "관계자 아이디 또는 비밀번호가 다릅니다. "
                                self.message = "초기 아이디와 비밀번호를 입력했는지 다시 확인하여 주십시오. "
                                self.captcha = arc4random_uniform(8999) + 1000
                            } else {
                                self.isAlert = true
                                self.title = "보안코드를 올바르게 입력해 주세요."
                                self.captcha = arc4random_uniform(8999) + 1000
                            }
                        }) { Text("초기화") }.padding().disabled(self.captchaInput.isEmpty || self.adminID.isEmpty || self.adminPW.isEmpty).alert(isPresented: self.$isAlert) {
                            Alert(title: Text(self.title), message: Text(self.message), dismissButton: .default(Text("승인"), action: {
                                self.captchaInput = ""
                            }))
                        }
                    }
                }
            }
            if !self.UserDB.auth {
                Text("관계자 아이디 & 비밀번호 초기화는 즉시 적용되며")
                Text("지정된 파일들은 정보 보호를 위해 설정이 초기화 됩니다. ")
            }
            Text("").padding()
            Text("만약 지원자가 관계자 계정을 변경 하였을 경우에는 회사가 지원자를 불합격 처리할 수 있습니다. ").foregroundColor(.purple)
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
