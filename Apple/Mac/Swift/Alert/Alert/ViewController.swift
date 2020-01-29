//
//  ViewController.swift
//  Alert
//
//  Created by HM on 2020/01/27.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation
import SwiftUI
import AVFoundation

private var alertSound = AVAudioPlayer()

struct ViewController: View {
    @EnvironmentObject var StoreDrive: StoreDrive
    @State private var animatedLevel: Double = 0.5
    @State private var animatingLevel: Double = 0
    let timer = Timer.publish(every: 0.15, on: .current, in: .common).autoconnect()
    
    var body: some View {
        ZStack {
            Rectangle().frame(maxWidth: .infinity, maxHeight: .infinity).background(self.StoreDrive.bgColor).opacity(animatingLevel).onReceive(timer) {_ in
                (self.animatedLevel > self.animatingLevel) && self.StoreDrive.altStatus != 0 ? (self.animatingLevel += 0.1) : (self.animatingLevel = 0.01)
            }
            VStack {
                HStack {
                    Button("Blue Alert") {
                        self.StoreDrive.bgColor = .blue
                        self.StoreDrive.alertColor = .blue
                        self.StoreDrive.altStatus = 1
                        playSound(source: self.StoreDrive.altStatus - 1)
                    }.foregroundColor(.blue)
                    Button("Yellow Alert") {
                        self.StoreDrive.bgColor = .yellow
                        self.StoreDrive.alertColor = .yellow
                        self.StoreDrive.altStatus = 2
                        playSound(source: self.StoreDrive.altStatus - 1)
                    }.foregroundColor(.yellow)
                    Button("Red Alert") {
                        self.StoreDrive.bgColor = .red
                        self.StoreDrive.alertColor = .red
                        self.StoreDrive.altStatus = 3
                        playSound(source: self.StoreDrive.altStatus - 1)
                    }.foregroundColor(.red)
                    Button("Black Alert") {
                        self.StoreDrive.bgColor = .black
                        self.StoreDrive.alertColor = Color.init(red: 0, green: 1, blue: 1, opacity: 1)
                        self.StoreDrive.altStatus = 4
                        playSound(source: self.StoreDrive.altStatus - 1)
                    }.foregroundColor(.black)
                }.padding()
                if (StoreDrive.altStatus != 0) {
                    Button("Clear Alert") {
                        self.StoreDrive.bgColor = .white
                        self.StoreDrive.alertColor = .green
                        self.StoreDrive.altStatus = 0
                        self.animatingLevel = 0.1
                        self.timer.upstream.connect().cancel()
                        playSound(source: -1)
                    }.foregroundColor(.green)
                } else {
                    Button("Clear Alert") {
                        playSound(source: -2)
                    }.foregroundColor(.gray)
                }
            }
        }
        .frame(maxWidth: .infinity, maxHeight: .infinity)
    }
}

private func playSound(source: Int) {
    let alertData: [String] = ["Blue", "Yellow", "Red", "Black"]
    if (source == -1) {
        alertSound.stop()
    } else if (source == -2) {
        alertSound.stop()
        if let soundURL = Bundle.main.path(forResource: "input_failed", ofType: "mp3") {
            do {
                alertSound = try AVAudioPlayer(contentsOf: URL(fileURLWithPath: soundURL))
                alertSound.prepareToPlay()
            } catch {
                NSLog("Failed to play audio source.")
            }
            alertSound.play()
        } else {
            NSLog("Audio source does not exist.")
        }
    } else {
        alertSound.stop()
        if let soundURL = Bundle.main.path(forResource: "\(alertData[source])", ofType: "mp3") {
            do {
                alertSound = try AVAudioPlayer(contentsOf: URL(fileURLWithPath: soundURL))
                alertSound.prepareToPlay()
            } catch {
                NSLog("Failed to play audio source.")
            }
            alertSound.play()
        } else {
            NSLog("Audio source does not exist.")
        }
    }
}

struct ViewController_Previews: PreviewProvider {
    static var previews: some View {
        ViewController()
    }
}
