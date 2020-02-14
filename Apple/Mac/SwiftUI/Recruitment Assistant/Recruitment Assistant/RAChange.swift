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
    var body: some View {
        VStack {
            Text("관계자 아이디 & 비밀번호 변경")
            .font(.title).bold().padding().fixedSize()
            HStack {
                VStack {
                    if self.UserDB.auth {
                        Text("만약 현행 유지하고 싶으면 비워두기")
                        TextField("변경할 관계자 아이디", text: self.$adminID).frame(width: 150)
                        SecureField("변경할 관계자 비밀번호", text: self.$adminPW).frame(width: 150)
                    }
                }
                VStack {
                    Button(action: {
                        if !self.UserDB.auth {
                            self.UserDB.adminID = "admin"
                            self.UserDB.adminPW = "passwd"
                            UserDefaults.standard.set(self.UserDB.adminID, forKey: "adminID")
                            UserDefaults.standard.set(self.UserDB.adminPW, forKey: "adminPW")
                            self.UserDB.status = "TestOFSelect"
                        } else {
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
                        }
                    }) { self.UserDB.auth ? Text("변경") : Text("초기화") }.padding()
                }
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
