//
//  ContentView.swift
//  FlagsOfTheWorld
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @State private var showModal: Bool = false
    var body: some View {
        Button("Show Modal") {
            self.showModal.toggle()
        }.sheet(isPresented: $showModal) {
            Text("I am a Modal")
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
