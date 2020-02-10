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
    var body: some View {
        VStack {
            if self.UserDB.status == "Intro" {
                Intro()
            } else if self.UserDB.status == "UserIdentify" {
                UserIdentify()
            } else if self.UserDB.status == "TestOFSelect" {
                TestOFSelect()
            } else if self.UserDB.status == "TestStart" {
                TestStart()
            } else if self.UserDB.status == "Result" {
                Result()
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
        }.frame(idealWidth: 1024, maxWidth: .infinity, idealHeight: 768, maxHeight: .infinity)
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
