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
            if self.UserDB.status == 0 {
                Intro()
            } else if self.UserDB.status == 1 {
                UserIdentify()
            }
            Text("본 문제를 무단 복제, 공유, 배포시 법적 책임을 물을 수 있습니다. ")
                .foregroundColor(.red).padding()
        }
    }
}


struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
