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
                Text(convertTime(inputTime: startTime, dotEnable: true)).font(.title).foregroundColor(.gray)
                HStack {
                    Picker(selection: $hour.onChange({ (Int) -> Void in
                            now = Date()
                            startTime = hour * 3600 + minute * 60 + second
                        }), label: Text("시")) {
                        ForEach(h, id: \.self) { h_set in
                            Text("\(h_set)").tag(h_set + 1000)
                        }
                    }.fixedSize()
                    Picker(selection: $minute.onChange({ (Int) -> Void in
                            now = Date()
                            startTime = hour * 3600 + minute * 60 + second
                        }), label: Text("분")) {
                        ForEach(m, id: \.self) { m_set in
                            Text("\(m_set)").tag(m_set + 100)
                        }
                    }.fixedSize()
                    Picker(selection: $second.onChange({ (Int) -> Void in
                            now = Date()
                            startTime = hour * 3600 + minute * 60 + second
                        }), label: Text("초")) {
                        ForEach(s, id: \.self) { s_set in
                            Text("\(s_set)").tag(s_set)
                        }
                    }.fixedSize()
                }
                HStack {
                    Text("ETA: ")
                    startTime == 0 ? Text("N/A") : Text(convertDate(inputTime: startTime, secEnable: false))
                }
                Toggle("무음 카운트", isOn: $muteSound.onChange({ (Bool) -> Void in
                    UserDefaults.standard.set(muteSound, forKey: "muteCount")
                })).padding()
                HStack {
                    Button(action: {
                        setTimer = true
                        if !pause {
                            setTime = startTime
                        } else {
                            pause = false
                        }
                        now = Date()
                        timer = Timer.scheduledTimer(withTimeInterval: 1, repeats: true, block: { _ in
                            guard startTime > 0 else {
                                timer?.invalidate()
                                return
                            }
                            startTime -= 1
                            if startTime == 0 {
                                !muteSound ? controlAudio(source: "timeOver1", enable: true) : controlAudio(source: "timeOver2", enable: true)
                            } else if startTime <= 10 {
                                controlAudio(source: "countDown", enable: !muteSound)
                            } else if startTime <= 30 {
                                controlAudio(source: "sound3", enable: !muteSound)
                            } else if startTime <= 60 {
                                controlAudio(source: "sound1", enable: !muteSound)
                            } else {
                                controlAudio(source: "sound2", enable: !muteSound)
                            }
                        })
                    }, label: { Text("시작") }).disabled(startTime == 0)
                    Button(action: {
                        startTime = 0
                        hour = 0
                        minute = 0
                        second = 0
                        pause = false
                        controlAudio(source: nil, enable: false)
                    }, label: { Text("초기화")}).disabled(startTime == 0)
                }
                HStack {
                    Button(action: {

                    }, label: { Text("사운드 선택...")})
                }
            } else {
                if startTime != 0 {
                    Text("타이머 시작").bold().padding().fixedSize().font(.largeTitle)
                } else {
                    Text("타이머 완료").bold().padding().fixedSize().font(.largeTitle)
                }
                if startTime % 2 == 0 {
                    if 62 > startTime && startTime > 54 {
                        Text(convertTime(inputTime: startTime, dotEnable: true)).font(.title).foregroundColor(.red)
                    } else if 32 > startTime && startTime > 24 {
                        Text(convertTime(inputTime: startTime, dotEnable: true)).font(.title).foregroundColor(.red)
                    } else if 12 > startTime && startTime > 4 {
                        Text(convertTime(inputTime: startTime, dotEnable: true)).font(.title).foregroundColor(.red)
                    } else if startTime == 0 {
                        Text(convertTime(inputTime: startTime, dotEnable: true)).font(.title).background(Color.red)
                    } else {
                        if 15 > startTime && startTime > 0 {
                            Text(convertTime(inputTime: startTime, dotEnable: true)).font(.title).foregroundColor(.orange)
                        } else {
                            Text(convertTime(inputTime: startTime, dotEnable: true)).font(.title)
                        }
                    }
                } else {
                    if 16 > startTime && startTime > 0 {
                        Text(convertTime(inputTime: startTime, dotEnable: false)).font(.title).foregroundColor(.orange)
                    } else {
                        Text(convertTime(inputTime: startTime, dotEnable: false)).font(.title)
                    }
                }
                HStack {
                    Text("ETA: ")
                    if (startTime == 0) {
                        Text(convertDate(inputTime: setTime, secEnable: true)).strikethrough(true).foregroundColor(Color.gray)
                    } else {
                        Text(convertDate(inputTime: setTime, secEnable: true)).strikethrough(false)
                    }
                }
                Toggle("무음 카운트", isOn: $muteSound.onChange({ (Bool) -> Void in
                    UserDefaults.standard.set(muteSound, forKey: "muteCount")
                })).disabled(startTime == 0).padding()
                HStack {
                    Button(action: {
                        setTimer = false
                        startTime = setTime
                        hour = setTime / 60 / 60
                        minute = setTime / 60 % 60
                        second = setTime % 60
                        timer?.invalidate()
                        now = Date()
                        controlAudio(source: nil, enable: false)
                    }, label: { startTime != 0 ? Text("정지") : Text("이전") })
                    Button(action: {
                        setTimer = false
                        pause = true
                        hour = startTime / 60 / 60
                        minute = startTime / 60 % 60
                        second = startTime % 60
                        timer?.invalidate()
                        now = Date()
                        controlAudio(source: nil, enable: false)
                    }, label: { Text("일시 정지") }).disabled(startTime == 0)
                    Button(action: {
                        setTimer = false
                        hour = 0
                        minute = 0
                        second = 0
                        startTime = 0
                        pause = false
                        timer?.invalidate()
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
            get: { wrappedValue },
            set: { selection in
                wrappedValue = selection
                handler(selection)
        })
    }
}

@available(*, deprecated)
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
