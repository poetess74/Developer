//
//  ContentView.swift
//  DownloadImageSwiftUI
//
//  Created by HM on 1/21/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    var body: some View {
        VStack {
            URLImage(url: Constants.imageURL)
                .frame(width: UIScreen.main.bounds.width, height: UIScreen.main.bounds.height / 2)
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
