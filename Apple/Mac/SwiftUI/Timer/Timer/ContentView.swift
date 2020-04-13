//
//  ContentView.swift
//  Timer
//
//  Created by HM on 2020/04/12.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

var now = Date()

struct ContentView: View {
    @State var setTimer = false
    @State var setTime = 0
    @State var startTime = 0
    @State var pause = false
    @State var timer: Timer?
    var body: some View {
        VStack {
            if !setTimer {
                Text("타이머 설정").bold().padding().fixedSize().font(.largeTitle)
                Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title).foregroundColor(.gray)
                VStack {
                    Text("초 설정")
                    HStack {
                        Button(action: {
                            self.startTime += 1
                            self.pause = false
                            now = Date()
                        }, label: { Text("+1초") }).disabled(self.startTime + 1 >= 86400)
                        Button(action: {
                            self.startTime += 5
                            self.pause = false
                            now = Date()
                        }, label: { Text("+5초") }).disabled(self.startTime + 5 >= 86400)
                        Button(action: {
                            self.startTime += 10
                            self.pause = false
                            now = Date()
                        }, label: { Text("+10초") }).disabled(self.startTime + 10 >= 86400)
                    }
                    HStack {
                        Button(action: {
                            self.startTime -= 1
                            self.pause = false
                            now = Date()
                        }, label: { Text("-1초") }).disabled(self.startTime - 1 < 0)
                        Button(action: {
                            self.startTime -= 5
                            self.pause = false
                            now = Date()
                        }, label: { Text("-5초") }).disabled(self.startTime - 5 < 0)
                        Button(action: {
                            self.startTime -= 10
                            self.pause = false
                            now = Date()
                        }, label: { Text("-10초") }).disabled(self.startTime - 10 < 0)
                    }
                }
                VStack {
                    Text("분 설정")
                    HStack {
                        Button(action: {
                            self.startTime += 60
                            self.pause = false
                            now = Date()
                        }, label: { Text("+1분") }).disabled(self.startTime + 60 >= 86400)
                        Button(action: {
                            self.startTime += 300
                            self.pause = false
                            now = Date()
                        }, label: { Text("+5분") }).disabled(self.startTime + 300 >= 86400)
                        Button(action: {
                            self.startTime += 600
                            self.pause = false
                            now = Date()
                        }, label: { Text("+10분") }).disabled(self.startTime + 600 >= 86400)
                    }
                    HStack {
                        Button(action: {
                            self.startTime -= 60
                            self.pause = false
                            now = Date()
                        }, label: { Text("-1분") }).disabled(self.startTime - 60 < 0)
                        Button(action: {
                            self.startTime -= 300
                            self.pause = false
                            now = Date()
                        }, label: { Text("-5분") }).disabled(self.startTime - 300 < 0)
                        Button(action: {
                            self.startTime -= 600
                            self.pause = false
                            now = Date()
                        }, label: { Text("-10분") }).disabled(self.startTime - 600 < 0)
                    }
                }
                VStack {
                    Text("시 설정")
                    HStack {
                        Button(action: {
                            self.startTime += 3600
                            self.pause = false
                            now = Date()
                        }, label: { Text("+1시") }).disabled(self.startTime + 3600 >= 86400)
                        Button(action: {
                            self.startTime -= 3600
                            self.pause = false
                            now = Date()
                        }, label: { Text("-1시") }).disabled(self.startTime - 3600 < 0)
                    }
                }
                HStack {
                    Text("ETA: ")
                    self.startTime == 0 ? Text("N/A") : Text(convertDate(inputTime: self.startTime, secEnable: false))
                }
                HStack {
                    Button(action: {
                        self.setTimer = true
                        if !self.pause {
                            self.setTime = self.startTime
                        } else {
                            self.pause = false
                        }
                        now = Date()
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
                if self.startTime != 0 {
                    Text("타이머 시작").bold().padding().fixedSize().font(.largeTitle)
                } else {
                    Text("타이머 완료").bold().padding().fixedSize().font(.largeTitle)
                }
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
                    Text("ETA: ")
                    Text(convertDate(inputTime: self.setTime, secEnable: true))
                }
                HStack {
                    Button(action: {
                        self.setTimer = false
                        self.startTime = self.setTime
                        self.timer?.invalidate()
                    }, label: { self.startTime != 0 ? Text("정지") : Text("이전") })
                    Button(action: {
                        self.setTimer = false
                        self.pause = true
                        self.timer?.invalidate()
                    }, label: { Text("일시 정지") }).disabled(self.startTime == 0)
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

private func convertDate(inputTime: Int, secEnable: Bool) -> String {
    let date = DateFormatter()
    let convertedTime = now + TimeInterval(inputTime) as Date
    if secEnable {
        date.dateFormat = "HH:mm:ss"
    } else {
        date.dateFormat = "HH:mm"
    }
        
    return String(date.string(from: convertedTime))
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
