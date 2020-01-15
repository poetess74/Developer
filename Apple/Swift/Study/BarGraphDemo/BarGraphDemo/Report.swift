//
//  Report.swift
//  BarGraphDemo
//
//  Created by HM on 1/15/20.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation

struct Report: Hashable {
    let year: String
    let revenue: Double
}

extension Report {
    static func all() -> [Report] {
        return [
            Report(year: "2001", revenue: 1500),
            Report(year: "2002", revenue: 3500),
            Report(year: "2003", revenue: 8500)
        ]
    }
}
