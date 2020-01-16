//
//  ContentView.swift
//  Notifications-Form
//
//  Created by HM on 1/16/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @State private var images = ["🗾","🌅","🌄","🌠","🎇","🌇","🗾","🌅","🌄","🌠","🎇","🌇"]
    var body: some View {
        NavigationView {
            Form {
                Section(footer: Text("Notification previews will be shown whether the iPhone is locked or unlocked")) {
                    HStack {
                        Text("Show Previews")
                        Spacer()
                        NavigationLink(destination: Text("")) {
                            Text("Always").foregroundColor(.gray)
                        }.fixedSize()
                    }
                }
                Section(footer: Text("Choose while apps can suggest shortcuts on the lock screen")) {
                    NavigationLink(destination: Text("")) {
                        Text("Siri Suggestions")
                    }
                }
                Section(header: Text("NOTIFICATION STYLE")) {
                    ForEach (0..<images.count, id: \.self) { index in
                        HStack {
                            Text(self.images[index])
                                .font(.largeTitle)
                            Text("Notification \(index + 1)")
                        }
                    }
                }
            }.navigationBarTitle("Notifications", displayMode: .inline)
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
