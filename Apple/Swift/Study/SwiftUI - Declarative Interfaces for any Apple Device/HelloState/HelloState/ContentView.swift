//
//  ContentView.swift
//  HelloState
//
//  Created by HM on 1/9/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @State var name: String = "John"
    var body: some View {
        VStack {
            Text(name)
                .font(.largeTitle)
            Button(action: {
                self.name = "Mary"
            }) {
                Text("Change Name")
            }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
