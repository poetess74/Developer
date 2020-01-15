//
//  BarGraph.swift
//  BarGraphDemo
//
//  Created by HM on 1/15/20.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation
import SwiftUI

struct BarGraph: View {
    var body: some View {
        VStack {
            HStack(alignment: .lastTextBaseline) {
                Rectangle()
                    .fill(Color.orange)
                    .frame(width: 100, height: 180)
                    .padding()
                Rectangle()
                    .fill(Color.green)
                    .frame(width: 100, height: 280)
                    .padding()
                Rectangle()
                    .fill(Color.blue)
                    .frame(width: 100, height: 380)
                    .padding()
                Spacer()
            }
        }
    }
}

struct BarGraph_Previews: PreviewProvider {
    static var previews: some View {
        BarGraph()
    }
}
