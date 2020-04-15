//
//  ContentView.swift
//  Timer
//
//  Created by HM on 2020/04/12.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI
import AVFoundation

var now = Date()
var sound = AVAudioPlayer()

struct ContentView: View {
    @State var setTimer = false
    @State var setTime = 0
    @State var startTime = 0
    @State var pause = false
    @State var timer: Timer?
    @State var hour = 0
    @State var minute = 0
    @State var second = 0
    @State var muteSound = UserDefaults.standard.bool(forKey: "muteCount")
    
    let h = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
    let m = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59]
    let s = [0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55]
    
    var body: some View {
        VStack {
            if !setTimer {
                Text("타이머 설정").bold().padding().fixedSize().font(.largeTitle)
                Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title).foregroundColor(.gray)
                HStack {
                    Picker(selection: $hour.onChange({ (Int) -> Void in
                            now = Date()
                            self.startTime = self.hour * 3600 + self.minute * 60 + self.second
                        }), label: Text("시")) {
                        ForEach(h, id: \.self) { h_set in
                            Text("\(h_set)").tag(h_set + 1000)
                        }
                    }.fixedSize()
                    Picker(selection: $minute.onChange({ (Int) -> Void in
                            now = Date()
                            self.startTime = self.hour * 3600 + self.minute * 60 + self.second
                        }), label: Text("분")) {
                        ForEach(m, id: \.self) { m_set in
                            Text("\(m_set)").tag(m_set + 100)
                        }
                    }.fixedSize()
                    Picker(selection: $second.onChange({ (Int) -> Void in
                            now = Date()
                            self.startTime = self.hour * 3600 + self.minute * 60 + self.second
                        }), label: Text("초")) {
                        ForEach(s, id: \.self) { s_set in
                            Text("\(s_set)").tag(s_set)
                        }
                    }.fixedSize()
                }
                HStack {
                    Text("ETA: ")
                    self.startTime == 0 ? Text("N/A") : Text(convertDate(inputTime: self.startTime, secEnable: false))
                }.padding()
                Toggle("무음 카운트", isOn: $muteSound.onChange({ (Bool) -> Void in
                    UserDefaults.standard.set(self.muteSound, forKey: "muteCount")
                })).padding()
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
                            if self.startTime == 0 {
                                !self.muteSound ? controlAudio(source: "timeOver1", enable: true) : controlAudio(source: "timeOver2", enable: true)
                            } else if self.startTime <= 10 {
                                controlAudio(source: "countDown", enable: !self.muteSound)
                            } else if self.startTime <= 30 {
                                controlAudio(source: "sound3", enable: !self.muteSound)
                            } else if self.startTime <= 60 {
                                controlAudio(source: "sound1", enable: !self.muteSound)
                            } else {
                                controlAudio(source: "sound2", enable: !self.muteSound)
                            }
                        })
                    }, label: { Text("시작") }).disabled(self.startTime == 0)
                    Button(action: {
                        self.startTime = 0
                        self.hour = 0
                        self.minute = 0
                        self.second = 0
                        self.pause = false
                        controlAudio(source: nil, enable: false)
                    }, label: { Text("초기화")}).disabled(self.startTime == 0)
                }
            } else {
                if self.startTime != 0 {
                    Text("타이머 시작").bold().padding().fixedSize().font(.largeTitle)
                } else {
                    Text("타이머 완료").bold().padding().fixedSize().font(.largeTitle)
                }
                if self.startTime % 2 == 0 {
                    if 62 > self.startTime && self.startTime > 54 {
                        Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title).foregroundColor(.red)
                    } else if 32 > self.startTime && self.startTime > 24 {
                        Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title).foregroundColor(.red)
                    } else if 12 > self.startTime && self.startTime > 4 {
                        Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title).foregroundColor(.red)
                    } else if self.startTime == 0 {
                        Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title).background(Color.red)
                    } else {
                        if 15 > self.startTime && self.startTime > 0 {
                            Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title).foregroundColor(.orange)
                        } else {
                            Text(convertTime(inputTime: self.startTime, dotEnable: true)).font(.title)
                        }
                    }
                } else {
                    if 16 > self.startTime && self.startTime > 0 {
                        Text(convertTime(inputTime: self.startTime, dotEnable: false)).font(.title).foregroundColor(.orange)
                    } else {
                        Text(convertTime(inputTime: self.startTime, dotEnable: false)).font(.title)
                    }
                }
                HStack {
                    Text("ETA: ")
                    Text(convertDate(inputTime: self.setTime, secEnable: true))
                }.padding()
                Toggle("무음 카운트", isOn: $muteSound.onChange({ (Bool) -> Void in
                    UserDefaults.standard.set(self.muteSound, forKey: "muteCount")
                })).disabled(self.startTime == 0).padding()
                HStack {
                    Button(action: {
                        self.setTimer = false
                        self.startTime = self.setTime
                        self.hour = self.setTime / 60 / 60
                        self.minute = self.setTime / 60 % 60
                        self.second = self.setTime % 60
                        self.timer?.invalidate()
                        now = Date()
                        controlAudio(source: nil, enable: false)
                    }, label: { self.startTime != 0 ? Text("정지") : Text("이전") })
                    Button(action: {
                        self.setTimer = false
                        self.pause = true
                        self.hour = self.startTime / 60 / 60
                        self.minute = self.startTime / 60 % 60
                        self.second = self.startTime % 60
                        self.timer?.invalidate()
                        now = Date()
                        controlAudio(source: nil, enable: false)
                    }, label: { Text("일시 정지") }).disabled(self.startTime == 0)
                    Button(action: {
                        self.setTimer = false
                        self.hour = 0
                        self.minute = 0
                        self.second = 0
                        self.startTime = 0
                        self.pause = false
                        self.timer?.invalidate()
                        controlAudio(source: nil, enable: false)
                    }, label: { Text("초기화") })
                }
            }
        }.padding()
    }
}

extension Binding {
    func onChange(_ handler: @escaping (Value) -> Void) -> Binding<Value> {
        return Binding(
            get: { self.wrappedValue },
            set: { selection in
                self.wrappedValue = selection
                handler(selection)
        })
    }
}

private func controlAudio(source: String?, enable: Bool) {
    let sound1 = Bundle.main.path(forResource: "ClockSound1", ofType: "mp3")
    let sound2 = Bundle.main.path(forResource: "ClockSound2", ofType: "mp3")
    let sound3 = Bundle.main.path(forResource: "ClockSound3", ofType: "mp3")
    let countDown = Bundle.main.path(forResource: "CountDown", ofType: "mp3")
    let timeOver1 = Bundle.main.path(forResource: "TimeOver1", ofType: "mp3")
    let timeOver2 = Bundle.main.path(forResource: "TimeOver2", ofType: "mp3")
    
    switch source {
    case "sound1": do { sound = try AVAudioPlayer(contentsOf: URL(fileURLWithPath: sound1!)) } catch { }
    case "sound2": do { sound = try AVAudioPlayer(contentsOf: URL(fileURLWithPath: sound2!)) } catch { }
    case "sound3": do { sound = try AVAudioPlayer(contentsOf: URL(fileURLWithPath: sound3!)) } catch { }
    case "countDown":
        do {
            sound = try AVAudioPlayer(contentsOf: URL(fileURLWithPath: countDown!))
            sound.currentTime = 7
        } catch { }
    case "timeOver1": do { sound = try AVAudioPlayer(contentsOf: URL(fileURLWithPath: timeOver1!)) } catch { }
    case "timeOver2": do { sound = try AVAudioPlayer(contentsOf: URL(fileURLWithPath: timeOver2!)) } catch { }
    default: if !enable { sound.stop() } else { source == nil ? NSLog("No audio source.") : NSLog("Audio not imported: \(source!)") }
    }
    if enable {
        if sound.isPlaying { sound.stop() }
        sound.prepareToPlay()
        sound.play()
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
