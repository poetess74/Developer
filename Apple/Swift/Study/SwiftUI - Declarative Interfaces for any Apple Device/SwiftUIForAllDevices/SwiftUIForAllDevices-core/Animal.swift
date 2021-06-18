//
//  Animal.swift
//  SwiftUIForAllDevices
//
//  Created by HM on 2020/02/03.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation

struct Animal: Hashable {
    let name: String
    let description: String
    let image: String
}

extension Animal {
    static var placeholder: Animal {
        return Animal(name: "", description: "", image: "")
    }
}
