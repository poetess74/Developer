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
    let reports: [Report]
    var body: some View {
        VStack {
            HStack(alignment: .lastTextBaseline) {
                ForEach(self.reports, id: \.self) { report in
                    BarView(report: report)
                }
            }
        }
    }
}

struct BarGraph_Previews: PreviewProvider {
    static var previews: some View {
        BarGraph(reports: Report.all())
    }
}

struct BarView: View {
    let report: Report
    var body: some View {
        let value = report.revenue / 500
        let yValue = Swift.min(value * 20, 500)
        return VStack {
            Text(String(format: "$%.2f", report.revenue))
            Rectangle()
                .fill(Color.red)
                .frame(width: 100, height: CGFloat(yValue))
            Text(report.year)
        }
    }
}
