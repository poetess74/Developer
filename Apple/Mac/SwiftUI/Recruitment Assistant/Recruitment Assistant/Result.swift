//
//  Result.swift
//  Recruitment Assistant
//
//  Created by HM on 2020/02/09.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct Result: View {
    @EnvironmentObject var UserDB: UserDB
    @State private var str = ""
    var body: some View {
        VStack {
            Text("\(self.UserDB.userID)님의 결과").font(.title).bold().padding().fixedSize()
            Text("\(self.UserDB.answerItem!.count)문제 중 \(self.UserDB.userPoint)문제 맞았습니다. ")
            if self.UserDB.answerItem!.count / 2 > self.UserDB.userPoint {
                Text("불합격").font(.largeTitle).foregroundColor(.red)
            } else {
                Text("합격").font(.largeTitle).foregroundColor(.blue)
            }
            if !saveResult(saveDir: self.UserDB.ResultDirUrl!, id: self.UserDB.userID + self.UserDB.userPW, wholeAnswer: self.UserDB.answerItem!.count, userPoint: self.UserDB.userPoint) {
                Text("결과 파일 저장에 실패하였습니다. ")
                    .foregroundColor(.red)
            }
            Button(action: {
                self.UserDB.userID = ""
                self.UserDB.userPW = ""
                self.UserDB.userAnswer.removeAll()
                for _ in 0..<self.UserDB.answerItem!.count {
                    self.UserDB.userAnswer.append("")
                }
                self.UserDB.userPoint = 0
                self.UserDB.status = "Intro"
            }) { Text("마침") }.padding()
        }
    }
}

private func saveResult(saveDir: URL, id: String, wholeAnswer: Int, userPoint: Int) -> Bool {
    if id.count != 12 { return false }
    let path = saveDir.appendingPathComponent("\(id).txt")
    let text = "지원자: \(id), 합격 여부: \(wholeAnswer / 2 > userPoint ? "불합격" : "합격"), 정답/전체: \(userPoint)/\(wholeAnswer)"
    do {
        NSLog("\(saveDir), \(id) | \(path), \(text)")
        try text.write(to: path, atomically: true, encoding: .utf8)
        return true
    } catch {
        return false
    }
}

struct Result_Previews: PreviewProvider {
    static var previews: some View {
        Result()
    }
}
