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
    private let alertArray: [String] = ["GREEN", "BLUE", "YELLOW", "RED", "BLACK"]
    
    var body: some View {
        VStack {
            self.StoreDrive.altStatus != 0 ? Text("ALERT").bold().font(.title).foregroundColor(self.StoreDrive.alertColor) : Text("").bold().font(.title)
            Text("CONDITION \(self.alertArray[self.StoreDrive.altStatus])").bold().foregroundColor(self.StoreDrive.alertColor)
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
