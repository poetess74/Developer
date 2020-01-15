//
//  Card.swift
//  gestures-demo
//
//  Created by HM on 1/15/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct Card: View {
    let tapped: Bool
    var body: some View {
        VStack {
            Text("Card")
                .font(.largeTitle)
                .foregroundColor(.white)
        }.frame(minWidth: 0, maxWidth: .infinity, minHeight: 0, maxHeight: .infinity)
            .background(self.tapped ? Color.orange : Color.purple)
            .cornerRadius(30)
    }
}

struct Card_Previews: PreviewProvider {
    static var previews: some View {
        Card(tapped: false)
    }
}
