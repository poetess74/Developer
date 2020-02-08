//
//  Intro.swift (0)
//  Recruitment Assistant
//
//  Created by HM on 2020/02/08.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct Intro: View {
    @EnvironmentObject var UserDB: UserDB
    var body: some View {
        VStack {
            Text("지원해 주셔서 진심으로 감사드립니다. ")
                .font(.title).bold().padding()
            Button(action: { self.UserDB.status = 1 }) {
                Text("신원 확인")
            }
            Text("Copyright (c) 2020 Greengecko, Inc. ")
        }
    }
}

struct Intro_Previews: PreviewProvider {
    static var previews: some View {
        Intro()
    }
}
