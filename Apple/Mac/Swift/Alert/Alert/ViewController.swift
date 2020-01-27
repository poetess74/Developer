//
//  ViewController.swift
//  Alert
//
//  Created by HM on 2020/01/27.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation
import SwiftUI

struct ViewController: View {
    @EnvironmentObject var StoreDrive: StoreDrive
    @State private var animatedLevel: Double = 0.5
    @State private var animatingLevel: Double = 0
    let timer = Timer.publish(every: 0.5, on: .current, in: .common).autoconnect()
    
    var body: some View {
        ZStack {
            Rectangle().frame(maxWidth: .infinity, maxHeight: .infinity).background(self.StoreDrive.bgColor).opacity(animatingLevel).onReceive(timer) {_ in
                (self.animatedLevel > self.animatingLevel) && self.StoreDrive.altStatus != 0 ? (self.animatingLevel += 0.1) : (self.animatingLevel = 0.1)
                NSLog(String(self.animatingLevel))
            }
            VStack {
                HStack {
                    Button("Blue Alert") {
                        self.StoreDrive.bgColor = .blue
                        self.StoreDrive.altStatus = 1
                    }
                    Button("Yellow Alert") {
                        self.StoreDrive.bgColor = .yellow
                        self.StoreDrive.altStatus = 2
                    }.foregroundColor(.black)
                    Button("Red Alert") {
                        self.StoreDrive.bgColor = .red
                        self.StoreDrive.altStatus = 3
                    }
                    Button("Gray Alert") {
                        self.StoreDrive.bgColor = .gray
                        self.StoreDrive.altStatus = 4
                    }
                }
                Button("Clear Alert") {
                    self.StoreDrive.bgColor = .white
                    self.StoreDrive.altStatus = 0
                    self.animatingLevel = 0.1
                    self.timer.upstream.connect().cancel()
                }.foregroundColor(.black)
            }
        }
        .frame(maxWidth: .infinity, maxHeight: .infinity)
    }
}


struct ViewController_Previews: PreviewProvider {
    static var previews: some View {
        ViewController()
    }
}
