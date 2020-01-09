//
//  ContentView.swift
//  ObservableObjectAnotherExample
//
//  Created by HM on 1/9/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @ObservedObject var userSettings = UserSettings()
    var body: some View {
        VStack {
            Text("\(self.userSettings.score)")
                .font(.largeTitle)
            Button("Increment Score") {
                self.userSettings.score += 1
            }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
