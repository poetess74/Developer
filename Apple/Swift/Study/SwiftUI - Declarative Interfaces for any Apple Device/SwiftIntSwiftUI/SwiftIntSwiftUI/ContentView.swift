//
//  ContentView.swift
//  SwiftIntSwiftUI
//
//  Created by HM on 1/20/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @ObservedObject var settingsVM = SettingsViewModel()
    var body: some View {
        VStack(alignment: .center) {
            Toggle(isOn: self.$settingsVM.isOn) {
                Text("")
            }.fixedSize()
        }.frame(minWidth: 0, maxWidth: .infinity, minHeight: 0, maxHeight: .infinity)
         .background(self.$settingsVM.isOn.wrappedValue ? Color.green : Color.gray)
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
