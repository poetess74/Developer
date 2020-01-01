//
//  ContentView.swift
//  Hiking
//
//  Created by HM on 1/1/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    let hikes = Hike.all()
    var body: some View {
        List(self.hikes, id: \.name) {
            hike in Text(hike.name)
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
