//
//  ContentView.swift
//  Recruitment Assistant
//
//  Created by HM on 2020/02/08.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @EnvironmentObject var UserDB: UserDB
    @State private var isAlert = false
    var body: some View {
        VStack {
            if self.UserDB.status == "Intro" {
                Intro()
            } else if self.UserDB.status == "UserIdentify" {
                if UserDB.TestFile != "" {
                    UserIdentify()
                } else {
                    UserIdentify()
                    self.isAlert = true
                    alert(isPresented: self.$isAlert) {
                        Alert(title: "fff", message: "fff", dismissButton: .default(Text("승인"), action: {self.UserDB.status = "TestOFSelect"}))
                    }
                }
            } else if self.UserDB.status == "TestOFSelect" {
                TestOFSelect()
            } else {
                ZStack {
                    Intro()
                    VStack(alignment: .leading) {
                        Text("Unexpected exception resolving reference")
                        .bold().background(Color.white).foregroundColor(.red)
                        Text("• NullReferenceException: ObjectReference not set to an instance of an object at UserDB.status (\(self.UserDB.status)) in ContentView.swift")
                            .foregroundColor(.black).lineLimit(nil).multilineTextAlignment(.leading).background(Color.white)
                        Spacer()
                    }.padding()
                }
            }
            Text("  ")
        }.animation(.default)
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
