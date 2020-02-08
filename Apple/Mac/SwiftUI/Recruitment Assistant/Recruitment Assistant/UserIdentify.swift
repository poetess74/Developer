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
    var body: some View {
        VStack {
            Text("지원자의 신원정보를 입력하여 주세요. ")
                .font(.title).bold().padding()
            HStack {
                Text("성명")
            }
            HStack {
                Text("고유식별번호")
            }
        }
    }
}

struct UserIdentify_Previews: PreviewProvider {
    static var previews: some View {
        UserIdentify()
    }
}
