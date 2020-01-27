//
//  ContentView.swift
//  Alert
//
//  Created by HM on 2020/01/27.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @EnvironmentObject var StoreDrive: StoreDrive
    private let alertArray: [String] = ["No", "Blue", "Yellow", "Red", "Gray"]
    
    var body: some View {
        VStack {
            Text("\(self.alertArray[self.StoreDrive.altStatus]) alert armed.").padding()
            ViewController()
        }
        .frame(maxWidth: .infinity, maxHeight: .infinity)
    }
}


struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
