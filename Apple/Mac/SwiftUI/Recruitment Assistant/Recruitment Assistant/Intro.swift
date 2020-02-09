//
//  Intro.swift
//  Recruitment Assistant
//
//  Created by HM on 2020/02/08.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct Intro: View {
    @EnvironmentObject var UserDB: UserDB
    @State private var isAlert = false
    var body: some View {
        VStack {
            Text("본 회사에 지원해 주셔서 진심으로 감사드립니다. ")
                .font(.title).bold().padding().fixedSize()
            HStack {
                Button(action: {
                    if self.UserDB.TestFile != nil || self.UserDB.UserFile != nil || self.UserDB.AnswerFile != nil || self.UserDB.ResultDirPath != nil {
                        self.UserDB.status = "UserIdentify"
                    } else {
                        self.isAlert = true
                    }
                }) { Text("신원 확인") }.padding().alert(isPresented: self.$isAlert) {
                    Alert(title: Text("테스트에 사용할 문제가 없습니다. "), message: Text("테스트에 사용할 문제 & 신상파일 및 결과 폴더를 선택하여 주시기 바랍니다. 승인 버튼을 누를 경우 자동으로 선택하는 화면으로 전환되며 권한이 있는 사람만 지정할 수 있으므로 지원자일 경우 관계자에게 알려 주시길 바랍니다. "), dismissButton: .default(Text("승인"), action: { self.UserDB.status = "TestOFSelect" }))
                }
                Button(action: { self.UserDB.status = "TestOFSelect" }) {
                    Text("문항 선택")
                }
            }
            Text("지원자는 \"신원 확인\" 버튼을 눌러 출석체크를 하고 테스트를 시작합니다. \n다만 \"문항 선택\" 버튼은 관계자 외 누르지 마시기 바랍니다. ")
                .lineLimit(nil).multilineTextAlignment(.center).foregroundColor(.purple).fixedSize()
            HStack {
                Text("\(self.UserDB.TestFile == nil ? "현재 테스트에 사용할 문제 & 신상 파일, 결과 폴더가 지정되지 않았습니다. " : "")")
            }.padding().foregroundColor(.orange)
            Text("프로그램의 저작권은 그린게코게임즈에 있습니다. ")
            Text("본 출제된 문제를 무단 복제, 공유, 배포시 법적 책임을 물을 수 있습니다. ")
                .foregroundColor(.red)
        }
    }
}

struct Intro_Previews: PreviewProvider {
    static var previews: some View {
        Intro()
    }
}
