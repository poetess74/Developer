//
//  ContentView.swift
//  Coronavirus
//
//  Created by HM on 2020/02/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    var body: some View {
        TabView {
            TestView()
                .tabItem {
                    Image(systemName: "magnifyingglass").font(.title)
                    Text("검사")
                }
            AroundView()
                .tabItem {
                    Image(systemName: "location").font(.title)
                    Text("주변")
                }
            InfoView()
                .tabItem {
                    Image(systemName: "info.circle").font(.title)
                    Text("정보")
                }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
