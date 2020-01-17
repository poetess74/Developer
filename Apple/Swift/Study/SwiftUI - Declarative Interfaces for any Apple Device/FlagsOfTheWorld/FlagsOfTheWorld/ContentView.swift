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
    @State private var selectedFlag: String = ""
    @State private var country: String = ""
    let flags = ["🇦🇽","🇩🇿","🇵🇰","🇺🇸","🇹🇷","🇧🇷"]
    var body: some View {
        List {
            Text(self.country)
            ForEach(0..<self.flags.count, id: \.self) { index in
                HStack {
                    Text(self.flags[index])
                        .font(.custom("Arial", size: 100))
                    Text("Flag \(index + 1)")
                }.onTapGesture {
                    self.showModal.toggle()
                    self.selectedFlag = self.flags[index]
                }
            }
        }.sheet(isPresented: self.$showModal) {
            FlagDetailView(country: self.$country, showModal: self.$showModal, flag: self.selectedFlag)
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
