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
    @State private var adminID = ""
    @State private var adminPW = ""
    @State private var auth = false
    @State private var safe = false
    @State private var isAlert = false
    var body: some View {
        VStack {
            Text("테스트에 사용할 문제 & 신상파일, 결과 출력 폴더 선택")
                .font(.title).bold().padding().fixedSize()
            HStack {
                VStack {
                    TextField("관계자 아이디", text: self.$adminID).frame(width: 125).disabled(self.auth)
                    SecureField("관계자 비밀번호", text: self.$adminPW).frame(width: 125).disabled(self.auth)
                }
                VStack {
                    Button(action: {
                        if !self.auth {
                            if (self.adminID == self.UserDB.adminID) && (self.adminPW == self.UserDB.adminPW) {
                                self.auth = true
                                if self.UserDB.adminID == "admin" && self.UserDB.adminPW == "passwd" {
                                    self.safe = false
                                } else {
                                    self.safe = true
                                }
                            } else {
                                self.isAlert = true
                            }
                        } else {
                            self.auth = false
                            self.adminID = ""
                            self.adminPW = ""
                        }
                    }) { self.auth ? Text("로그아웃") : Text("로그인") }.alert(isPresented: self.$isAlert) {
                        Alert(title: Text("관계자 아이디 또는 비밀번호가 다릅니다. "), dismissButton: .default(Text("승인"), action: { self.adminID = ""; self.adminPW = "" }))
                    }
                    Button(action: {
                        if self.auth { self.UserDB.auth = true } else { self.UserDB.auth = false }
                        self.UserDB.status = "RAChange"
                    }){ self.auth ? Text("아이디 & 비번 변경") : Text("아이디 & 비번 초기화") }
                }
            }
            VStack {
                HStack {
                    if (self.auth && !self.safe) {
                        VStack {
                            Text("기존 비밀번호를 사용할 경우 보안상 취약할 수 있음")
                                .bold().padding().fixedSize()
                            HStack {
                                Button(action: {
                                    self.UserDB.auth = true
                                    self.UserDB.status = "RAChange"
                                }) { Text("지금 변경") }
                                Button(action: { self.safe = true }) {
                                    Text("다음에 변경")
                                }
                            }
                        }
                    }
                    if (self.UserDB.TestFile == nil && self.auth && self.safe) {
                        Button(action: {
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
                                        UserDefaults.standard.set(self.UserDB.TestFile, forKey: "TestFile")
                                        UserDefaults.standard.set(self.UserDB.testItem, forKey: "testItem")
                                    }
                                } else {
                                    return
                                }
                            }
                        }) {
                            Text("테스트 파일 선택...")
                        }
                    } else {
                        if (self.auth && self.safe) {
                            VStack {
                            Text("현재 선택된 테스트 파일").foregroundColor(.green)
                            Text(self.UserDB.TestFile!)
                            Text("")
                            }
                        }
                    }
                    if (self.safe) {
                        Spacer()
                    }
                    if (self.UserDB.UserFile == nil && self.auth && self.safe) {
                        Button(action: {
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
                                        UserDefaults.standard.set(self.UserDB.UserFile, forKey: "UserFile")
                                        UserDefaults.standard.set(self.UserDB.userIDItem, forKey: "userIDItem")
                                    }
                                } else {
                                    return
                                }
                            }
                        }) {
                            Text("신상정보 파일 선택...")
                        }
                    } else {
                        if (self.auth && self.safe) {
                            VStack {
                            Text("현재 선택된 신상 파일").foregroundColor(.green)
                            Text(self.UserDB.UserFile!)
                            Text("")
                            }
                        }
                    }
                }.padding()
                HStack {
                    if (self.UserDB.AnswerFile == nil && self.auth && self.safe) {
                        Button(action: {
                            let answer = NSOpenPanel()
                            answer.title = "정답 채점에 사용할 파일 선택..."
                            answer.canChooseDirectories = false
                            answer.canChooseFiles = true
                            answer.canCreateDirectories = false
                            answer.allowsMultipleSelection = false
                            answer.allowedFileTypes = ["txt"]
                            answer.allowsOtherFileTypes = false
                            DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
                                if answer.runModal() == .OK {
                                    if (answer.url != nil) {
                                        self.UserDB.AnswerFile = answer.url!.path
                                        let fileResult = try! NSString(contentsOfFile: NSString(string: answer.url!.path) as String, encoding: String.Encoding.utf8.rawValue)
                                        self.UserDB.answerItem = fileResult.components(separatedBy: ",")
                                        for _ in 0..<self.UserDB.answerItem!.count {
                                            self.UserDB.userAnswer.append("")
                                        }
                                        UserDefaults.standard.set(self.UserDB.AnswerFile, forKey: "AnswerFile")
                                        UserDefaults.standard.set(self.UserDB.answerItem, forKey: "answerItem")
                                        UserDefaults.standard.set(self.UserDB.userAnswer, forKey: "userAnswer")
                                    }
                                } else {
                                    return
                                }
                            }
                        }) {
                            Text("정답 파일 선택...")
                        }
                    } else {
                        if (self.auth && self.safe) {
                            VStack {
                            Text("현재 선택된 정답 파일").foregroundColor(.green)
                            Text(self.UserDB.AnswerFile!)
                            Text("")
                            }
                        }
                    }
                    if (self.safe) {
                        Spacer()
                    }
                    if (self.UserDB.ResultDirPath == nil && self.auth && self.safe) {
                            Button(action: {
                                let resultDir = NSOpenPanel()
                                resultDir.title = "결과 출력할 폴더 선택..."
                                resultDir.canChooseDirectories = true
                                resultDir.canChooseFiles = false
                                resultDir.canCreateDirectories = false
                                resultDir.allowsMultipleSelection = false
                                resultDir.allowsOtherFileTypes = false
                                DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
                                    if resultDir.runModal() == .OK {
                                        if (resultDir.url != nil) {
                                            self.UserDB.ResultDirPath = resultDir.url!.path
                                            self.UserDB.ResultDirUrl = resultDir.url!
                                            UserDefaults.standard.set(self.UserDB.ResultDirUrl, forKey: "ResultDirUrl")
                                            UserDefaults.standard.set(self.UserDB.ResultDirPath, forKey: "ResultDirPath")
                                        }
                                    } else {
                                        return
                                    }
                                }
                            }) {
                                Text("결과 출력 폴더 선택...")
                            }
                    } else {
                        if (self.auth && self.safe) {
                            VStack {
                            Text("현재 선택된 결과 출력 폴더").foregroundColor(.green)
                            Text(self.UserDB.ResultDirPath!)
                            Text("")
                            }
                        }
                    }
                }.padding()
                if (self.auth && self.safe) {
                    Button(action: {
                        self.UserDB.TestFile = nil
                        self.UserDB.UserFile = nil
                        self.UserDB.AnswerFile = nil
                        self.UserDB.testItem = nil
                        self.UserDB.userIDItem = nil
                        self.UserDB.userAnswer = []
                        self.UserDB.answerItem = nil
                        self.UserDB.ResultDirPath = nil
                        self.UserDB.ResultDirUrl = nil
                        UserDefaults.standard.removeObject(forKey: "TestFile")
                        UserDefaults.standard.removeObject(forKey: "UserFile")
                        UserDefaults.standard.removeObject(forKey: "AnswerFile")
                        UserDefaults.standard.removeObject(forKey: "testItem")
                        UserDefaults.standard.removeObject(forKey: "userIDItem")
                        UserDefaults.standard.removeObject(forKey: "answerItem")
                        UserDefaults.standard.removeObject(forKey: "ResultDirPath")
                        UserDefaults.standard.removeObject(forKey: "ResultDirUrl")
                    }) {
                        Text("파일 제거").foregroundColor(.red)
                    }.disabled(self.UserDB.TestFile == nil && self.UserDB.UserFile == nil && self.UserDB.AnswerFile == nil && self.UserDB.ResultDirPath == nil)
                }
                Text("지원하는 형식: txt")
                
                Button(action: { self.UserDB.status = "Intro" }) {
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
