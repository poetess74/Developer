//
//  ContentView.swift
//  Night-Shift-Form
//
//  Created by HM on 1/16/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @State private var scheduled: Bool = true
    @State private var manuallyOn: Bool = false
    @State private var colorTemp: CGFloat = 0.5
    var body: some View {
        NavigationView {
            Form {
                Section(header: Text("Night Shift automatically shifts the colors of your display to the warmer end of the color spectrum after dark. This may help you get a better night's sleep. ")) {
                    Toggle(isOn: $scheduled) {
                        Text("Scheduled")
                    }
                    HStack {
                        VStack(alignment: .leading) {
                            Text("From")
                            Text("To")
                        }
                        Spacer()
                        NavigationLink(destination: Text("Scheduled Settings")) {
                            VStack {
                                Text("Sunset").foregroundColor(.blue)
                                Text("Sunrise").foregroundColor(.blue)
                            }
                        }.fixedSize()
                    }
                }
                Section() {
                    Toggle(isOn: $manuallyOn) {
                        Text("Manually Enable Until Tomorrow")
                    }
                }
                Section(header: Text("COLOR TEMPERATURE")) {
                    HStack {
                        Text("Less Warm")
                        Slider(value: $colorTemp)
                        Text("More Warm")
                    }
                }
            }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
