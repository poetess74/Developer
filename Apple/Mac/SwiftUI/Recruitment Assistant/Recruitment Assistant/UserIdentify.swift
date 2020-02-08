//
//  UserIdentify.swift (1)
//  Recruitment Assistant
//
//  Created by HM on 2020/02/08.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct UserIdentify: View {
    @EnvironmentObject var UserDB: UserDB
    @State private var isAlert = false
    @State private var userID = ""
    @State private var userPW = ""
    @State private var title = ""
    @State private var message = ""
    var body: some View {
        VStack {
            Text("지원자의 신원정보를 입력하여 주세요. ")
                .font(.title).bold().padding().fixedSize()
            HStack {
                TextField("지원 코드", text: $userID).frame(width: 90)
                SecureField("PIN", text: $userPW).frame(width: 40)
            }
            HStack {
                Button(action: { self.UserDB.status = "Intro" }) {
                    Text("메인")
                }.padding()
                Button(action: {
                    if (self.UserDB.TestFile != "") {
                        if (self.userID != "" && self.userID.count != 8 && self.userPW != "" && self.userPW.count != 4) {
                            let userInput = self.userID + self.userPW
                            if (userInput == "CHECKSUM_ON_SERVER") {
                                self.UserDB.status = "TestStart"
                            } else {
                                self.isAlert = true
                                self.title = "올바른 고유식별번호가 아닙니다. "
                                self.message = "\(self.userID) 은(는) 올바른 고유식별번호가 아닙니다. "
                                self.userID = ""
                                self.userPW = ""
                            }
                        } else {
                            self.isAlert = true
                            self.title = "올바른 고유식별번호가 아닙니다. "
                            self.message = "\(self.userID) 은(는) 올바른 고유식별번호가 아닙니다. "
                            self.userID = ""
                            self.userPW = ""
                        }
                    } else {
                        self.isAlert = true
                        self.title = "테스트에 사용할 문제가 없습니다. "
                        self.message = "테스트에 사용할 문제파일을 선택하여 주시기 바랍니다. 승인 버튼을 누를 경우 자동으로 문제파일을 선택하는 화면으로 전환되며 권한이 있는 사람만 문제파일을 지정할 수 있으므로 지원자일 경우 관계자에게 알려 주시길 바랍니다. "
                    }
                }) { Text("다음") }.padding().alert(isPresented: self.$isAlert) {
                    Alert(title: Text(self.title), message: Text(self.message), dismissButton: .default(Text("승인"), action: { self.UserDB.status = "TestOFSelect" }))
                }
            }
            Text("지원자의 개인정보는 안전하게 처리되며 본 용도 외에는 사용되지 않습니다. ")
        }
    }
}

struct UserIdentify_Previews: PreviewProvider {
    static var previews: some View {
        UserIdentify()
    }
}
