//
//  ContentView.swift
//  Timer
//
//  Created by HM on 2020/04/12.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @State var setTimer = false
    @State var setTime = 0
    @State var startTime = 0
    @State var timer: Timer?
    var body: some View {
        VStack {
            if !setTimer {
                Text("타이머 설정").bold().padding().fixedSize().font(.largeTitle)
                Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title).foregroundColor(.gray)
                HStack {
                    Button(action: { self.startTime += 60 }, label: { Text("+1분") }).disabled(self.startTime + 60 >= 86400)
                    Button(action: { self.startTime += 300 }, label: { Text("+5분") }).disabled(self.startTime + 300 >= 86400)
                    Button(action: { self.startTime += 600 }, label: { Text("+10분") }).disabled(self.startTime + 600 >= 86400)
                }
                HStack {
                    Button(action: { self.startTime -= 60 }, label: { Text("-1분") }).disabled(self.startTime - 60 < 0)
                    Button(action: { self.startTime -= 300 }, label: { Text("-5분") }).disabled(self.startTime - 300 < 0)
                    Button(action: { self.startTime -= 600 }, label: { Text("-10분") }).disabled(self.startTime - 600 < 0)
                }
                HStack {
                    Button(action: {
                        self.setTimer = true
                        self.setTime = self.startTime
                        self.timer = Timer.scheduledTimer(withTimeInterval: 1, repeats: true, block: { _ in
                            guard self.startTime > 0 else {
                                self.timer?.invalidate()
                                return
                            }
                            self.startTime -= 1
                        })
                    }, label: { Text("시작") }).disabled(self.startTime == 0)
                    Button(action: { self.startTime = 0 }, label: { Text("초기화")}).disabled(self.startTime == 0)
                }
            } else {
                Text("타이머 시작").bold().padding().fixedSize().font(.largeTitle)
                if self.startTime % 2 == 0 {
                    if 32 > self.startTime && self.startTime > 24 {
                        Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title).foregroundColor(.red)
                    } else if self.startTime == 0 {
                        Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title).background(Color.red)
                    } else {
                        Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title)
                    }
                } else {
                    if 7 > self.startTime && self.startTime > 0 {
                        Text(convertTime(inputTime: self.startTime, dotEnable: false)).font(.title).foregroundColor(.red)
                    } else {
                        Text(convertTime(inputTime: self.startTime, dotEnable: false)).font(.title)
                    }
                }
                HStack {
                    Button(action: {
                        self.setTimer = false
                        self.startTime = self.setTime
                        self.timer?.invalidate()
                    }, label: { Text("정지") })
                    Button(action: {
                        self.setTimer = false
                        self.startTime = 0
                        self.timer?.invalidate()
                    }, label: { Text("초기화") })
                }
            }
        }.padding()
    }
}

private func convertTime(inputTime: Int, dotEnable: Bool) -> String {
    let hour = inputTime / 3600
    let min = inputTime / 60 % 60
    let sec = inputTime % 60
    
    if dotEnable {
        return String(format: "%02i:%02i:%02i", hour, min, sec)
    } else {
        return String(format: "%02i %02i %02i", hour, min, sec)
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
