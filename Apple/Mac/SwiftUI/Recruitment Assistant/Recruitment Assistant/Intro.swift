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
                    if self.UserDB.TestFile != nil && self.UserDB.UserFile != nil && self.UserDB.AnswerFile != nil && self.UserDB.ResultDirPath != nil {
                        self.UserDB.status = "UserIdentify"
                    } else {
                        self.isAlert = true
                    }
                }) { Text("신원 확인") }.padding().alert(isPresented: self.$isAlert) {
                    Alert(title: Text("테스트를 시작할 수 없습니다. "), message: Text("필수 파일 또는 폴더가 하나 이상 설정되어 있지 않았으므로 테스트를 시작할 수 없습니다. 문제가 지속적으로 일어날 경우 관계자에게 알려 주시기 바랍니다. 지정되지 않은 파일 또는 폴더 목록은 아래의 \"다음이 지정되지 않았음\" 섹션을 참조하십시오. "), dismissButton: .default(Text("승인")))
                }
                Button(action: { self.UserDB.status = "TestOFSelect" }) { Text("문항 선택") }
            }
            Text("지원자는 \"신원 확인\" 버튼을 눌러 출석체크를 하고 테스트를 시작합니다. \n다만 \"문항 선택\" 버튼은 관계자 외 누르지 마시기 바랍니다. ")
                .lineLimit(nil).multilineTextAlignment(.center).foregroundColor(.purple).fixedSize().padding()
            Text("\((self.UserDB.TestFile == nil || self.UserDB.UserFile == nil || self.UserDB.AnswerFile == nil || self.UserDB.ResultDirPath == nil) ? "다음이 지정되지 않았음" : "")").foregroundColor(.orange)
            HStack {
                if self.UserDB.TestFile == nil {
                    Text("문제 파일")
                }
                if self.UserDB.UserFile == nil {
                    Text("신상 파일")
                }
                if self.UserDB.AnswerFile == nil {
                    Text("정답 파일")
                }
                if self.UserDB.ResultDirPath == nil {
                    Text("결과 폴더")
                }
            }.foregroundColor(.orange)
            Text("프로그램의 저작권은 그린게코게임즈에 있습니다. ").padding()
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
