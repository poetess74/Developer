//
//  UserIdentify.swift
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
                    if (self.userID != "" && self.userID.count == 8 && self.userPW != "" && self.userPW.count == 4) {
                        let userInput = self.userID + self.userPW
                        if (userInput == "000000000000") {
                            self.UserDB.status = "TestStart"
                        } else {
                            self.isAlert = true
                            self.title = "지원자의 신원정보를 찾을 수 없습니다. "
                            self.message = "입력하신 고유식별번호 \(self.userID) 을(를) 다시 한번 확인하시고 문제가 지속되면 관계자에게 문의해 주시기 바랍니다. "
                        }
                    } else {
                        self.isAlert = true
                        self.title = "올바른 고유식별번호가 아닙니다. "
                        self.message = "\(self.userID) 은(는) 올바른 고유식별번호가 아닙니다. "
                        self.userID = ""
                    }
                }) { Text("다음") }.padding().alert(isPresented: self.$isAlert) {
                    Alert(title: Text(self.title), message: Text(self.message), dismissButton: .default(Text("승인"), action: {self.userPW = ""}))
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
