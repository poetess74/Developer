//
//  ContentView.swift
//  FlagsOfTheWorld
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    let flags = ["🇦🇽","🇩🇿","🇵🇰","🇺🇸","🇹🇷","🇧🇷"]
    @State private var flagVM: FlagViewModel = FlagViewModel()
    var body: some View {
        List {
            Text(self.flagVM.country)
            ForEach(self.flags, id: \.self) { flag in
                HStack {
                    Text(flag)
                        .font(.custom("Arial", size: 100))
                    Spacer()
                }.onTapGesture {
                    self.flagVM.flag = flag
                    self.flagVM.showModal.toggle()
                }
            }
        }.sheet(isPresented: self.$flagVM.showModal) {
            FlagDetailView(flagVM: self.$flagVM)
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
