//
//  TestStart.swift
//  Recruitment Assistant
//
//  Created by HM on 2020/02/09.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct TestStart: View {
    @EnvironmentObject var UserDB: UserDB
    @State private var isAlert = false
    @State private var title = ""
    @State private var message = ""
    @State private var currentItem = 0
    @State private var currentAnswer = ""
    var body: some View {
        VStack{
            Text("\(self.UserDB.userID)님 좋은 결과가 있으시길 바랍니다. ")
                .font(.custom("Airal", size: 23)).foregroundColor(.purple).bold().padding().fixedSize()
            Text(self.UserDB.testItem![currentItem]).lineLimit(nil).multilineTextAlignment(.leading)
            TextField("답안 입력", text: self.$currentAnswer).lineLimit(nil).multilineTextAlignment(.leading).frame(width: 400).padding()
            Spacer()
            HStack {
                if self.currentItem == 0 {
                    Button(action: { self.UserDB.status = "Intro" }) { Text("메인") }
                    Button(action: {
                        self.UserDB.userAnswer[self.currentItem] = self.currentAnswer
                        self.currentAnswer = ""
                        self.currentItem += 1
                    }) {Text("다음")}
                } else if (self.UserDB.testItem!.count - 1) == self.currentItem {
                    Button(action: {
                        self.currentItem -= 1
                        self.currentAnswer = (self.UserDB.userAnswer[self.currentItem])
                    }) {Text("이전")}
                    Button(action: {
                        self.UserDB.userAnswer[self.currentItem] = self.currentAnswer
                        self.isAlert = true
                        self.title = "마지막으로 한번 더 확인하시기 바랍니다. "
                        self.message = "시험을 마칠 경우 이후 수정을 할 수 없음을 숙지 바랍니다. "
                    }) { Text("채점") }.alert(isPresented: self.$isAlert) {
                        Alert(title: Text(self.title), message: Text(self.message), primaryButton: .destructive(Text("마침")) {
                            for i in 0..<self.UserDB.userAnswer.count {
                                if self.UserDB.answerItem![i] == self.UserDB.userAnswer[i] {
                                    self.UserDB.userPoint += 1
                                }
                            }
                            self.UserDB.status = "Result"
                        }, secondaryButton: .cancel(Text("검토")))
                    }
                } else {
                    Button(action: {
                        self.currentItem -= 1
                        self.currentAnswer = (self.UserDB.userAnswer[self.currentItem])
                    }) {Text("이전")}
                    Button(action: {
                        self.UserDB.userAnswer[self.currentItem] = self.currentAnswer
                        self.currentAnswer = ""
                        self.currentItem += 1
                    }) {Text("다음")}
                }
            }
        }
    }
}

struct TestStart_Previews: PreviewProvider {
    static var previews: some View {
        TestStart()
    }
}
