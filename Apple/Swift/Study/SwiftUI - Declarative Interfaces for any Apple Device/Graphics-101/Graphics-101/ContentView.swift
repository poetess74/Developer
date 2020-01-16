//
//  ContentView.swift
//  Graphics-101
//
//  Created by HM on 1/15/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    var body: some View {
        VStack {
            Circle()
                .fill(Color.red)
                .frame(width: 200, height: 200)
            Circle()
                .stroke(Color.green, lineWidth: 20)
            Rectangle()
                .fill(Color.yellow)
                .frame(width: 100, height: 200)
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
